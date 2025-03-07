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
        private readonly IListingRepository _listingRepository;
        private readonly IAgentRepository _agentRepository;

        private readonly IMapper _mapper;
        public ListingService(IListingRepository listingRepository,IAgentRepository agentRepository, IMapper mapper) 
        { 
            _listingRepository = listingRepository;
            _agentRepository = agentRepository;
            _mapper = mapper;
        }

        public ListingDto Add(ListingDto listingDto)
        {
            var listing = Listing.Create(listingDto.Type,listingDto.Status,listingDto.NumberOfRooms,
                listingDto.NumberOfBathrooms,listingDto.NumberOfKitchens,listingDto.Price,listingDto.Location,
                listingDto.Area,listingDto.Parking,listingDto.Description,listingDto.MainImageFileName,
                listingDto.OtherImagesFileNames);

            var agent = _agentRepository.GetById(listingDto.AgentId);

            if (agent == null) 
            {
                throw new ArgumentNullException();
            }

            listing.SetAgent(agent);

            return _mapper.Map<ListingDto>(_listingRepository.Add(listing));
        }

        public ListingDtoId Delete(ListingDtoId listingDtoId)
        {
            var listing = _mapper.Map<Listing>(listingDtoId);

            return _mapper.Map<ListingDtoId>(_listingRepository.Delete(listing));
        }

        public ListingDtoId Delete(int id)
        {
            return _mapper.Map<ListingDtoId>(_listingRepository.Delete(id));
        }

        public List<ListingDtoId> GetAll()
        {
            return _mapper.Map<List<ListingDtoId>>(_listingRepository.GetAll());
        }

        public ListingDtoId GetById(int id)
        {
            return _mapper.Map<ListingDtoId>(_listingRepository.GetById(id));
        }

        public ListingDtoId Update(ListingDtoId listingDtoId)
        {
            var listing = _listingRepository.GetById(listingDtoId.Id);

            if(listing == null) 
            {
                throw new ArgumentNullException();
            }

            listing.Update(listingDtoId.Type, listingDtoId.Status, listingDtoId.NumberOfRooms,
                listingDtoId.NumberOfBathrooms, listingDtoId.NumberOfKitchens, listingDtoId.Price, listingDtoId.Location,
                listingDtoId.Area, listingDtoId.Parking, listingDtoId.Description, listingDtoId.MainImageFileName,
                listingDtoId.OtherImagesFileNames);

            return _mapper.Map<ListingDtoId>(_listingRepository.Update(listing));
        }
    }
}
