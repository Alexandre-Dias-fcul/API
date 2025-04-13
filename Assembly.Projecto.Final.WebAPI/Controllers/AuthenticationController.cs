using Assembly.Projecto.Final.Services.Dtos.OtherDtos;
using Assembly.Projecto.Final.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace Assembly.Projecto.Final.WebAPI.Controllers
{
    public class AuthenticationController:BaseController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("AuthenticationEmployee")]
        [AllowAnonymous]
        public ActionResult<string> AutenticationEmployee([FromBody] LoginDto loginDto ) 
        {
            return Ok(_authenticationService.AuthenticationEmployee(loginDto.Email,loginDto.Passoword));
        }

        [HttpPost("AuthenticationUser")]
        [AllowAnonymous]
        public ActionResult<string> AutenticationUser([FromBody] LoginDto loginDto)
        {
            return Ok(_authenticationService.AuthenticationUser(loginDto.Email, loginDto.Passoword));
        }
    }
}
