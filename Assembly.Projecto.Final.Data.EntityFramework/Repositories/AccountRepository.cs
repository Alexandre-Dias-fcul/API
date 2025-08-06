using Assembly.Projecto.Final.Data.EntityFramework.Context;
using Assembly.Projecto.Final.Domain.Common;
using Assembly.Projecto.Final.Domain.Core.Repositories;
using Assembly.Projecto.Final.Domain.Enums;
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

        public bool EmailExistsEmployee(string email)
        {
            var accounts = DbSet.Include(e => e.EntityLink)
                .Where(e => e.Email == email && e.EntityLink.EntityType == EntityType.Employee).ToList();

            if (accounts.Count > 0)
            {
                return true;
            }

            return false;
        }

        public bool EmailExistsUser(string email)
        {
            var accounts = DbSet.Include(e => e.EntityLink)
                .Where(e => e.Email == email && e.EntityLink.EntityType == EntityType.User).ToList();

            if (accounts.Count > 0)
            {
                return true;
            }

            return false;
        }

        public Account? GetByEmailWithEmployee(string email)
        {
            return DbSet.Include(e => e.EntityLink).ThenInclude(e => e.Employee)
                  .FirstOrDefault(e => e.Email == email && e.EntityLink.EntityType == EntityType.Employee);
        }

        public Account? GetByEmailWithUser(string email) 
        {
            return DbSet.Include(e => e.EntityLink).ThenInclude(e => e.User)
                   .FirstOrDefault(e => e.Email == email && e.EntityLink.EntityType == EntityType.User);   
        }   
    }
}
