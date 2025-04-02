using Assembly.Projecto.Final.Domain.Core.Repositories;
using Assembly.Projecto.Final.Services.Dtos.GetDtos;
using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.EmployeeUserDtos;
using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.OtherModelsDtos;
using Assembly.Projecto.Final.Services.Interfaces;
using Assembly.Projecto.Final.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assembly.Projecto.Final.WebAPI.Controllers
{
    public class StaffController:BaseController
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService) 
        {
            _staffService = staffService;
        }

        [HttpGet]
        public IEnumerable<StaffDto> GetAll()
        {
            return _staffService.GetAll();
        }

        [HttpGet("{id:int}")]
        public ActionResult<StaffDto> GetById(int id)
        {
            return Ok(_staffService.GetById(id));
        }

        [HttpGet("GetByIdWithAll/{id:int}")]
        public ActionResult<AgentAllDto> GetByIdWithAll(int id)
        {
            return Ok(_staffService.GetByIdWithAll(id));
        }

        [HttpPost("AddAddress/{userId:int}")]
        public ActionResult<AddressDto> AddAdress(int userId, [FromBody] CreateAddressDto createAddressDto)
        {
            return Ok(_staffService.AddressAdd(userId, createAddressDto));
        }

        [HttpPost("AddContact/{userId:int}")]
        public ActionResult<ContactDto> AddContact(int userId, [FromBody] CreateContactDto createContactDto)
        {
            return Ok(_staffService.ContactAdd(userId, createContactDto));
        }

        [HttpPost("AddAccount/{userId:int}")]
        public ActionResult<AccountDto> AddAccount(int userId, [FromBody] CreateAccountDto createAccountDto)
        {
            return Ok(_staffService.AccountAdd(userId, createAccountDto));
        }

        [HttpPost]
        public ActionResult<StaffDto> Add([FromBody] CreateStaffDto createStaffDto)
        {
            return Ok(_staffService.Add(createStaffDto));
        }

        [HttpPut("{id:int}")]
        public ActionResult<StaffDto> Update([FromRoute] int id, [FromBody] StaffDto staffDto)
        {
            return Ok(_staffService.Update(staffDto));
        }

        [HttpDelete("{id:int}")]

        public ActionResult<StaffDto> Delete(int id)
        {
            return Ok(_staffService.Delete(id));
        }
    }
}
