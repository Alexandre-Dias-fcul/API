using Assembly.Projecto.Final.Domain.Common;
using Assembly.Projecto.Final.Domain.Core.Repositories;
using Assembly.Projecto.Final.Domain.Enums;
using Assembly.Projecto.Final.Domain.Models;
using Assembly.Projecto.Final.Services.Dtos;
using Assembly.Projecto.Final.Services.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public AgentDto Add(AgentDto agentDto)
        {
            _unitOfWork.BeginTransaction();

            var name = Name.Create(agentDto.Name.FirstName, string.Join(" ",agentDto.Name.MiddleNames), agentDto.Name.LastName);

            var agent = Agent.Create(name, agentDto.DateOfBirth, agentDto.Gender, agentDto.PhotoFileName, agentDto.IsActive,
                         agentDto.HiredDate, agentDto.DateOfTermination, agentDto.Role);

            var entityLink = EntityLink.Create(EntityType.Employee, agent.Id);

            var account = Account.Create(agentDto.EntityLink.Account.Password, agentDto.EntityLink.Account.Email);

            entityLink.SetAccount(account);

            foreach (var contact in agentDto.EntityLink.Contacts)
            {
                var novoContacto = Contact.Create(contact.ContactType, contact.Value);

                entityLink.AddContact(novoContacto);

            }

            foreach (var address in agentDto.EntityLink.Addresses)
            {
                var novoAddress = Address.Create(address.Street, address.City, address.Country, address.PostalCode);

                entityLink.AddAddress(novoAddress);
            }

            agent.SetEntityLink(entityLink);

            if (agentDto.SupervisorId != null)
            {
                var supervisor = _unitOfWork.AgentRepository.GetById((int)agentDto.SupervisorId);

                if(supervisor == null) 
                {
                    throw new ArgumentNullException();
                }

                agent.SetSupervisor(supervisor);
            }

            Agent addedAgent;

            using (_unitOfWork) 
            {
                addedAgent=_unitOfWork.AgentRepository.Add(agent);

                _unitOfWork.Commit();
            }

            return _mapper.Map<AgentDto>(addedAgent);
        }

        public AgentDtoId Delete(AgentDtoId agentDtoId)
        {
            var agent = _mapper.Map<Agent>(agentDtoId);

            

            return _mapper.Map<AgentDtoId>(_unitOfWork.AgentRepository.Delete(agent));
        }

        public AgentDtoId? Delete(int id)
        {
            return _mapper.Map<AgentDtoId>(_unitOfWork.AgentRepository.Delete(id));
        }

        public List<AgentDtoId> GetAll()
        {
            return _mapper.Map<List<AgentDtoId>>(_unitOfWork.AgentRepository.GetAll());
        }

        public List<AgentDtoId> GetAllInclude()
        { 
            return _mapper.Map<List<AgentDtoId>>(_unitOfWork.AgentRepository.GetAllInclude());
        }

        public AgentListingDto? GetAllListingByEmployeeId(int idEmployee)
        { 

            return _mapper.Map<AgentListingDto>(_unitOfWork.AgentRepository.GetAllListingByEmployeeId(idEmployee));
        }

        public List<ManagerAgentDto> GetAllManagerAgents(int idManager)
        {
            var agents = _unitOfWork.AgentRepository.GetAllManagerAgents(idManager);

            var agentDtos = _mapper.Map<List<ManagerAgentDto>>(agents);

            return agentDtos;
        }

        public AgentDtoId? GetById(int id)
        {
            return _mapper.Map<AgentDtoId>(_unitOfWork.AgentRepository.GetById(id));
        }

        public AgentDtoId? GetByIdInclude(int id)
        {
            return _mapper.Map<AgentDtoId>(_unitOfWork.AgentRepository.GetById(id));
        }

        public void ManagerReassign(int idManager, int idAgent)
        {
            _unitOfWork.BeginTransaction();

            var manager = _unitOfWork.AgentRepository.GetById(idManager);

            var agent = _unitOfWork.AgentRepository.GetById(idAgent);

            if(manager == null || agent == null) 
            {
                throw new ArgumentNullException();
            }

            if(manager.Role != RoleType.Manager || agent.Role!= RoleType.Agent) 
            {
                throw new ArgumentException();
            }

            var agentWithListing = _unitOfWork.AgentRepository.GetAllListingByEmployeeId(agent.Id);

            var listings = agentWithListing.Listings.ToList();

            using (_unitOfWork)
            {
                foreach (var listing in listings)
                {
                    listing.SetAgent(manager);

                    _unitOfWork.ListingRepository.Update(listing);

                    var reassign = Reassign.Create(agent.Id, manager.Id, manager.Id, DateTime.Now);

                    reassign.SetListing(listing);

                    _unitOfWork.ReassignRepository.Add(reassign);
                }

                _unitOfWork.Commit();
            }
        }

        public AgentDtoId Update(AgentDtoId agentDtoId)
        {
            _unitOfWork.BeginTransaction();

            var agent = _unitOfWork.AgentRepository.GetByIdInclude(agentDtoId.Id);

            if(agent == null) 
            {
                throw new ArgumentNullException();
            }

            agent.Update(agentDtoId.Name.FirstName,string.Join(" ", agentDtoId.Name.MiddleNames),
                agentDtoId.Name.LastName,agentDtoId.DateOfBirth,agentDtoId.Gender,agentDtoId.PhotoFileName,
                agentDtoId.IsActive,agentDtoId.HiredDate,agentDtoId.DateOfTermination,agentDtoId.Role);

            if(agentDtoId.EntityLink != null && agent.EntityLink != null) 
            {
                if (agentDtoId.EntityLink.Account != null && agent.EntityLink.Account != null) 
                {
                    agent.EntityLink.Account.Update(agentDtoId.EntityLink.Account.Password,
                        agentDtoId.EntityLink.Account.Email);
                }

                if (agentDtoId.EntityLink.Addresses != null && agent.EntityLink.Addresses != null)
                {
                    foreach(var address in agentDtoId.EntityLink.Addresses) 
                    {
                        var addressUpdate = agent.EntityLink.Addresses.Where(e => e.Id == address.Id)
                            .FirstOrDefault();

                        if (addressUpdate == null) 
                        {
                            throw new ArgumentNullException();
                        }

                        addressUpdate.Update(address.Street,address.City,address.Country,address.PostalCode);
                    }
                }
                
                if(agentDtoId.EntityLink.Contacts != null && agent.EntityLink.Contacts != null) 
                {
                    foreach (var contact in agentDtoId.EntityLink.Contacts)
                    {
                        var contactUpdate = agent.EntityLink.Contacts.Where(c => c.Id == contact.Id)
                            .FirstOrDefault();

                        if(contactUpdate == null) 
                        {
                            throw new ArgumentNullException();
                        }

                        contactUpdate.Update(contact.ContactType,contact.Value);
                    }
                }
            }

            Agent updatedAgent;

            using (_unitOfWork) 
            {
                updatedAgent = _unitOfWork.AgentRepository.Update(agent);

                _unitOfWork.Commit();
            }

            return _mapper.Map<AgentDtoId>(updatedAgent);
        }
    }
}
