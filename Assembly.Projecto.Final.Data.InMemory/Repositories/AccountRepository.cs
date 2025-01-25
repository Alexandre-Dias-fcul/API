using Assembly.Projecto.Final.Domain.Core.Repositories;
using Assembly.Projecto.Final.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Data.InMemory.Repositories
{
    public class AccountRepository:Repository<Account,int>,IAccountRepository
    {
        private readonly Database _db;
        public AccountRepository(Database db):base(db.Accounts) 
        {
            _db = db;
        }
    }
}
