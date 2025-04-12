using Assembly.Projecto.Final.Domain.Common;
using Assembly.Projecto.Final.Domain.Core.Repositories;
using Assembly.Projecto.Final.Domain.Enums;
using Assembly.Projecto.Final.Domain.Models;
using Assembly.Projecto.Final.Services.Dtos;
using Assembly.Projecto.Final.Services.Dtos.GetDtos;
using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.EmployeeUserDtos;
using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.OtherModelsDtos;
using Assembly.Projecto.Final.Services.Exceptions;
using Assembly.Projecto.Final.Services.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Services.Services
{
    public class AgentService : IAgentService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        public AgentService(IUnitOfWork unitOfWork, IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public AgentDto Add(CreateAgentDto createAgentDto)
        {
            Agent addedAgent;

            using (_unitOfWork) 
            {
                var name = Name.Create(createAgentDto.Name.FirstName,string.Join(" ",createAgentDto.Name.MiddleNames),
                    createAgentDto.Name.LastName);

                var agent = Agent.Create(name, createAgentDto.DateOfBirth, createAgentDto.Gender,
                    createAgentDto.PhotoFileName, createAgentDto.IsActive,createAgentDto.HiredDate, 
                    createAgentDto.DateOfTermination, createAgentDto.Role);

                if (createAgentDto.SupervisorId is not null) 
                {
                    var supervisor = _unitOfWork.AgentRepository.GetById((int)createAgentDto.SupervisorId);

                    NotFoundException.When(supervisor is null, $"{nameof(supervisor)} não foi encontrado.");

                    agent.SetSupervisor(supervisor);
                }

                addedAgent = _unitOfWork.AgentRepository.Add(agent);

                _unitOfWork.Commit();
            }

            return _mapper.Map<AgentDto>(addedAgent);
        }

        public AccountDto AccountAdd(int agentId, CreateAccountDto createAccountDto)
        {
            using (_unitOfWork) 
            {
                var agent = _unitOfWork.AgentRepository.GetByIdWithAccount(agentId);

                NotFoundException.When(agent is null, $"{nameof(agent)} não foi encontrado.");

                CustomApplicationException.When(agent.EntityLink is not null && agent.EntityLink.Account is not null,
                    "A account já existe");

                byte[] passwordHash;
                byte[] passwordSalt;

                using (var hmac = new HMACSHA512()) 
                {
                    passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(createAccountDto.Password));
                    passwordSalt = hmac.Key;
                }

                var account = Account.Create(passwordHash, passwordSalt, createAccountDto.Email);

                if (agent.EntityLink is null)
                {
                     var entityLink = EntityLink.Create(EntityType.Employee, agent.Id);

                     agent.SetEntityLink(entityLink);     
                }

                agent.EntityLink.SetAccount(account);

                _unitOfWork.AgentRepository.Update(agent);

                var accountDto = _mapper.Map<AccountDto>(agent.EntityLink.Account);

                _unitOfWork.Commit();

                return accountDto;
            }   
        }

        public AddressDto AddressAdd(int agentId, CreateAddressDto createAddressDto)
        {
            using (_unitOfWork)
            {
                var agent = _unitOfWork.AgentRepository.GetByIdWithAddresses(agentId);

                NotFoundException.When(agent is null, $"{nameof(agent)} não foi encontrado.");

                if (agent.EntityLink is null)
                {
                    var entityLink = EntityLink.Create(EntityType.Employee, agent.Id);

                    agent.SetEntityLink(entityLink);
                }

                var exists = agent.EntityLink.Addresses.Any(address => address.Street == createAddressDto.Street &&
                             address.City == createAddressDto.City && address.Country == createAddressDto.Country &&
                             address.PostalCode == createAddressDto.PostalCode);

                NotFoundException.When(exists, "Este endereço já existe.");

                var address = Address.Create(createAddressDto.Street, createAddressDto.City, createAddressDto.Country,
                        createAddressDto.PostalCode);

                
                agent.EntityLink.AddAddress(address);

                _unitOfWork.AgentRepository.Update(agent);

                var foundedAddress = agent.EntityLink.Addresses.FirstOrDefault(a => a.Street == address.Street &&
                          a.City == address.City && a.Country == address.Country && a.PostalCode == address.PostalCode);

                _unitOfWork.Commit();

                var addressDto = _mapper.Map<AddressDto>(foundedAddress);

                return addressDto;
            }
        }

        public ContactDto ContactAdd(int agentId, CreateContactDto createContactDto)
        {
            using (_unitOfWork) 
            {
                var agent = _unitOfWork.AgentRepository.GetByIdWithContacts(agentId);

                NotFoundException.When(agent is null, $"{nameof(agent)} não foi encontrado.");

                if (agent.EntityLink is null)
                {
                    var entityLink = EntityLink.Create(EntityType.Employee, agent.Id);

                    agent.SetEntityLink(entityLink);
                }

                var exists = agent.EntityLink.Contacts.Any(contact =>
                    contact.ContactType == createContactDto.ContactType && contact.Value == createContactDto.Value);

                CustomApplicationException.When(exists,"Este contacto já existe.");

                var contact = Contact.Create(createContactDto.ContactType, createContactDto.Value);

                agent.EntityLink.AddContact(contact);

                _unitOfWork.AgentRepository.Update(agent);

                var foundedContact = agent.EntityLink.Contacts.FirstOrDefault(c => c.ContactType == contact.ContactType 
                                && c.Value == contact.Value);

                _unitOfWork.Commit();

                var contactDto = _mapper.Map<ContactDto>(foundedContact);

                return contactDto;
            }
        }

        public AccountDto AccountUpdate(int agentId, UpdateAccountDto updateAccountDto)
        {
            using (_unitOfWork)
            {
                var agent = _unitOfWork.AgentRepository.GetByIdWithAccount(agentId);

                NotFoundException.When(agent is null, $"{nameof(agent)} não foi encontrado.");

                NotFoundException.When(agent.EntityLink is null, "A account não existe.");

                NotFoundException.When(agent.EntityLink.Account is null, "A account não existe.");

                bool isSamePassword;
                byte[] passowrdHash;
                byte[] passwordSalt;

                using (var hmac = new HMACSHA512(agent.EntityLink.Account.PasswordSalt))
                {
                    var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(updateAccountDto.Password));
                   
                    isSamePassword = computedHash.SequenceEqual(agent.EntityLink.Account.PasswordHash);
                }

                if (isSamePassword)
                {
                    passowrdHash = agent.EntityLink.Account.PasswordHash;
                    passwordSalt = agent.EntityLink.Account.PasswordSalt;
                }
                else
                {
                    using (var hmac = new HMACSHA512())
                    {
                        passowrdHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(updateAccountDto.Password));

                        passwordSalt = hmac.Key;
                    }
                }

                if (!isSamePassword || updateAccountDto.Email != agent.EntityLink.Account.Email)
                { 
                    agent.EntityLink.Account.Update(passowrdHash,passwordSalt,updateAccountDto.Email);

                    _unitOfWork.AgentRepository.Update(agent);

                    _unitOfWork.Commit();
                }
                
                var updatedAccountDto = _mapper.Map<AccountDto>(agent.EntityLink.Account);

                return updatedAccountDto;
            }
        }

        public AddressDto AddressUpdate(int agentId, AddressDto addressDto)
        {
            using (_unitOfWork) 
            {
                var agent = _unitOfWork.AgentRepository.GetByIdWithAddresses(agentId);

                NotFoundException.When(agent is null,$"{nameof(agent)} não foi encontado.");

                NotFoundException.When(agent.EntityLink is null, "O address não existe.");

                NotFoundException.When(agent.EntityLink.Addresses is null, "O address não existe.");

                var address = agent.EntityLink.Addresses.FirstOrDefault(a => a.Id == addressDto.Id);

                NotFoundException.When(address is null, "O address não existe.");

                if(address.Street != addressDto.Street || address.City != addressDto.City 
                     || address.Country != addressDto.Country || address.PostalCode != addressDto.PostalCode) 
                {
                    agent.EntityLink.Addresses.FirstOrDefault(a => a.Id == addressDto.Id).
                        Update(addressDto.Street, addressDto.City, addressDto.Country, addressDto.PostalCode);

                    _unitOfWork.AgentRepository.Update(agent);

                    _unitOfWork.Commit();
                }

                var foundedAddress = agent.EntityLink.Addresses.FirstOrDefault(a => a.Id == addressDto.Id);

                var updatedAddressDto = _mapper.Map<AddressDto>(foundedAddress);

                return updatedAddressDto;
            }
        }

        public ContactDto ContactUpdate(int agentId, ContactDto contactDto)
        {
            using (_unitOfWork) 
            {
                var agent = _unitOfWork.AgentRepository.GetByIdWithContacts(agentId);

                NotFoundException.When(agent is null, $"{nameof(agent)} não foi encontado.");

                NotFoundException.When(agent.EntityLink is null, "O contacto não existe.");

                NotFoundException.When(agent.EntityLink.Contacts is null, "O contacto não existe.");

                var contacto = agent.EntityLink.Contacts.FirstOrDefault(c => c.Id == contactDto.Id);

                NotFoundException.When(contacto is null, "O contacto não existe.");

                if (contacto.ContactType != contactDto.ContactType || contacto.Value != contactDto.Value) 
                {
                    agent.EntityLink.Contacts.FirstOrDefault(c => c.Id == contactDto.Id)
                        .Update(contactDto.ContactType, contactDto.Value);

                    _unitOfWork.AgentRepository.Update(agent);

                    _unitOfWork.Commit();
                }

                var foundedContact = agent.EntityLink.Contacts.FirstOrDefault(c => c.Id == contactDto.Id);

                var updatedContactDto = _mapper.Map<ContactDto>(foundedContact);

                return updatedContactDto;

            }
        }

        public AgentDto Delete(AgentDto agentDto)
        {
            Agent deletedAgent;

            using(_unitOfWork) 
            {

                var foundedAgent = _unitOfWork.AgentRepository.GetById(agentDto.Id);

                NotFoundException.When(foundedAgent is null, $"{nameof(foundedAgent)} não foi encontrado.");

                deletedAgent =_unitOfWork.AgentRepository.Delete(foundedAgent);

                _unitOfWork.Commit();
            }

            return _mapper.Map<AgentDto>(deletedAgent);
        }

        public AgentDto Delete(int id)
        {
            Agent deletedAgent;

            using (_unitOfWork)
            {

                var foundedAgent = _unitOfWork.AgentRepository.GetById(id);

                NotFoundException.When(foundedAgent is null, $"{nameof(foundedAgent)} não foi encontrado.");

                deletedAgent = _unitOfWork.AgentRepository.Delete(id);

                _unitOfWork.Commit();
            }

            return _mapper.Map<AgentDto>(deletedAgent);
        }

        public List<AgentDto> GetAll()
        {
            var list = new List<AgentDto>();

            foreach (var agent in _unitOfWork.AgentRepository.GetAll())
            {
                var agentDto = _mapper.Map<AgentDto>(agent);

                list.Add(agentDto);
            }

            return list;
        }

        public AgentDto GetById(int id)
        {
            var agent = _unitOfWork.AgentRepository.GetById(id);

            return _mapper.Map<AgentDto>(agent);
        }

        public AgentDto Update(AgentDto agentDto)
        {
            Agent updatedAgent;

            using (_unitOfWork)
            {
                var foundedAgent = _unitOfWork.AgentRepository.GetById(agentDto.Id);

                NotFoundException.When(foundedAgent is null, $"{nameof(foundedAgent)} não foi encontrado.");

                foundedAgent.Update(agentDto.Name.FirstName,string.Join(" ",agentDto.Name.MiddleNames),agentDto.Name.LastName,
                    agentDto.DateOfBirth,agentDto.Gender,agentDto.PhotoFileName,agentDto.IsActive);

                if (agentDto.SupervisorId is not null)
                {
                    var supervisor = _unitOfWork.AgentRepository.GetById((int)agentDto.SupervisorId);

                    NotFoundException.When(supervisor is null, $"{nameof(supervisor)} não foi encontrado.");

                    foundedAgent.SetSupervisor(supervisor);
                }

                updatedAgent = _unitOfWork.AgentRepository.Update(foundedAgent);

                _unitOfWork.Commit();
            }

            return _mapper.Map<AgentDto>(updatedAgent);
        }

        public AgentAllDto GetByIdWithAll(int id)
        {
            var agent = _unitOfWork.AgentRepository.GetByIdWithAll(id);

            return _mapper.Map<AgentAllDto>(agent);
        }

        public AgentWithPersonalContactsDto GetByIdWithPersonalContacts(int id)
        {
            var agent = _unitOfWork.AgentRepository.GetByIdWithPersonalContacts(id);

            return _mapper.Map<AgentWithPersonalContactsDto>(agent);
        }

        public AgentWithParticipantsDto GetByIdWithParticipants(int id)
        {
            var agent = _unitOfWork.AgentRepository.GetByIdWithParticipants(id);

            return _mapper.Map<AgentWithParticipantsDto>(agent);
        }
    }
}
