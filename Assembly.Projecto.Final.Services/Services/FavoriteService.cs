using Assembly.Projecto.Final.Domain.Core.Repositories;
using Assembly.Projecto.Final.Domain.Models;
using Assembly.Projecto.Final.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Services.Services
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IFavoriteRepository _favoriteRepository;
        public FavoriteService(IFavoriteRepository favoriteRepository) 
        { 
            _favoriteRepository = favoriteRepository;
        }
        public Favorite Add(Favorite favorite)
        {
            return _favoriteRepository.Add(favorite);
        }

        public Favorite Delete(Favorite favorite)
        {
            return _favoriteRepository.Delete(favorite);
        }

        public Favorite? Delete(int id)
        {
            return _favoriteRepository.Delete(id);
        }

        public List<Favorite> GetAll()
        {
            return _favoriteRepository.GetAll();
        }

        public Favorite? GetById(int id)
        {
            return _favoriteRepository.GetById(id);
        }

        public Favorite Update(Favorite favorite)
        {
            return _favoriteRepository.Update(favorite);
        }
    }
}
