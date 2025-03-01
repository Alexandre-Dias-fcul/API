using Assembly.Projecto.Final.Domain.Common;
using Assembly.Projecto.Final.Domain.Enums;
using Assembly.Projecto.Final.Domain.Models;
using Assembly.Projecto.Final.Services.Interfaces;
using Assembly.Projecto.Final.WebAPI.Dtos;
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
        private readonly IMapper _mapper;

        public AgentController(IAgentService agentService,IMapper mapper) 
        {
            _agentService = agentService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<AgentDto>> GetAll() 
        {
            var agents = _agentService.GetAllInclude();

            /*var agentDtos = new List<AgentDto>();

            var agentDto = new AgentDto();

            foreach (var agent in agents) 
            {
                agentDto.Name = new NameDto();
                agentDto.Name.FirstName = agent.Name.FirstName;
                agentDto.Name.MiddleNames = agent.Name.MiddleNames.ToString();
                agentDto.Name.LastName = agent.Name.LastName;
                agentDto.DateOfBirth = agent.DateOfBirth;
                agentDto.PhotoFileName = agent.PhotoFileName;
                agentDto.IsActive = agent.IsActive;
                agentDto.HiredDate = agent.HiredDate;
                agentDto.DateOfTermination = agent.DateOfTermination;
                agentDto.Role = (RoleType)agent.Role;
                agentDto.EntityLink = new EntityLinkDto();
                agentDto.EntityLink.Contacts = new List<ContactDto>();

                foreach(var contact in agent.EntityLink.Contacts) 
                {
                    var contactDto = new ContactDto();
                    contactDto.ContactType = (ContactType)contact.ContactType;
                    contactDto.Value = contact.Value;

                    agentDto.EntityLink.Contacts.Add(contactDto);
                }


                agentDto.EntityLink.Addresses = new List<AddressDto>();

                foreach (var address in agent.EntityLink.Addresses) 
                {
                    var addressDto = new AddressDto();

                    addressDto.Street = address.Street;
                    addressDto.City = address.City;
                    addressDto.Country = address.Country;
                    addressDto.PostalCode = address.PostalCode;

                    agentDto.EntityLink.Addresses.Add(addressDto);
                }

                agentDtos.Add(agentDto);
                
            }*/

            var agentDtos =_mapper.Map<List<AgentDto>>(agents);

            return Ok(agentDtos);
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
