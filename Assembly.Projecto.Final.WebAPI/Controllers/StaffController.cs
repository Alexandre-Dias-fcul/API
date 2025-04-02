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
            try
            {
                var addressDto = _staffService.AddressAdd(userId, createAddressDto);

                return Ok(addressDto);

            }
            catch (ArgumentNullException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("AddContact/{userId:int}")]
        public ActionResult<ContactDto> AddContact(int userId, [FromBody] CreateContactDto createContactDto)
        {
            try
            {
                var contactDto = _staffService.ContactAdd(userId, createContactDto);

                return Ok(contactDto);

            }
            catch (ArgumentNullException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("AddAccount/{userId:int}")]
        public ActionResult<AccountDto> AddAccount(int userId, [FromBody] CreateAccountDto createAccountDto)
        {
            try
            {
                var accountDto = _staffService.AccountAdd(userId, createAccountDto);

                return Ok(accountDto);

            }
            catch (ArgumentNullException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult<StaffDto> Add([FromBody] CreateStaffDto createStaffDto)
        {
            try
            {
                var staffDto =_staffService.Add(createStaffDto);

                return Ok(staffDto);
            } 
            catch (ArgumentNullException ex) 
            {
                return NotFound(new { message = ex.Message });
            } 
        }

        [HttpPut("{id:int}")]
        public ActionResult<StaffDto> Update([FromRoute] int id, [FromBody] StaffDto staffDto)
        {
            try
            {
                var updatedStaffDto =_staffService.Update(staffDto);

                return Ok(updatedStaffDto);

            }
            catch(ArgumentNullException ex) 
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult<StaffDto> Delete(int id)
        {
            try 
            {
                var deletedStaff = _staffService.Delete(id);

                return Ok(deletedStaff);
            }
            catch(ArgumentNullException ex) 
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
