using Assembly.Projecto.Final.Domain.Common;
using Assembly.Projecto.Final.Domain.Core.Repositories;
using Assembly.Projecto.Final.Domain.Models;
using Assembly.Projecto.Final.Services.Dtos;
using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.OtherModelsDtos;
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
        private readonly IMapper _mapper;

        public AccountService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        public AccountDto Add(CreateAccountDto createAccountDto)
        {
            var account =_mapper.Map<Account>(createAccountDto);

            Account addedAccount; 

            using (_unitOfWork) 
            {
                _unitOfWork.BeginTransaction();

                 addedAccount = _unitOfWork.AccountRepository.Add(account);

                _unitOfWork.Commit();
            }

            return _mapper.Map<AccountDto>(addedAccount);
        }

        public AccountDto Delete(AccountDto accountDto)
        {
             var account = _mapper.Map<Account>(accountDto);

            Account deletedAccount;

            using(_unitOfWork) 
            {
                _unitOfWork.BeginTransaction();

                var foundedAccount = _unitOfWork.AccountRepository.GetById(account.Id);

                if (foundedAccount == null) 
                {
                    throw new ArgumentNullException(nameof(foundedAccount), "Not found");
                }

                deletedAccount = _unitOfWork.AccountRepository.Delete(foundedAccount);

                _unitOfWork.Commit();
            }

             return _mapper.Map<AccountDto>(deletedAccount);
        }

        public AccountDto Delete(int id)
        {

            Account deletedAccount;

            using (_unitOfWork) 
            {
                _unitOfWork.BeginTransaction();

                var foundedAccount = _unitOfWork.AccountRepository.GetById(id);

                if(foundedAccount == null) 
                {
                    throw new ArgumentNullException(nameof(foundedAccount), "Not found");
                }

                deletedAccount = _unitOfWork.AccountRepository.Delete(id);

                _unitOfWork.Commit();
            }
                

            return _mapper.Map<AccountDto>(deletedAccount);
        }

        public List<AccountDto> GetAll()
        {
            var list = new List<AccountDto>();

            foreach(var account in _unitOfWork.AccountRepository.GetAll()) 
            {
                var accountDto = _mapper.Map<AccountDto>(account);

                list.Add(accountDto);
            }

            return list;
        }

        public AccountDto GetById(int id)
        {
            var account = _unitOfWork.AccountRepository.GetById(id);

            return _mapper.Map<AccountDto>(account);
        }

        public AccountDto Update(AccountDto accountDto)
        {
            var account = _mapper.Map<Account>(accountDto);

            Account updatedAccount;

            using (_unitOfWork) 
            {
                _unitOfWork.BeginTransaction();

                var foundedAccount = _unitOfWork.AccountRepository.GetById(accountDto.Id);

                if (foundedAccount is null)
                {
                    throw new ArgumentNullException(nameof(foundedAccount), "Not found");
                }

                foundedAccount.Update(accountDto.Password,accountDto.Email);

                updatedAccount = _unitOfWork.AccountRepository.Update(foundedAccount);

                _unitOfWork.Commit();
            } 

            return _mapper.Map<AccountDto>(updatedAccount);
        }
    }
}
