using Assembly.Projecto.Final.Domain.Core.Repositories;
using Assembly.Projecto.Final.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Data.InMemory.Repositories
{
    public class FeedBackRepository:Repository<FeedBack,int>,IFeedBackRepository
    {
        private readonly Database _db;
        public FeedBackRepository(Database db):base(db.FeedBacks)
        {
            _db = db;
        }
    }
}
