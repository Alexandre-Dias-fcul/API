﻿using Assembly.Projecto.Final.Domain.Core.Repositories;
using Assembly.Projecto.Final.Domain.Enums;
using Assembly.Projecto.Final.Domain.Models;
using Assembly.Projecto.Final.Services.Dtos;
using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.EmployeeUserDtos;
using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.OtherModelsDtos;
using Assembly.Projecto.Final.Services.Exceptions;
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

        public ListingDto Add(CreateListingServiceDto createListingServiceDto)
        {
            Listing addedListing;

            using (_unitOfWork) 
            {
                var listing = Listing.Create(createListingServiceDto.Type,createListingServiceDto.Status,
                    createListingServiceDto.NumberOfBathrooms,createListingServiceDto.NumberOfBathrooms,
                    createListingServiceDto.NumberOfKitchens,createListingServiceDto.Price,createListingServiceDto.Location,
                    createListingServiceDto.Area,createListingServiceDto.Parking,createListingServiceDto.Description,
                    createListingServiceDto.MainImageFileName,createListingServiceDto.OtherImagesFileNames);

                var agent = _unitOfWork.AgentRepository.GetById(createListingServiceDto.AgentId);

                NotFoundException.When(agent is null, $"{nameof(agent)} não foi encontrado.");

                listing.SetAgent(agent);

                addedListing = _unitOfWork.ListingRepository.Add(listing);

                _unitOfWork.Commit();
            }

            return _mapper.Map<ListingDto>(addedListing);
        }

        public ReassignDto ListingReassign(int listingId, int agentId)
        {
            using (_unitOfWork) 
            {
                _unitOfWork.BeginTransaction();

                var listing = _unitOfWork.ListingRepository.GetById(listingId);

                NotFoundException.When(listing is null, $" {nameof(listing)} não foi encontrada.");

                var agent = _unitOfWork.AgentRepository.GetById(agentId);

                NotFoundException.When(agent is null, $"{nameof(agent)} não foi encontrado.");

                CustomApplicationException.When(listing.AgentId == agent.Id, " Esta listing já é deste agente.");

                CustomApplicationException.When(agent.Supervisor is null,"O agente não tem supervisor.");

                var olderAgentId = listing.AgentId;

                listing.SetAgent(agent);
               
                var reassign = Reassign.Create(olderAgentId, listing.AgentId,(int)agent.SupervisorId, DateTime.UtcNow);

                _unitOfWork.ListingRepository.Update(listing);

                var addedReassign = _unitOfWork.ReassignRepository.Add(reassign);

                _unitOfWork.Commit();

                return _mapper.Map<ReassignDto>(addedReassign);

            }      
        }
        public ListingDto Delete(ListingDto listingDto)
        {
            Listing deletedListing;

            using (_unitOfWork) 
            {
                var foundedListing = _unitOfWork.ListingRepository.GetById(listingDto.Id);

                NotFoundException.When(foundedListing is null,$" { nameof(foundedListing) } não foi encontrado.");

                deletedListing = _unitOfWork.ListingRepository.Delete(foundedListing);

                _unitOfWork.Commit();
            }

            return _mapper.Map<ListingDto>(deletedListing);
        }

        public ListingDto Delete(int id)
        {
            Listing deletedListing;

            using (_unitOfWork)
            {
                var foundedListing = _unitOfWork.ListingRepository.GetById(id);

                NotFoundException.When(foundedListing is null, $" {nameof(foundedListing)} não foi encontrado.");

                deletedListing = _unitOfWork.ListingRepository.Delete(id);

                _unitOfWork.Commit();
            }

            return _mapper.Map<ListingDto>(deletedListing);
        }

        public List<ListingDto> GetAll()
        {
            var list = new List<ListingDto>();

            foreach(var listing in _unitOfWork.ListingRepository.GetAll()) 
            {
                var listingDto = _mapper.Map<ListingDto>(listing);

                list.Add(listingDto);
            }

            return list;
        }

        public ListingDto GetById(int id)
        {
            var listing = _unitOfWork.ListingRepository.GetById(id);

            return _mapper.Map<ListingDto>(listing);
        }

        public ListingDto Update(ListingDto listingDto)
        {
            Listing updatedListing;

            using (_unitOfWork)
            {
                var foundedListing = _unitOfWork.ListingRepository.GetById(listingDto.Id);

                NotFoundException.When(foundedListing is null, $" {nameof(foundedListing)} não foi encontrado.");

                foundedListing.Update(listingDto.Type, listingDto.Status,
                    listingDto.NumberOfBathrooms, listingDto.NumberOfBathrooms,
                    listingDto.NumberOfKitchens,listingDto.Price, listingDto.Location,
                    listingDto.Area, listingDto.Parking, listingDto.Description,
                    listingDto.MainImageFileName, listingDto.OtherImagesFileNames);

                updatedListing = _unitOfWork.ListingRepository.Update(foundedListing);

                _unitOfWork.Commit();
            }

            return _mapper.Map<ListingDto>(updatedListing);
        }
    }
}
