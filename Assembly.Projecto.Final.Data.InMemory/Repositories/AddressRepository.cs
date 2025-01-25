using Assembly.Projecto.Final.Domain.Core.Repositories;
using Assembly.Projecto.Final.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Data.InMemory.Repositories
{
    public class AddressRepository:Repository<Address,int>,IAddressRepository
    {
        private readonly Database _db;

        public AddressRepository(Database db):base(db.Addresses)
        {
            _db = db;
        }
    }
}
