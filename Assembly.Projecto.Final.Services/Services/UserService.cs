using Assembly.Projecto.Final.Domain.Common;
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
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;

            _mapper = mapper;
        }

        public UserDto Add(CreateUserDto createUserDto)
        {
            User addedUser;

            using(_unitOfWork) 
            {
                var name = Name.Create(createUserDto.Name.FirstName, createUserDto.Name.MiddleNames,
                   createUserDto.Name.LastName);

                var user = User.Create(name, createUserDto.DateOfBirth, createUserDto.Gender,
                    createUserDto.PhotoFileName, createUserDto.IsActive);

                addedUser = _unitOfWork.UserRepository.Add(user);

                _unitOfWork.Commit();
            }

            return _mapper.Map<UserDto>(addedUser);
        }

        public AccountDto AccountAdd(int userId, CreateAccountDto createAccountDto)
        {
            using (_unitOfWork)
            {
                var user = _unitOfWork.UserRepository.GetByIdWithAccount(userId);

                NotFoundException.When(user is null, $"{nameof(user)} não foi encontrado.");

                CustomApplicationException.When(user.EntityLink is not null && user.EntityLink.Account is not null,
                    "A account já existe.");

                var account = Account.Create(createAccountDto.Password, createAccountDto.Email);


                if (user.EntityLink is not null)
                {
                    user.EntityLink.SetAccount(account);
                }
                else
                {
                    var entityLink = EntityLink.Create(EntityType.User, user.Id);

                    entityLink.SetAccount(account);

                    user.SetEntityLink(entityLink);
                }

                _unitOfWork.UserRepository.Update(user);

                _unitOfWork.Commit();

                var accountDto = _mapper.Map<AccountDto>(account);

                return accountDto;
            }
        }

        public AddressDto AddressAdd(int userId, CreateAddressDto createAddressDto)
        {
            using (_unitOfWork)
            {
                var user = _unitOfWork.UserRepository.GetByIdWithAddresses(userId);

                NotFoundException.When(user is null, $"{nameof(user)} não foi encontrado.");

                var exists = false;

                if (user.EntityLink is not null)
                {
                    exists = user.EntityLink.Addresses.Any(address => address.Street == createAddressDto.Street &&
                             address.City == createAddressDto.City && address.Country == createAddressDto.Country &&
                             address.PostalCode == createAddressDto.PostalCode);
                }

                CustomApplicationException.When(exists, "Este endereço já existe.");

                var address = Address.Create(createAddressDto.Street, createAddressDto.City, createAddressDto.Country,
                        createAddressDto.PostalCode);

                if (user.EntityLink is not null)
                {
                    user.EntityLink.AddAddress(address);
                }
                else
                {
                    var entityLink = EntityLink.Create(EntityType.User, user.Id);

                    entityLink.AddAddress(address);

                    user.SetEntityLink(entityLink);

                }

                _unitOfWork.UserRepository.Update(user);

                _unitOfWork.Commit();

                var addressDto = _mapper.Map<AddressDto>(address);

                return addressDto;
            }
        }

        public ContactDto ContactAdd(int userId, CreateContactDto createContactDto)
        {
            using (_unitOfWork)
            {
                var user = _unitOfWork.UserRepository.GetByIdWithContacts(userId);

                NotFoundException.When(user is null, $" {nameof(user)} não foi encontrado.");

                var exists = false;

                if (user.EntityLink is not null)
                {
                    exists = user.EntityLink.Contacts.Any(contact =>
                    contact.ContactType == createContactDto.ContactType && contact.Value == createContactDto.Value);
                }

                CustomApplicationException.When(exists, "Este contacto já existe.");

                var contact = Contact.Create(createContactDto.ContactType, createContactDto.Value);

                if (user.EntityLink is not null)
                {
                    user.EntityLink.AddContact(contact);
                }
                else
                {
                    var entityLink = EntityLink.Create(EntityType.User, user.Id);

                    user.SetEntityLink(entityLink);

                    entityLink.AddContact(contact);
                }

                _unitOfWork.UserRepository.Update(user);

                _unitOfWork.Commit();

                var contactDto = _mapper.Map<ContactDto>(contact);

                return contactDto;
            }
        }
        public UserDto Delete(UserDto userDto)
        {
            User deletedUser;

            using (_unitOfWork) 
            {
                var foundedUser = _unitOfWork.UserRepository.Delete(userDto.Id);

                NotFoundException.When(foundedUser is null, $"{nameof(foundedUser)} não foi encontrado.");

                deletedUser = _unitOfWork.UserRepository.Delete(foundedUser);

                _unitOfWork.Commit();
            }

            return _mapper.Map<UserDto>(deletedUser);
        }

        public UserDto Delete(int id)
        {
            User deletedUser;

            using (_unitOfWork)
            {
                var foundedUser = _unitOfWork.UserRepository.Delete(id);

                NotFoundException.When(foundedUser is null, $"{nameof(foundedUser)} não foi encontrado.");

                deletedUser = _unitOfWork.UserRepository.Delete(id);

                _unitOfWork.Commit();
            }

            return _mapper.Map<UserDto>(deletedUser);
        }

        public List<UserDto> GetAll()
        {
            var list = new List<UserDto>();

            foreach (var user in _unitOfWork.UserRepository.GetAll()) 
            {
                var userDto = _mapper.Map<UserDto>(user);

                list.Add(userDto);
            }

            return list;
        }

        public UserDto GetById(int id)
        {
            var user = _unitOfWork.UserRepository.GetById(id);

            return _mapper.Map<UserDto>(user);
        }

        public UserAllDto GetByIdWithAll(int id)
        {
            var user = _unitOfWork.UserRepository.GetByIdWithAll(id);

            return _mapper.Map<UserAllDto>(user);
        }

        public UserDto Update(UserDto userDto)
        {
            User updatedUser;

            using (_unitOfWork)
            {
                var foundedUser = _unitOfWork.UserRepository.Delete(userDto.Id);

                NotFoundException.When(foundedUser is null, $"{nameof(foundedUser)} não foi encontrado.");

                var name = Name.Create(userDto.Name.FirstName, userDto.Name.MiddleNames,
                   userDto.Name.LastName);

                foundedUser.Update(name, userDto.DateOfBirth, userDto.Gender,
                    userDto.PhotoFileName, userDto.IsActive);

                updatedUser = _unitOfWork.UserRepository.Update(foundedUser);

                _unitOfWork.Commit();
            }

            return _mapper.Map<UserDto>(updatedUser);
        }
    }
}
