using Assembly.Projecto.Final.Data.EntityFramework.Context;
using Assembly.Projecto.Final.Domain.Core.Repositories;
using Assembly.Projecto.Final.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Data.EntityFramework.Repositories
{
    public class AccountRepository : Repository<Account, int>, IAccountRepository
    {
        public AccountRepository(ApplicationDbContext context) : base(context)
        {
             
        }

        public Account? GetByEmailWithEmployee(string email)
        {
            return DbSet.Include(e => e.EntityLink).ThenInclude(em => em.Employee).FirstOrDefault(a => a.Email == email);
        }
    }
}
