using Assembly.Projecto.Final.Services.Dtos.GetDtos;
using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.EmployeeUserDtos;
using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.OtherModelsDtos;
using Assembly.Projecto.Final.Services.Interfaces;
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
            return Ok(_agentService.Add(createAgentDto));
        }

        [HttpPost("AddAddress/{userId:int}")]
        public ActionResult AddAdress(int userId,[FromBody] CreateAddressDto createAddressDto) 
        {
            _agentService.AddressAdd(userId, createAddressDto);

            return Ok();
        }

        [HttpPost("AddContact/{userId:int}")]
        public ActionResult AddContact(int userId, [FromBody] CreateContactDto createContactDto)
        {
            _agentService.ContactAdd(userId, createContactDto);

            return Ok();
        }

        [HttpPost("AddAccount/{userId:int}")]
        public ActionResult AddAccount(int userId, [FromBody] CreateAccountDto createAccountDto)
        {
            _agentService.AccountAdd(userId, createAccountDto);

            return Ok();
        }

        [HttpPut("{id:int}")]
        public ActionResult<AgentDto> Update([FromRoute] int id, [FromBody] AgentDto agentDto) 
        {
            return Ok(_agentService.Update(agentDto));
        }

        [HttpDelete("{id:int}")]

        public ActionResult<AgentDto> Delete(int id) 
        {
            return Ok(_agentService.Delete(id));
        }

    }
}
