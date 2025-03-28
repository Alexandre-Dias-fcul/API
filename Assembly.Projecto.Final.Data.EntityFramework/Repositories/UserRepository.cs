using Assembly.Projecto.Final.Data.EntityFramework.Context;
using Assembly.Projecto.Final.Domain.Core.Repositories;
using Assembly.Projecto.Final.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Data.EntityFramework.Repositories
{
    public class UserRepository :Repository<User,int>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public User? GetByIdWithAccount(int id)
        {
            return DbSet.Include(u => u.EntityLink)
                .ThenInclude(el => el.Account)
                .FirstOrDefault(u => u.Id == id);
        }

        public User? GetByIdWithAddresses(int id)
        {
            return DbSet.Include(u => u.EntityLink)
                 .ThenInclude(el => el.Addresses)
                 .FirstOrDefault(u => u.Id == id);
        }

        public User? GetByIdWithContacts(int id)
        {
            return DbSet.Include(u => u.EntityLink)
                 .ThenInclude(el => el.Contacts)
                 .FirstOrDefault(u => u.Id == id);
        }
    }
}
