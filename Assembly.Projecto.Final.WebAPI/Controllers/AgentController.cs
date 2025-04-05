using Assembly.Projecto.Final.Services.Dtos.GetDtos;
using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.EmployeeUserDtos;
using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.OtherModelsDtos;
using Assembly.Projecto.Final.Services.Interfaces;
using Assembly.Projecto.Final.Services.Services;
using Microsoft.AspNetCore.Mvc;

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
       

        [HttpPost]
        public ActionResult<AgentDto> Add([FromBody] CreateAgentDto createAgentDto) 
        {
            var agentDto = _agentService.Add(createAgentDto);

            return Ok(agentDto);
        }

        [HttpPost("AddAddress/{userId:int}")]
        public ActionResult<AddressDto> AddAdress(int userId,[FromBody] CreateAddressDto createAddressDto) 
        {
            var addressDto = _agentService.AddressAdd(userId, createAddressDto);

            return Ok(addressDto);
        }

        [HttpPost("AddContact/{userId:int}")]
        public ActionResult<ContactDto> AddContact(int userId, [FromBody] CreateContactDto createContactDto)
        {
            var contactDto = _agentService.ContactAdd(userId, createContactDto);

            return Ok(contactDto);
        }

        [HttpPost("AddAccount/{userId:int}")]
        public ActionResult<AccountDto> AddAccount(int userId, [FromBody] CreateAccountDto createAccountDto)
        {
            var accountDto = _agentService.AccountAdd(userId, createAccountDto);

            return accountDto;
        }

        [HttpPut("{id:int}")]
        public ActionResult<AgentDto> Update([FromRoute] int id, [FromBody] AgentDto agentDto) 
        {
            var updatedAgentDto = _agentService.Update(agentDto);

            return Ok(updatedAgentDto);
        }
    }
}
