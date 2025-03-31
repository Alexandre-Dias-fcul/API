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
            return Ok(_userService.Add(createUserDto));
        }

        [HttpPost("AddAddress/{userId:int}")]
        public ActionResult AddAdress(int userId, [FromBody] CreateAddressDto createAddressDto)
        {
            _userService.AddressAdd(userId, createAddressDto);

            return Ok();
        }

        [HttpPost("AddContact/{userId:int}")]
        public ActionResult AddContact(int userId, [FromBody] CreateContactDto createContactDto)
        {
            _userService.ContactAdd(userId, createContactDto);

            return Ok();
        }

        [HttpPost("AddAccount/{userId:int}")]
        public ActionResult AddAccount(int userId, [FromBody] CreateAccountDto createAccountDto)
        {
            _userService.AccountAdd(userId, createAccountDto);

            return Ok();
        }

        [HttpPut("{id:int}")]
        public ActionResult<UserDto> Update([FromRoute] int id, [FromBody] UserDto userDto) 
        {
            return Ok(_userService.Update(userDto));
        }

        [HttpDelete("{id:int}")]
        public ActionResult<UserDto> Delete(int id) 
        {
            return Ok(_userService.Delete(id));
        }
    }
}
