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
        private readonly IAgentRepository _agentRepository;

        private readonly IListingRepository _listingRepository;

        private readonly IReassignRepository _reassignRepository;

        private readonly IMapper _mapper;
        public AgentService(IAgentRepository agentRepository,IListingRepository listingRepository,IReassignRepository reassignRepository, IMapper mapper) 
        { 
            _agentRepository = agentRepository;
            _listingRepository = listingRepository;
            _reassignRepository = reassignRepository;
            _mapper = mapper;
        }
        public AgentDto Add(AgentDto agentDto)
        {
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
                var supervisor = _agentRepository.GetById((int)agentDto.SupervisorId);

                if(supervisor == null) 
                {
                    throw new ArgumentNullException();
                }

                agent.SetSupervisor(supervisor);
            }

            return _mapper.Map<AgentDto>(_agentRepository.Add(agent));
        }

        public AgentDtoId Delete(AgentDtoId agentDtoId)
        {
            var agent = _mapper.Map<Agent>(agentDtoId);

            

            return _mapper.Map<AgentDtoId>(_agentRepository.Delete(agent));
        }

        public AgentDtoId? Delete(int id)
        {
            return _mapper.Map<AgentDtoId>(_agentRepository.Delete(id));
        }

        public List<AgentDtoId> GetAll()
        {
            return _mapper.Map<List<AgentDtoId>>(_agentRepository.GetAll());
        }

        public List<AgentDtoId> GetAllInclude()
        { 
            return _mapper.Map<List<AgentDtoId>>(_agentRepository.GetAllInclude());
        }

        public AgentListingDto? GetAllListingByEmployeeId(int idEmployee)
        { 

            return _mapper.Map<AgentListingDto>(_agentRepository.GetAllListingByEmployeeId(idEmployee));
        }

        public List<ManagerAgentDto> GetAllManagerAgents(int idManager)
        {
            var agents = _agentRepository.GetAllManagerAgents(idManager);

            var agentDtos = _mapper.Map<List<ManagerAgentDto>>(agents);

            return agentDtos;
        }

        public AgentDtoId? GetById(int id)
        {
            return _mapper.Map<AgentDtoId>(_agentRepository.GetById(id));
        }

        public AgentDtoId? GetByIdInclude(int id)
        {
            return _mapper.Map<AgentDtoId>(_agentRepository.GetById(id));
        }

        public void ManagerReassign(int idManager, int idAgent)
        {
            var manager = _agentRepository.GetById(idManager);

            var agent = _agentRepository.GetById(idAgent);

            if(manager == null || agent == null) 
            {
                throw new ArgumentNullException();
            }

            if(manager.Role != RoleType.Manager || agent.Role!= RoleType.Agent) 
            {
                throw new ArgumentException();
            }

            var agentWithListing = _agentRepository.GetAllListingByEmployeeId(agent.Id);

            var listings = agentWithListing.Listings.ToList();

            foreach (var listing in listings) 
            {
                listing.SetAgent(manager);

                _listingRepository.Update(listing);

                var reassign = Reassign.Create(agent.Id, manager.Id, manager.Id, DateTime.Now);

                reassign.SetListing(listing);

                _reassignRepository.Add(reassign);
            }
            
        }

        public AgentDtoId Update(AgentDtoId agentDtoId)
        {
            var agent = _agentRepository.GetByIdInclude(agentDtoId.Id);

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
                        var addressAlterar = agent.EntityLink.Addresses.Where(e => e.Id == address.Id)
                            .FirstOrDefault();

                        if (addressAlterar == null) 
                        {
                            throw new ArgumentNullException();
                        }

                        addressAlterar.Update(address.Street,address.City,address.Country,address.PostalCode);
                    }
                }
                
                if(agentDtoId.EntityLink.Contacts != null && agent.EntityLink.Contacts != null) 
                {
                    foreach (var contact in agentDtoId.EntityLink.Contacts)
                    {
                        var contactAlterar = agent.EntityLink.Contacts.Where(c => c.Id == contact.Id)
                            .FirstOrDefault();

                        if(contactAlterar == null) 
                        {
                            throw new ArgumentNullException();
                        }

                        contactAlterar.Update(contact.ContactType,contact.Value);
                    }
                }
            }

            return _mapper.Map<AgentDtoId>(_agentRepository.Update(agent));
        }
    }
}
