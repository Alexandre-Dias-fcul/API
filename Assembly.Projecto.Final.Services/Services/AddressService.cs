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
     public class AddressService:IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        public AddressService(IAddressRepository addressRepository) 
        { 
            _addressRepository = addressRepository;
        }

        public Address Add(Address address)
        {
            return _addressRepository.Add(address);
        }

        public Address Delete(Address address)
        {
            return _addressRepository.Delete(address);
        }

        public Address? Delete(int id)
        {
            return _addressRepository.Delete(id);
        }

        public List<Address> GetAll()
        {
            return _addressRepository.GetAll();
        }

        public Address? GetById(int id)
        {
            return _addressRepository.GetById(id);
        }

        public Address Update(Address address)
        {
             return _addressRepository.Update(address);
        }
    }
}
