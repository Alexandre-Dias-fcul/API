using Assembly.Projecto.Final.Domain.Common;
using Assembly.Projecto.Final.Domain.Core.Repositories;
using Assembly.Projecto.Final.Domain.Enums;
using Assembly.Projecto.Final.Domain.Models;
using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.EmployeeUserDtos;
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
    public class StaffService : IStaffService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public StaffService(IUnitOfWork unitOfWork,IMapper mapper) 
        {
            _unitOfWork = unitOfWork;

            _mapper = mapper;
        }

        public void AccountAdd(int userId, CreateAccountDto createAccountDto)
        {
            var staff = _unitOfWork.StaffRepository.GetByIdWithAccount(userId);

            if (staff is null)
            {
                throw new ArgumentNullException(nameof(staff), "Não foi encontrado.");
            }

            if (staff.EntityLink is not null)
            {
                if (staff.EntityLink.Account is null)
                {
                    var account = Account.Create(createAccountDto.Password, createAccountDto.Email);

                    staff.EntityLink.SetAccount(account);

                    _unitOfWork.StaffRepository.Update(staff);
                }
            }
            else
            {
                var entityLink = EntityLink.Create(EntityType.Employee, staff.Id);

                staff.SetEntityLink(entityLink);

                var account = Account.Create(createAccountDto.Password, createAccountDto.Email);

                staff.EntityLink.SetAccount(account);

                _unitOfWork.StaffRepository.Update(staff);
            }
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

        public void AddressAdd(int userId, CreateAddressDto createAddressDto)
        {
            var staff = _unitOfWork.StaffRepository.GetByIdWithAddresses(userId);

            if (staff is null)
            {
                throw new ArgumentNullException(nameof(staff), "Não foi encontrado.");
            }

            var existe = false;

            if (staff.EntityLink is not null)
            {
                foreach (var address in staff.EntityLink.Addresses)
                {
                    if (address.Street == createAddressDto.Street && address.City == createAddressDto.City &&
                        address.Country == createAddressDto.Country && address.PostalCode == createAddressDto.PostalCode)
                    {
                        existe = true;
                    }
                }
            }

            if (existe is false)
            {
                var address = Address.Create(createAddressDto.Street, createAddressDto.City, createAddressDto.Country,
                    createAddressDto.PostalCode);

                if (staff.EntityLink is not null)
                {
                   staff.EntityLink.AddAddress(address);
                }
                else
                {
                    var entityLink = EntityLink.Create(EntityType.Employee, staff.Id);

                    staff.SetEntityLink(entityLink);

                    staff.EntityLink.AddAddress(address);
                }

                _unitOfWork.StaffRepository.Update(staff);
            }
        }

        public void ContactAdd(int userId, CreateContactDto createContactDto)
        {
            var staff = _unitOfWork.AgentRepository.GetByIdWithAccount(userId);

            if (staff is null)
            {
                throw new ArgumentNullException(nameof(staff), "Não foi encontrado.");
            }

            var existe = false;

            if (staff.EntityLink is not null)
            {
                foreach (var contact in staff.EntityLink.Contacts)
                {
                    if (contact.ContactType == createContactDto.ContactType && contact.Value == createContactDto.Value)
                    {
                        existe = true;
                    }
                }
            }

            if (existe == false)
            {
                var contact = Contact.Create(createContactDto.ContactType, createContactDto.Value);

                if (staff.EntityLink is not null)
                {
                    staff.EntityLink.AddContact(contact);
                }
                else
                {
                    var entityLink = EntityLink.Create(EntityType.Employee, staff.Id);

                    staff.SetEntityLink(entityLink);

                    staff.EntityLink.AddContact(contact);
                }

                _unitOfWork.AgentRepository.Update(staff);
            }
        }

        public StaffDto Delete(StaffDto staffDto)
        {
            Staff deletedStaff;

            using (_unitOfWork) 
            {
                var foundedStaff = _unitOfWork.StaffRepository.GetById(staffDto.Id);

                if(foundedStaff is null) 
                {
                    throw new ArgumentNullException(nameof(foundedStaff), "Não foi encontrado.");
                }

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

                if (foundedStaff is null)
                {
                    throw new ArgumentNullException(nameof(foundedStaff), "Não foi encontrado.");
                }

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

        public StaffDto Update(StaffDto staffDto)
        {

            Staff updatedStaff;

            using (_unitOfWork)
            {
                var foundedStaff = _unitOfWork.StaffRepository.GetById(staffDto.Id);

                if (foundedStaff is null)
                {
                    throw new ArgumentNullException(nameof(foundedStaff), "Não foi encontrado.");
                }

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
