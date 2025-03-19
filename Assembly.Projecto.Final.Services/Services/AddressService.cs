﻿using Assembly.Projecto.Final.Domain.Core.Repositories;
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
     public class AddressService:IAddressService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        public AddressService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public AddressDto Add(CreateAddressDto createAddressDto)
        {
            return _unitOfWork.AddressRepository.Add(address);
        }

        public Address Delete(Address address)
        {
            return _unitOfWork.AddressRepository.Delete(address);
        }

        public Address? Delete(int id)
        {
            return _unitOfWork.AddressRepository.Delete(id);
        }

        public List<Address> GetAll()
        {
            return _unitOfWork.AddressRepository.GetAll();
        }

        public Address? GetById(int id)
        {
            return _unitOfWork.AddressRepository.GetById(id);
        }

        public Address Update(Address address)
        {
             return _unitOfWork.AddressRepository.Update(address);
        }
    }
}
