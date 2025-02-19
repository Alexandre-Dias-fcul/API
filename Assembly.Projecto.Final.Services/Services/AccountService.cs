using Assembly.Projecto.Final.Domain.Core.Repositories;
using Assembly.Projecto.Final.Domain.Models;
using Assembly.Projecto.Final.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Services.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository) 
        { 
            _accountRepository = accountRepository;
        }
        public Account Add(Account account)
        {
            return _accountRepository.Add(account);
        }

        public Account Delete(Account account)
        {
             return _accountRepository.Delete(account);
        }

        public Account? Delete(int id)
        {
            return _accountRepository.Delete(id);
        }

        public List<Account> GetAll()
        {
            return _accountRepository.GetAll();
        }

        public Account? GetById(int id)
        {
            return _accountRepository.GetById(id);
        }

        public Account Update(Account account)
        {
            return _accountRepository.Update(account);
        }
    }
}
