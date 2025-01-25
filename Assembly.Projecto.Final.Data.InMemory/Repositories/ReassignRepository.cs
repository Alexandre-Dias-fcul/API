using Assembly.Projecto.Final.Domain.Core.Repositories;
using Assembly.Projecto.Final.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Data.InMemory.Repositories
{
     public class ReassignRepository:Repository<Reassign,int>,IReassignRepository
    {
        private readonly Database _db;
        public ReassignRepository(Database db):base(db.Reassigns)
        { 
            _db = db;
        }
    }
}
