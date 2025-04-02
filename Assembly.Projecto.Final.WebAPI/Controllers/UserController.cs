using Assembly.Projecto.Final.Services.Dtos.GetDtos;
using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.EmployeeUserDtos;
using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.OtherModelsDtos;
using Assembly.Projecto.Final.Services.Interfaces;
using Assembly.Projecto.Final.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assembly.Projecto.Final.WebAPI.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IEnumerable<UserDto> GetAll()
        {
            return _userService.GetAll();
        }

        [HttpGet("{id:int}")]
        public ActionResult<UserDto> GetById(int id) 
        {
            return Ok(_userService.GetById(id));
        }

        [HttpGet("GetByIdWithAll/{id:int}")]
        public ActionResult<UserAllDto> GetByIdWithAll(int id)
        {
            return Ok(_userService.GetByIdWithAll(id));
        }

        [HttpPost]

        public ActionResult<UserDto> Add(CreateUserDto createUserDto) 
        {
            try
            {
                var userDto =_userService.Add(createUserDto);

                return Ok(userDto);
            }
            catch(ArgumentNullException ex) 
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPost("AddAddress/{userId:int}")]
        public ActionResult<AddressDto> AddAdress(int userId, [FromBody] CreateAddressDto createAddressDto)
        {
            try 
            {
                var addressDto =_userService.AddressAdd(userId, createAddressDto);

                return Ok(addressDto);
            }
            catch(ArgumentNullException ex) 
            {
                return NotFound(new { message = ex.Message });
            }
            catch(InvalidOperationException ex) 
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("AddContact/{userId:int}")]
        public ActionResult<ContactDto> AddContact(int userId, [FromBody] CreateContactDto createContactDto)
        {
            try
            {
                var contactDto = _userService.ContactAdd(userId, createContactDto);

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
                var accountDto = _userService.AccountAdd(userId, createAccountDto);

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

        [HttpPut("{id:int}")]
        public ActionResult<UserDto> Update([FromRoute] int id, [FromBody] UserDto userDto) 
        {
            try 
            {
                var updatedUserDto = _userService.Update(userDto);

                return Ok(updatedUserDto);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            
        }

        [HttpDelete("{id:int}")]
        public ActionResult<UserDto> Delete(int id) 
        {
            try 
            {
                var deletedUserDto = _userService.Delete(id);

                return Ok(deletedUserDto);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
