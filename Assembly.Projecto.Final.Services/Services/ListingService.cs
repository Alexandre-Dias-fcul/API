﻿using Assembly.Projecto.Final.Domain.Core.Repositories;
using Assembly.Projecto.Final.Domain.Models;
using Assembly.Projecto.Final.Services.Dtos;
using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.OtherModelsDtos;
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

        public ListingDto Add(CreateListingDto createListingDto)
        {
            Listing addedListing;

            using (_unitOfWork) 
            {
                _unitOfWork.BeginTransaction();

                var listing = Listing.Create(createListingDto.Type,createListingDto.Status,
                    createListingDto.NumberOfBathrooms,createListingDto.NumberOfBathrooms,
                    createListingDto.NumberOfKitchens,createListingDto.Price,createListingDto.Location,
                    createListingDto.Area,createListingDto.Parking,createListingDto.Description,
                    createListingDto.MainImageFileName,createListingDto.OtherImagesFileNames);

                addedListing = _unitOfWork.ListingRepository.Add(listing);

                _unitOfWork.Commit();
            }

            return _mapper.Map<ListingDto>(addedListing);
        }

        public ListingDto Delete(ListingDto listingDto)
        {
            Listing deletedListing;

            using (_unitOfWork) 
            {
                _unitOfWork.BeginTransaction();

                var foundedListing = _unitOfWork.ListingRepository.Delete(listingDto.Id);

                if(foundedListing is null) 
                {
                    throw new ArgumentNullException(nameof(foundedListing), "Não foi encontrado.");
                }

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
                _unitOfWork.BeginTransaction();

                var foundedListing = _unitOfWork.ListingRepository.Delete(id);

                if (foundedListing is null)
                {
                    throw new ArgumentNullException(nameof(foundedListing), "Não foi encontrado.");
                }

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
                _unitOfWork.BeginTransaction();

                var foundedListing = _unitOfWork.ListingRepository.Delete(listingDto.Id);

                if (foundedListing is null)
                {
                    throw new ArgumentNullException(nameof(foundedListing), "Não foi encontrado.");
                }

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
