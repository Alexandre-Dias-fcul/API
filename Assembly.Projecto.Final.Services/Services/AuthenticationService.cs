using Assembly.Projecto.Final.Domain.Common;
using Assembly.Projecto.Final.Domain.Core.Repositories;
using Assembly.Projecto.Final.Domain.Enums;
using Assembly.Projecto.Final.Domain.Models;
using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.OtherModelsDtos;
using Assembly.Projecto.Final.Services.Exceptions;
using Assembly.Projecto.Final.Services.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Services.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        private readonly IConfiguration _config;
        public AuthenticationService(IUnitOfWork unitOfWork, IMapper mapper,IConfiguration config)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _config = config;
        }

        public string AuthenticationEmployee(string email, string password)
        {
            var account = _unitOfWork.AccountRepository.GetByEmailWithEmployee(email);

            NotFoundException.When(account is null, $"{nameof(account)} não foi encontrada.");

            CustomApplicationException.When(account.EntityLink.EntityType is not EntityType.Employee, " Não é empregado.");

            CustomApplicationException.When(!VerifyPassword(password, account.PasswordHash, account.PasswordSalt),
                "Password inválida");

            var employeeId = account.EntityLink.Employee.Id;
            string role;
            int id;

            var agent = _unitOfWork.AgentRepository.GetById(employeeId);

            if (agent is not null)
            {
                id = agent.Id;
                role = agent.Role.ToString();
            }
            else
            {
                var staff = _unitOfWork.StaffRepository.GetById(employeeId);

                NotFoundException.When(staff is null, $"{nameof(staff)} não foi encontrado.");

                id = staff.Id;
                role = "Staff";
            }

            return GenerateJwtToken(id, email, role);
        }

        public string AuthenticationUser(string email, string password)
        {
            var account = _unitOfWork.AccountRepository.GetByEmailWithUser(email);

            NotFoundException.When(account is null, $"{nameof(account)} não foi encontrada.");

            CustomApplicationException.When(account.EntityLink.EntityType is not EntityType.User, " Não é usuário.");

            CustomApplicationException.When(!VerifyPassword(password, account.PasswordHash, account.PasswordSalt),
               "Password inválida");

            var userId = account.EntityLink.User.Id;

            var user = _unitOfWork.UserRepository.GetById(userId);

            NotFoundException.When(user is null, $"{nameof(user)} não foi encontrado.");

            var id = user.Id;

            var role = "User";

            return GenerateJwtToken(id, email,role);
        }

        private string GenerateJwtToken(int id, string email, string role)
        {
            var claims = new[]
            {
                new Claim("Id", id.ToString()),
                new Claim("Email", email),
                new Claim("Role", role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddMinutes(50);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private bool VerifyPassword(string inputPassword, byte[] storedHash, byte[] storedSalt)
        {
            using (var hmac = new HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(inputPassword));
                return computedHash.SequenceEqual(storedHash);
            }
        }  
    }
}
