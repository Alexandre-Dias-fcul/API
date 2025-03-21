using Assembly.Projecto.Final.Domain.Core.Repositories;
using Assembly.Projecto.Final.Domain.Models;
using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.OtherModelsDtos;
using Assembly.Projecto.Final.Services.Interfaces;
using AutoMapper;
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

        private readonly IMapper _mapper;

        public FavoriteService(IUnitOfWork unitOfWork,IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public FavoriteDto Add(CreateFavoriteDto createFavoriteDto)
        {
            Favorite addedFavorite;

            using (_unitOfWork) 
            {
                _unitOfWork.BeginTransaction();

                var foundedUser = _unitOfWork.UserRepository.GetById(createFavoriteDto.UserId);

                if (foundedUser is null) 
                {
                    throw new ArgumentNullException(nameof(foundedUser), "Não foi encontrado.");
                }

                var foundedListing = _unitOfWork.ListingRepository.GetById(createFavoriteDto.ListingId);

                if (foundedListing is null)
                {
                    throw new ArgumentNullException(nameof(foundedListing), "Não foi encontrado.");
                }

                var favorite = Favorite.Create(foundedUser, foundedListing);

                addedFavorite =_unitOfWork.FavoriteRepository.Add(favorite)

                _unitOfWork.Commit();
            }

            return _mapper.Map<FavoriteDto>(addedFavorite);
        }

        public FavoriteDto Delete(FavoriteDto favoriteDto)
        {
            Favorite deletedFavorite;

            using(_unitOfWork) 
            { 

            }
        }

        public FavoriteDto Delete(int id)
        {
            return _unitOfWork.FavoriteRepository.Delete(id);
        }

        public List<FavoriteDto> GetAll()
        {
            return _unitOfWork.FavoriteRepository.GetAll();
        }

        public FavoriteDto GetById(int id)
        {
            return _unitOfWork.FavoriteRepository.GetById(id);
        }

        public FavoriteDto Update(FavoriteDto favoriteDto)
        {
            return _unitOfWork.FavoriteRepository.Update(favorite);
        }
    }
}
