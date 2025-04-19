using Assembly.Projecto.Final.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Domain.Core.Repositories
{
    public interface IAccountRepository:IRepository<Account,int>
    {
        public Account? GetByEmailWithEmployee(string email);

        public Account? GetByEmailWithUser(string emal);

        public bool EmailExistsEmployee(string email);

        public bool EmailExistsUser(string email);
    }
}
