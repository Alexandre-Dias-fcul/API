using Assembly.Projecto.Final.Domain.Core.Repositories;
using Assembly.Projecto.Final.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Data.InMemory.Repositories
{
    public class UserRepository : Repository<User,int>,IUserRepository
    {
        private readonly Database _db;
       
        public UserRepository(Database db):base(db.Users)
        {
            _db = db;
        }
    }
}
