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

        private readonly IMapper _mapper;
        public AgentService(IAgentRepository agentRepository,IMapper mapper) 
        { 
            _agentRepository = agentRepository;
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

            _agentRepository.Add(agent);

            return agentDto;
        }

        public AgentDtoId Delete(AgentDtoId agentDtoId)
        {
            var agent = _mapper.Map<Agent>(agentDtoId);

            var agentApagado = _agentRepository.Delete(agent);

            var agentDtoIdApagado = _mapper.Map<AgentDtoId>(agentApagado);

            return agentDtoIdApagado;
        }

        public AgentDtoId? Delete(int id)
        {
            var agent = _agentRepository.Delete(id);

            var agentDtoId = _mapper.Map<AgentDtoId>(agent);

            return agentDtoId;
        }

        public List<AgentDtoId> GetAll()
        {
            var agents =_agentRepository.GetAll();

            var agentDtosId = _mapper.Map<List<AgentDtoId>>(agents);

            return agentDtosId;
        }

        public List<AgentDtoId> GetAllInclude()
        {
            var agents = _agentRepository.GetAllInclude();

            var agentDtosId = _mapper.Map<List<AgentDtoId>>(agents);

            return agentDtosId;
        }

        public List<ManagerAgentDto> GetAllManagerAgents(int idManager)
        {
            var agents = _agentRepository.GetAllManagerAgents(idManager);

            var agentDtos = _mapper.Map<List<ManagerAgentDto>>(agents);

            return agentDtos;
        }

        public AgentDtoId? GetById(int id)
        {
            var agent = _agentRepository.GetById(id);

            var agentDtoId = _mapper.Map<AgentDtoId>(agent);

            return agentDtoId;
        }

        public AgentDtoId? GetByIdInclude(int id)
        {
            var agent = _agentRepository.GetById(id);

            var agentDtoId = _mapper.Map<AgentDtoId>(agent);

            return agentDtoId;
        }

        public AgentDtoId Update(AgentDtoId agentDtoId)
        {
            var agentAlterar = _agentRepository.GetByIdInclude(agentDtoId.Id);

            if(agentAlterar == null) 
            {
                throw new ArgumentNullException();
            }

            agentAlterar.Update(agentDtoId.Name.FirstName,string.Join(" ", agentDtoId.Name.MiddleNames),
                agentDtoId.Name.LastName,agentDtoId.DateOfBirth,agentDtoId.Gender,agentDtoId.PhotoFileName,
                agentDtoId.IsActive,agentDtoId.HiredDate,agentDtoId.DateOfTermination,agentDtoId.Role);

            if(agentDtoId.EntityLink != null && agentAlterar.EntityLink != null) 
            {
                if (agentDtoId.EntityLink.Account != null && agentAlterar.EntityLink.Account != null) 
                {
                    agentAlterar.EntityLink.Account.Update(agentDtoId.EntityLink.Account.Password,
                        agentDtoId.EntityLink.Account.Email);
                }

                if (agentDtoId.EntityLink.Addresses != null && agentAlterar.EntityLink.Addresses != null)
                {
                    foreach(var address in agentDtoId.EntityLink.Addresses) 
                    {
                        var addressAlterar = agentAlterar.EntityLink.Addresses.Where(e => e.Id == address.Id)
                            .FirstOrDefault();

                        if (addressAlterar == null) 
                        {
                            throw new ArgumentNullException();
                        }

                        addressAlterar.Update(address.Street,address.City,address.Country,address.PostalCode);
                    }
                }
                
                if(agentDtoId.EntityLink.Contacts != null && agentAlterar.EntityLink.Contacts != null) 
                {
                    foreach (var contact in agentDtoId.EntityLink.Contacts)
                    {
                        var contactAlterar = agentAlterar.EntityLink.Contacts.Where(c => c.Id == contact.Id)
                            .FirstOrDefault();

                        if(contactAlterar == null) 
                        {
                            throw new ArgumentNullException();
                        }

                        contactAlterar.Update(contact.ContactType,contact.Value);
                    }
                }
            }

            var agentAlterado = _agentRepository.Update(agentAlterar);

            var agentDtoIdAlterado = _mapper.Map<AgentDtoId>(agentAlterado);

            return agentDtoIdAlterado;
        }
    }
}
