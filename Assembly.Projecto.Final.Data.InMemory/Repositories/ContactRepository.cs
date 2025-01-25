using Assembly.Projecto.Final.Domain.Core.Repositories;
using Assembly.Projecto.Final.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Data.InMemory.Repositories
{
    public class ContactRepository:Repository<Contact,int>,IContactRepository
    {
        private readonly Database _db;

        public ContactRepository(Database db):base(db.Contacts) 
        {
            _db = db;
        }
    }
}
