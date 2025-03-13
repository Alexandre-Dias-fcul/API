using Assembly.Projecto.Final.Domain.Core.Repositories;
using Assembly.Projecto.Final.Domain.Models;
using Assembly.Projecto.Final.Services.Dtos;
using Assembly.Projecto.Final.Services.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Services.Services
{
    public class ListingService : IListingService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        public ListingService(IUnitOfWork unitOfWork, IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public ListingDto Add(ListingDto listingDto)
        {
            var listing = Listing.Create(listingDto.Type,listingDto.Status,listingDto.NumberOfRooms,
                listingDto.NumberOfBathrooms,listingDto.NumberOfKitchens,listingDto.Price,listingDto.Location,
                listingDto.Area,listingDto.Parking,listingDto.Description,listingDto.MainImageFileName,
                listingDto.OtherImagesFileNames);

            var agent = _unitOfWork.AgentRepository.GetById(listingDto.AgentId);

            if (agent == null) 
            {
                throw new ArgumentNullException();
            }

            listing.SetAgent(agent);

            return _mapper.Map<ListingDto>(_unitOfWork.ListingRepository.Add(listing));
        }

        public ListingDtoId Delete(ListingDtoId listingDtoId)
        {
            var listing = _mapper.Map<Listing>(listingDtoId);

            return _mapper.Map<ListingDtoId>(_unitOfWork.ListingRepository.Delete(listing));
        }

        public ListingDtoId Delete(int id)
        {
            return _mapper.Map<ListingDtoId>(_unitOfWork.ListingRepository.Delete(id));
        }

        public List<ListingDtoId> GetAll()
        {
            return _mapper.Map<List<ListingDtoId>>(_unitOfWork.ListingRepository.GetAll());
        }

        public ListingDtoId GetById(int id)
        {
            return _mapper.Map<ListingDtoId>(_unitOfWork.ListingRepository.GetById(id));
        }

        public ListingDtoId Update(ListingDtoId listingDtoId)
        {
            var listing = _unitOfWork.ListingRepository.GetById(listingDtoId.Id);

            if(listing == null) 
            {
                throw new ArgumentNullException();
            }

            listing.Update(listingDtoId.Type, listingDtoId.Status, listingDtoId.NumberOfRooms,
                listingDtoId.NumberOfBathrooms, listingDtoId.NumberOfKitchens, listingDtoId.Price, listingDtoId.Location,
                listingDtoId.Area, listingDtoId.Parking, listingDtoId.Description, listingDtoId.MainImageFileName,
                listingDtoId.OtherImagesFileNames);

            return _mapper.Map<ListingDtoId>(_unitOfWork.ListingRepository.Update(listing));
        }
    }
}
