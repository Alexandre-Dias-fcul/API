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
            var address = _mapper.Map<Address>(createAddressDto);

            Address addedAddress;

            using (_unitOfWork) 
            {
                _unitOfWork.BeginTransaction();

                addedAddress = _unitOfWork.AddressRepository.Add(address);

                _unitOfWork.Commit(); 
            }

            return _mapper.Map<AddressDto>(addedAddress);
        }

        public AddressDto Delete(AddressDto addressDto)
        {
            var address = _mapper.Map<Address>(addressDto);

            Address deletedAddress;

            using (_unitOfWork) 
            {
                _unitOfWork.BeginTransaction();

                var foundedAddress = _unitOfWork.AddressRepository.GetById(address.Id);

                if (foundedAddress == null) 
                {
                    throw new ArgumentNullException(nameof(foundedAddress), "Not found");
                }

                deletedAddress =_unitOfWork.AddressRepository.Delete(address);

                _unitOfWork.Commit();
            }


            return _mapper.Map<AddressDto>(deletedAddress);
        }

        public AddressDto Delete(int id)
        {
            return _unitOfWork.AddressRepository.Delete(id);
        }

        public List<AddressDto> GetAll()
        {
            return _unitOfWork.AddressRepository.GetAll();
        }

        public AddressDto GetById(int id)
        {
            return _unitOfWork.AddressRepository.GetById(id);
        }

        public AddressDto Update(AddressDto addressDto)
        {
             return _unitOfWork.AddressRepository.Update(address);
        }
    }
}
