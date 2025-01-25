using Assembly.Projecto.Final.Domain.Core.Repositories;
using Assembly.Projecto.Final.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Data.InMemory.Repositories
{
    public class FavoriteRepository:Repository<Favorite,int>,IFavoriteRepository
    {
        private readonly Database _db;
        public FavoriteRepository(Database db):base(db.Favorites)
        {
            _db = db;
        }
    }
}
