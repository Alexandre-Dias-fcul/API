using Assembly.Projecto.Final.Domain.Common;
using Assembly.Projecto.Final.Domain.Enums;
using Assembly.Projecto.Final.Domain.Models;
using Assembly.Projecto.Final.Services.Dtos;
using Assembly.Projecto.Final.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assembly.Projecto.Final.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private readonly IAgentService _agentService;
        public AgentController(IAgentService agentService) 
        {
            _agentService = agentService;
        }

        [HttpGet]
        public ActionResult<List<AgentDto>> GetAll() 
        {
            var agents = _agentService.GetAllInclude();

            return Ok(agents);
        }

        [HttpPost]

        public ActionResult<AgentDto> Create([FromBody] AgentDto agentDto)  
        {
            var name = Name.Create(agentDto.Name.FirstName, agentDto.Name.MiddleNames.ToString(), agentDto.Name.LastName);

            var agent = Agent.Create(name,agentDto.DateOfBirth,agentDto.Gender,agentDto.PhotoFileName,agentDto.IsActive,
                         agentDto.HiredDate,agentDto.DateOfTermination,agentDto.Role);

            var entityLink = EntityLink.Create(EntityType.Employee,agent.Id);

            var account = Account.Create(agentDto.EntityLink.Account.Password,agentDto.EntityLink.Account.Email);

            entityLink.SetAccount(account);

            foreach(var contact in agentDto.EntityLink.Contacts) 
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

            _agentService.Add(agent);

            return Ok(agentDto);
        }
    }
}
