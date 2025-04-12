using Assembly.Projecto.Final.Services.Dtos.GetDtos;
using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.EmployeeUserDtos;
using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.OtherModelsDtos;
using Assembly.Projecto.Final.Services.Interfaces;
using Assembly.Projecto.Final.Services.Services;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Assembly.Projecto.Final.WebAPI.Controllers
{
    public class AgentController : BaseController
    {
        private readonly IAgentService _agentService;
        public AgentController(IAgentService agentService)
        {
            _agentService = agentService;
        }

        [HttpGet]
        public IEnumerable<AgentDto> GetAll()
        {
            return _agentService.GetAll();
        }

        [HttpGet("{id:int}")]
        public ActionResult<AgentDto> GetById(int id)
        {
            return Ok(_agentService.GetById(id));
        }

        [HttpGet("GetByIdWithAll/{id:int}")]
        public ActionResult<AgentAllDto> GetByIdWithAll(int id)
        {
            return Ok(_agentService.GetByIdWithAll(id));
        }

        [HttpGet("GetByIdWithPersonalContacs/{id:int}")]
        public ActionResult<AgentWithPersonalContactsDto> GetByIdWithPersonalContacts(int id) 
        {
            return Ok(_agentService.GetByIdWithPersonalContacts(id));
        }

        [HttpGet("GetByIdWithParticipants/{id:int}")]
        public ActionResult<AgentWithParticipantsDto> GetByIdWithParticipants(int id) 
        {
            return Ok(_agentService.GetByIdWithParticipants(id));
        }


        [HttpPost]
        public ActionResult<AgentDto> Add([FromBody] CreateAgentDto createAgentDto)
        {
            var agentDto = _agentService.Add(createAgentDto);

            return Ok(agentDto);
        }

        [HttpPost("AddAddress/{agentId:int}")]
        public ActionResult<AddressDto> AddAdress(int agentId, [FromBody] CreateAddressDto createAddressDto)
        {
            var addressDto = _agentService.AddressAdd(agentId, createAddressDto);

            return Ok(addressDto);
        }

        [HttpPost("AddContact/{agentId:int}")]
        public ActionResult<ContactDto> AddContact(int agentId, [FromBody] CreateContactDto createContactDto)
        {
            var contactDto = _agentService.ContactAdd(agentId, createContactDto);

            return Ok(contactDto);
        }

        [HttpPost("AddAccount/{agentId:int}")]
        public ActionResult<AccountDto> AddAccount(int agentId, [FromBody] CreateAccountDto createAccountDto)
        {
            var accountDto = _agentService.AccountAdd(agentId,createAccountDto);

            return accountDto;
        }

        [HttpPut("{id:int}")]
        public ActionResult<AgentDto> Update([FromRoute] int id, [FromBody] AgentDto agentDto)
        {
            if (id != agentDto.Id)
            {
                return BadRequest("Os ids do agent não coincidem.");
            }

            var updatedAgentDto = _agentService.Update(agentDto);

            return Ok(updatedAgentDto);
        }

        [HttpPut("UpdateAddress/{agentId:int}/{addressId:int}")]
        public ActionResult<AddressDto> UpdateAddress([FromRoute] int agentId,[FromRoute] int addressId, 
            [FromBody] AddressDto addressDto)
        {
            if(addressId != addressDto.Id) 
            {
                return BadRequest("Os ids do address não coincidem.");
            }

            var updatedAddressDto = _agentService.AddressUpdate(agentId, addressDto);

            return Ok(updatedAddressDto);
        }

        [HttpPut("UpdateContact/{agentId:int}/{contactId:int}")]
        public ActionResult<ContactDto> UpdateContact([FromRoute]int agentId, [FromRoute] int contactId,
            [FromBody] ContactDto contactDto)
        {
            if(contactId != contactDto.Id) 
            {
                return BadRequest("Os ids do contact não coincidem.");
            }

            var updatedContactDto = _agentService.ContactUpdate(agentId, contactDto);

            return Ok(updatedContactDto);
        }

        [HttpPut("UpdateAccount/{agentId:int}")]
        public ActionResult<AccountDto> UpdateAccount([FromRoute] int agentId, [FromBody] UpdateAccountDto updateAccountDto) 
        {
            var updatedAccount = _agentService.AccountUpdate(agentId, updateAccountDto);

            return updatedAccount;
        }
    }
}
