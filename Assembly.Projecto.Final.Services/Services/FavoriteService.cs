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
        private readonly IUnitOfWork _unitOfWork;
        public FavoriteService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        public Favorite Add(Favorite favorite)
        {
            return _unitOfWork.FavoriteRepository.Add(favorite);
        }

        public Favorite Delete(Favorite favorite)
        {
            return _unitOfWork.FavoriteRepository.Delete(favorite);
        }

        public Favorite? Delete(int id)
        {
            return _unitOfWork.FavoriteRepository.Delete(id);
        }

        public List<Favorite> GetAll()
        {
            return _unitOfWork.FavoriteRepository.GetAll();
        }

        public Favorite? GetById(int id)
        {
            return _unitOfWork.FavoriteRepository.GetById(id);
        }

        public Favorite Update(Favorite favorite)
        {
            return _unitOfWork.FavoriteRepository.Update(favorite);
        }
    }
}
