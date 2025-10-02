using Assembly.Projecto.Final.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Domain.Core.Repositories
{
    public interface IFavoriteRepository:IRepository<Favorite,int>
    {
        public Favorite? Existe(User user, Listing listing);

        public List<Favorite> GetAllByUserId(int userId);
    }
}
