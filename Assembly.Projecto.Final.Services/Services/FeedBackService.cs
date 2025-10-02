using Assembly.Projecto.Final.Domain.Core.Repositories;
using Assembly.Projecto.Final.Domain.Models;
using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.OtherModelsDtos;
using Assembly.Projecto.Final.Services.Exceptions;
using Assembly.Projecto.Final.Services.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Services.Services
{
    public class FeedBackService : IFeedBackService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        public FeedBackService(IUnitOfWork unitOfWork,IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public FeedBackDto Add(CreateFeedBackDto createFeedBackDto)
        {
            FeedBack addedFeedBack;

            using (_unitOfWork) 
            {
                var listing = _unitOfWork.ListingRepository.GetById(createFeedBackDto.ListingId);

                NotFoundException.When(listing is null,$"{nameof(listing)} não foi encontrada.");

                var user = _unitOfWork.UserRepository.GetById(createFeedBackDto.UserId);

                NotFoundException.When(user is null,$"{nameof(user)} não foi encontrado.");

                if (_unitOfWork.FeedBackRepository.Existe(user,listing) is null) 
                {
                    var feedBack = FeedBack.Create(createFeedBackDto.Rate, createFeedBackDto.Comment,
                   createFeedBackDto.CommentDate);

                    feedBack.SetListing(listing);

                    feedBack.SetUser(user);

                    addedFeedBack = _unitOfWork.FeedBackRepository.Add(feedBack);

                    _unitOfWork.Commit();
                }
                else 
                {
                    addedFeedBack = _unitOfWork.FeedBackRepository.Existe(user, listing);
                }
            }

            return _mapper.Map<FeedBackDto>(addedFeedBack);
        }

        public FeedBackDto Delete(FeedBackDto feedBackDto)
        {
            FeedBack deletedFeedBack;

            using (_unitOfWork) 
            {

                var foundedFeedBack = _unitOfWork.FeedBackRepository.GetById(feedBackDto.Id);

                NotFoundException.When(foundedFeedBack is null,$" {nameof(foundedFeedBack)} não foi encontrado.");

                deletedFeedBack = _unitOfWork.FeedBackRepository.Delete(foundedFeedBack);

                _unitOfWork.Commit();
            }

            return _mapper.Map<FeedBackDto>(deletedFeedBack);
        }

        public FeedBackDto Delete(int id)
        {
            FeedBack deletedFeedBack;

            using (_unitOfWork)
            {

                var foundedFeedBack = _unitOfWork.FeedBackRepository.GetById(id);

                NotFoundException.When(foundedFeedBack is null, $" {nameof(foundedFeedBack)} não foi encontrado.");

                deletedFeedBack = _unitOfWork.FeedBackRepository.Delete(id);

                _unitOfWork.Commit();
            }

            return _mapper.Map<FeedBackDto>(deletedFeedBack);
        }

        public List<FeedBackDto> GetAll()
        {
            var list = new List<FeedBackDto>();

            foreach (var feedBack in _unitOfWork.FeedBackRepository.GetAll()) 
            {
                var feedBackDto = _mapper.Map<FeedBackDto>(feedBack);

                list.Add(feedBackDto);
            }

            return list;
        }

        public FeedBackDto GetById(int id)
        {
            var feedBack = _unitOfWork.FeedBackRepository.GetById(id);

            return _mapper.Map<FeedBackDto>(feedBack);
        }

        public List<FeedBackDto> GetByListingId(int idListing)
        {
            var feedBacks = _unitOfWork.FeedBackRepository.GetByListingId(idListing);

            return _mapper.Map<List<FeedBackDto>>(feedBacks);
        }

        public FeedBackDto Update(FeedBackDto feedBackDto)
        {
            FeedBack updatedFeedBack;

            using (_unitOfWork)
            {
                var foundedFeedBack = _unitOfWork.FeedBackRepository.GetById(feedBackDto.Id);

                NotFoundException.When(foundedFeedBack is null, $" {nameof(foundedFeedBack)} não foi encontrado.");

                foundedFeedBack.Update(feedBackDto.Rate,feedBackDto.Comment,feedBackDto.CommentDate);

                updatedFeedBack = _unitOfWork.FeedBackRepository.Update(foundedFeedBack);

                _unitOfWork.Commit();
            }

            return _mapper.Map<FeedBackDto>(updatedFeedBack);
        }
    }
}
