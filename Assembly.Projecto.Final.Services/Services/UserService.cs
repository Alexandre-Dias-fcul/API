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
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;

            _mapper = mapper;
        }

        public void AccountAdd(int userId, CreateAccountDto createAccountDto)
        {
            var user = _unitOfWork.UserRepository.GetByIdWithAccount(userId);

            if (user is null)
            {
                throw new ArgumentNullException(nameof(user), "Não foi encontrado.");
            }

            if (user.EntityLink is not null)
            {
                if (user.EntityLink.Account is null)
                {
                    var account = Account.Create(createAccountDto.Password, createAccountDto.Email);

                    user.EntityLink.SetAccount(account);

                    _unitOfWork.UserRepository.Update(user);

                    _unitOfWork.Commit();
                }
            }
            else
            {
                var entityLink = EntityLink.Create(EntityType.User, user.Id);

                user.SetEntityLink(entityLink);

                var account = Account.Create(createAccountDto.Password, createAccountDto.Email);

                user.EntityLink.SetAccount(account);

                _unitOfWork.UserRepository.Update(user);

                _unitOfWork.Commit();
            }
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

        public void AddressAdd(int userId, CreateAddressDto createAddressDto)
        {
            var user = _unitOfWork.UserRepository.GetByIdWithAddresses(userId);

            if (user is null)
            {
                throw new ArgumentNullException(nameof(user), "Não foi encontrado.");
            }

            var existe = false;

            if (user.EntityLink is not null)
            {
                foreach (var address in user.EntityLink.Addresses)
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

                if (user.EntityLink is not null)
                {
                    user.EntityLink.AddAddress(address);
                }
                else
                {
                    var entityLink = EntityLink.Create(EntityType.User, user.Id);

                    user.SetEntityLink(entityLink);

                    user.EntityLink.AddAddress(address);
                }

                _unitOfWork.UserRepository.Update(user);

                _unitOfWork.Commit();
            }
        }

        public void ContactAdd(int userId, CreateContactDto createContactDto)
        {
            var user = _unitOfWork.UserRepository.GetByIdWithAccount(userId);

            if (user is null)
            {
                throw new ArgumentNullException(nameof(user), "Não foi encontrado.");
            }

            var existe = false;

            if (user.EntityLink is not null)
            {
                foreach (var contact in user.EntityLink.Contacts)
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

                if (user.EntityLink is not null)
                {
                    user.EntityLink.AddContact(contact);
                }
                else
                {
                    var entityLink = EntityLink.Create(EntityType.User, user.Id);

                    user.SetEntityLink(entityLink);

                    user.EntityLink.AddContact(contact);
                }

                _unitOfWork.UserRepository.Update(user);

                _unitOfWork.Commit();
            }
        }

        public UserDto Delete(UserDto userDto)
        {
            User deletedUser;

            using (_unitOfWork) 
            {
                var foundedUser = _unitOfWork.UserRepository.Delete(userDto.Id);

                if(foundedUser is null) 
                {
                    throw new ArgumentNullException(nameof(foundedUser), "Não foi encontrado.");
                }

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

                if (foundedUser is null)
                {
                    throw new ArgumentNullException(nameof(foundedUser), "Não foi encontrado.");
                }

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

        public UserDto Update(UserDto userDto)
        {
            User updatedUser;

            using (_unitOfWork)
            {
                var foundedUser = _unitOfWork.UserRepository.Delete(userDto.Id);

                if (foundedUser is null)
                {
                    throw new ArgumentNullException(nameof(foundedUser), "Não foi encontrado.");
                }

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
