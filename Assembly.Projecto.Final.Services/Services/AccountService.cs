using Assembly.Projecto.Final.Domain.Core.Repositories;
using Assembly.Projecto.Final.Domain.Models;
using Assembly.Projecto.Final.Services.Dtos;
using Assembly.Projecto.Final.Services.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Services.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        public Account Add(Account account)
        {
            return _unitOfWork.AccountRepository.Add(account);
        }

        public Account Delete(Account account)
        {
             return _unitOfWork.AccountRepository.Delete(account);
        }

        public Account? Delete(int id)
        {
            return _unitOfWork.AccountRepository.Delete(id);
        }

        public List<Account> GetAll()
        {
            return _unitOfWork.AccountRepository.GetAll();
        }

        public Account? GetById(int id)
        {
            return _unitOfWork.AccountRepository.GetById(id);
        }

        public Account Update(Account account)
        {
            return _unitOfWork.AccountRepository.Update(account);
        }
    }
}
