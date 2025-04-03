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
                var name = Name.Create(createAgentDto.Name.FirstName,createAgentDto.Name.MiddleNames,
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

                var account = Account.Create(createAccountDto.Password, createAccountDto.Email);

                if (agent.EntityLink is not null)
                {
                    agent.EntityLink.SetAccount(account);
                }
                else
                {
                    var entityLink = EntityLink.Create(EntityType.Employee, agent.Id);

                    entityLink.SetAccount(account);

                    agent.SetEntityLink(entityLink);
                }

                _unitOfWork.AgentRepository.Update(agent);

                _unitOfWork.Commit();

                var accountDto = _mapper.Map<AccountDto>(account);

                return accountDto;
            }   
        }

        public AddressDto AddressAdd(int agentId, CreateAddressDto createAddressDto)
        {
            using (_unitOfWork)
            {
                var agent = _unitOfWork.AgentRepository.GetByIdWithAddresses(agentId);

                NotFoundException.When(agent is null, $"{nameof(agent)} não foi encontrado.");

                var exists = false;

                if (agent.EntityLink is not null)
                {
                     exists = agent.EntityLink.Addresses.Any(address => address.Street == createAddressDto.Street &&
                              address.City == createAddressDto.City && address.Country == createAddressDto.Country &&
                              address.PostalCode == createAddressDto.PostalCode);
                }

                NotFoundException.When(exists, $"{nameof(agent)} Este endereço já existe.");

                var address = Address.Create(createAddressDto.Street, createAddressDto.City, createAddressDto.Country,
                        createAddressDto.PostalCode);

                if (agent.EntityLink is not null)
                {
                    agent.EntityLink.AddAddress(address);
                }
                else
                {
                    var entityLink = EntityLink.Create(EntityType.Employee, agent.Id);

                    entityLink.AddAddress(address);

                    agent.SetEntityLink(entityLink);

                }

                _unitOfWork.AgentRepository.Update(agent);

                _unitOfWork.Commit();

                var addressDto = _mapper.Map<AddressDto>(address);

                return addressDto;
            }
        }

        public ContactDto ContactAdd(int agentId, CreateContactDto createContactDto)
        {
            using (_unitOfWork) 
            {
                var agent = _unitOfWork.AgentRepository.GetByIdWithContacts(agentId);

                NotFoundException.When(agent is null, $"{nameof(agent)} não foi encontrado.");

                var existe = false;

                if (agent.EntityLink is not null)
                {
                    existe = agent.EntityLink.Contacts.Any( contact => 
                    contact.ContactType == createContactDto.ContactType && contact.Value == createContactDto.Value);
                }

                CustomApplicationException.When(existe,"Este contacto já existe.");

                var contact = Contact.Create(createContactDto.ContactType, createContactDto.Value);

                if (agent.EntityLink is not null)
                {
                    agent.EntityLink.AddContact(contact);
                }
                else
                {
                    var entityLink = EntityLink.Create(EntityType.Employee, agent.Id);

                    agent.SetEntityLink(entityLink);

                    entityLink.AddContact(contact);
                }

                _unitOfWork.AgentRepository.Update(agent);

                _unitOfWork.Commit();

                var contactDto = _mapper.Map<ContactDto>(contact);

                return contactDto;
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

                foundedAgent.Update(agentDto.Name.FirstName,agentDto.Name.MiddleNames,agentDto.Name.LastName,
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
    }
}
