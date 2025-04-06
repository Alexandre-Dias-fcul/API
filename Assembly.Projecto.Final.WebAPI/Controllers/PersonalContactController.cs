using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.OtherModelsDtos;
using Assembly.Projecto.Final.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Assembly.Projecto.Final.WebAPI.Controllers
{
    public class PersonalContactController:BaseController
    {
        private readonly IPersonalContactService _personalContactService;

        public PersonalContactController(IPersonalContactService personalContactService)
        {
            _personalContactService = personalContactService;
        }

        [HttpGet]
        public IEnumerable<PersonalContactDto> GetAll() 
        {
            return _personalContactService.GetAll();
        }

        [HttpGet("{id:int}")]
        public ActionResult<PersonalContactDto> GetById(int id) 
        {
            return Ok(_personalContactService.GetById(id));
        }

        [HttpPost]
        public ActionResult<PersonalContactDto> Add([FromBody]CreatePersonalContactDto personalContactDto) 
        {
            return Ok(_personalContactService.Add(personalContactDto));
        }

        [HttpPut("{id:int}")]
        public ActionResult<PersonalContactDto> Update([FromRoute] int id, 
            [FromBody] PersonalContactDto personalContactDto) 
        {
            if (id != personalContactDto.Id) 
            {
                return BadRequest("Os ids do personalContact não coincidem.");
            }

            return Ok(_personalContactService.Update(personalContactDto));
        }
    }
}
