﻿using Assembly.Projecto.Final.Domain.Common;
using Assembly.Projecto.Final.Domain.Core.Repositories;
using Assembly.Projecto.Final.Domain.Enums;
using Assembly.Projecto.Final.Domain.Models;
using Assembly.Projecto.Final.Services.Dtos.GetDtos;
using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.EmployeeUserDtos;
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
    public class StaffService : IStaffService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public StaffService(IUnitOfWork unitOfWork,IMapper mapper) 
        {
            _unitOfWork = unitOfWork;

            _mapper = mapper;
        }

        public StaffDto Add(CreateStaffDto createStaffDto)
        {
            Staff addedStaff;

            using(_unitOfWork) 
            {
                var name = Name.Create(createStaffDto.Name.FirstName, createStaffDto.Name.MiddleNames,
                    createStaffDto.Name.LastName);

                var staff = Staff.Create(name, createStaffDto.DateOfBirth, createStaffDto.Gender,
                    createStaffDto.PhotoFileName, createStaffDto.IsActive,createStaffDto.HiredDate,
                    createStaffDto.DateOfTermination);

                addedStaff = _unitOfWork.StaffRepository.Add(staff);

                _unitOfWork.Commit();
            }

            return _mapper.Map<StaffDto>(addedStaff);
        }

        public AccountDto AccountAdd(int staffId, CreateAccountDto createAccountDto)
        {
            using (_unitOfWork)
            {
                var staff = _unitOfWork.StaffRepository.GetByIdWithAccount(staffId);

                NotFoundException.When(staff is null, $"{nameof(staff)} não foi encontrado.");

                CustomApplicationException.When(staff.EntityLink is not null && staff.EntityLink.Account is not null,
                    "A account já existe");

                var account = Account.Create(createAccountDto.Password, createAccountDto.Email);

                if (staff.EntityLink is null)
                {
                    var entityLink = EntityLink.Create(EntityType.Employee, staff.Id);

                    staff.SetEntityLink(entityLink);
                }

                staff.EntityLink.SetAccount(account);

                _unitOfWork.StaffRepository.Update(staff);

                var accountDto = _mapper.Map<AccountDto>(staff.EntityLink.Account);

                _unitOfWork.Commit();

                return accountDto;
            }
        }

        public AddressDto AddressAdd(int staffId, CreateAddressDto createAddressDto)
        {
            using (_unitOfWork)
            {
                var staff = _unitOfWork.StaffRepository.GetByIdWithAddresses(staffId);

                NotFoundException.When(staff is null, $"{nameof(staff)} não foi encontrado.");

                var exists = false;

                if (staff.EntityLink is not null)
                {
                    exists = staff.EntityLink.Addresses.Any(address => address.Street == createAddressDto.Street &&
                             address.City == createAddressDto.City && address.Country == createAddressDto.Country &&
                             address.PostalCode == createAddressDto.PostalCode);
                }

                NotFoundException.When(exists, "Este endereço já existe.");

                var address = Address.Create(createAddressDto.Street, createAddressDto.City, createAddressDto.Country,
                        createAddressDto.PostalCode);

                if (staff.EntityLink is null)
                {
                    var entityLink = EntityLink.Create(EntityType.Employee, staff.Id);

                    staff.SetEntityLink(entityLink);
                }

                staff.EntityLink.AddAddress(address);

                _unitOfWork.StaffRepository.Update(staff);

                var foundedAddress = staff.EntityLink.Addresses.FirstOrDefault(a => a.Street == address.Street &&
                          a.City == address.City && a.Country == address.Country && a.PostalCode == address.PostalCode);

                _unitOfWork.Commit();

                var addressDto = _mapper.Map<AddressDto>(foundedAddress);

                return addressDto;
            }
        }

        public ContactDto ContactAdd(int staffId, CreateContactDto createContactDto)
        {
            using (_unitOfWork)
            {
                var staff = _unitOfWork.StaffRepository.GetByIdWithContacts(staffId);

                NotFoundException.When(staff is null, $"{nameof(staff)} não foi encontrado.");

                var existe = false;

                if (staff.EntityLink is not null)
                {
                    existe = staff.EntityLink.Contacts.Any(contact =>
                    contact.ContactType == createContactDto.ContactType && contact.Value == createContactDto.Value);
                }

                CustomApplicationException.When(existe, "Este contacto já existe.");

                var contact = Contact.Create(createContactDto.ContactType, createContactDto.Value);

                if (staff.EntityLink is null)
                {
                    var entityLink = EntityLink.Create(EntityType.Employee, staff.Id);

                    staff.SetEntityLink(entityLink);
                }

                staff.EntityLink.AddContact(contact);

                _unitOfWork.StaffRepository.Update(staff);

                var foundedContact = staff.EntityLink.Contacts.FirstOrDefault(c => c.ContactType == contact.ContactType
                                && c.Value == contact.Value);

                _unitOfWork.Commit();

                var contactDto = _mapper.Map<ContactDto>(foundedContact);

                return contactDto;
            }
        }

        public StaffDto Delete(StaffDto staffDto)
        {
            Staff deletedStaff;

            using (_unitOfWork) 
            {
                var foundedStaff = _unitOfWork.StaffRepository.GetById(staffDto.Id);

                NotFoundException.When(foundedStaff is null, $"{nameof(foundedStaff)} não foi encontrado.");

                deletedStaff = _unitOfWork.StaffRepository.Delete(foundedStaff);

                _unitOfWork.Commit();
            }

            return _mapper.Map<StaffDto>(deletedStaff);
        }

        public StaffDto Delete(int id)
        {
            Staff deletedStaff;

            using (_unitOfWork)
            {
                var foundedStaff = _unitOfWork.StaffRepository.GetById(id);

                NotFoundException.When(foundedStaff is null, $"{nameof(foundedStaff)} não foi encontrado.");

                deletedStaff = _unitOfWork.StaffRepository.Delete(id);

                _unitOfWork.Commit();
            }

            return _mapper.Map<StaffDto>(deletedStaff);
        }

        public List<StaffDto> GetAll()
        {
            var list = new List<StaffDto>();

            foreach(var staff in _unitOfWork.StaffRepository.GetAll()) 
            {
                var staffDto = _mapper.Map<StaffDto>(staff);

                list.Add(staffDto);
            }

            return list;
        }

        public StaffDto GetById(int id)
        {
            var staff = _unitOfWork.StaffRepository.GetById(id);

            return _mapper.Map<StaffDto>(staff);
        }

        public StaffAllDto GetByIdWithAll(int id)
        {
            var staff = _unitOfWork.StaffRepository.GetByIdWithAll(id);

            return _mapper.Map<StaffAllDto>(staff);
        }

        public StaffDto Update(StaffDto staffDto)
        {

            Staff updatedStaff;

            using (_unitOfWork)
            {
                var foundedStaff = _unitOfWork.StaffRepository.GetById(staffDto.Id);

                NotFoundException.When(foundedStaff is null, $"{nameof(foundedStaff)} não foi encontrado.");

                var name = Name.Create(staffDto.Name.FirstName,staffDto.Name.MiddleNames,
                   staffDto.Name.LastName);

                foundedStaff.Update(name, staffDto.DateOfBirth, staffDto.Gender,
                    staffDto.PhotoFileName, staffDto.IsActive, staffDto.HiredDate,
                    staffDto.DateOfTermination);

                updatedStaff = _unitOfWork.StaffRepository.Update(foundedStaff);

                _unitOfWork.Commit();
            }

            return _mapper.Map<StaffDto>(updatedStaff);
        }
    }
}
