using Assembly.Projecto.Final.Domain.Core.Repositories;
using Assembly.Projecto.Final.Domain.Models;
using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.OtherModelsDtos;
using Assembly.Projecto.Final.Services.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            Address addedAddress;

            using (_unitOfWork) 
            {
                _unitOfWork.BeginTransaction();

                var address = Address.Create(createAddressDto.Street, createAddressDto.City, createAddressDto.Country,
                    createAddressDto.PostalCode);

                addedAddress = _unitOfWork.AddressRepository.Add(address);

                _unitOfWork.Commit(); 
            }

            return _mapper.Map<AddressDto>(addedAddress);
        }

        public AddressDto Delete(AddressDto addressDto)
        {
            Address deletedAddress;

            using (_unitOfWork) 
            {
                _unitOfWork.BeginTransaction();

                var foundedAddress = _unitOfWork.AddressRepository.GetById(addressDto.Id);

                if (foundedAddress is null) 
                {
                    throw new ArgumentNullException(nameof(foundedAddress), "Não foi encontrado.");
                }

                deletedAddress =_unitOfWork.AddressRepository.Delete(foundedAddress);

                _unitOfWork.Commit();
            }


            return _mapper.Map<AddressDto>(deletedAddress);
        }

        public AddressDto Delete(int id)
        {
            Address deletedAddress;

            using (_unitOfWork) 
            {
                _unitOfWork.BeginTransaction();

                var foundedAddress = _unitOfWork.AddressRepository.GetById(id);

                if(foundedAddress is null) 
                {
                    throw new ArgumentNullException(nameof(foundedAddress), "Não foi encontrado.");
                }

                deletedAddress =  _unitOfWork.AddressRepository.Delete(id)

                _unitOfWork.Commit();

            }

            return _mapper.Map<AddressDto>(deletedAddress);
        }

        public List<AddressDto> GetAll()
        {
            var list = new List<AddressDto>();

            foreach(var address in _unitOfWork.AddressRepository.GetAll()) 
            {
                var addressDto = _mapper.Map<AddressDto>(address);

                list.Add(addressDto);
            }

            return list;
        }

        public AddressDto GetById(int id)
        {
            var address =_unitOfWork.AddressRepository.GetById(id);

            return _mapper.Map<AddressDto>(address);
        }

        public AddressDto Update(AddressDto addressDto)
        {
            Address updatedAddress;
            
            using (_unitOfWork) 
            {
                _unitOfWork.BeginTransaction();

                var foundedAddress = _unitOfWork.AddressRepository.GetById(addressDto.Id);  
                
                if(foundedAddress is null) 
                {
                    throw new ArgumentNullException(nameof(foundedAddress), "Não foi encontrado.");
                }

                foundedAddress.Update(addressDto.Street, addressDto.City, addressDto.Country, addressDto.PostalCode);

                updatedAddress = _unitOfWork.AddressRepository.Update(foundedAddress);

                _unitOfWork.Commit();
            }

            return _mapper.Map<AddressDto>(updatedAddress);
        }
    }
}
