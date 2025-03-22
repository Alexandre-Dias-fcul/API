using Assembly.Projecto.Final.Domain.Core.Repositories;
using Assembly.Projecto.Final.Domain.Models;
using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.EmployeeUserDtos;
using Assembly.Projecto.Final.Services.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;

            _mapper = mapper;
        }

        public UserDto Add(CreateUserDto createUserDto)
        {
            throw new NotImplementedException();
        }

        public UserDto Delete(UserDto userDto)
        {
            throw new NotImplementedException();
        }

        public UserDto Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<UserDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public UserDto Update(UserDto userDto)
        {
            throw new NotImplementedException();
        }
    }
}
