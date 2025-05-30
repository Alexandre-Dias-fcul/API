﻿using Assembly.Projecto.Final.Services.Dtos.GetDtos;
using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.OtherModelsDtos;
using Assembly.Projecto.Final.Services.Interfaces;
using Assembly.Projecto.Final.WebAPI.Extensions;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "Staff,Agent,Manager,Broker,Admin")]
        [HttpGet]
        public IEnumerable<PersonalContactDto> GetAll() 
        {
            return _personalContactService.GetAll();
        }

        [Authorize(Roles = "Staff,Agent,Manager,Broker,Admin")]
        [HttpGet("{id:int}")]
        public ActionResult<PersonalContactDto> GetById(int id) 
        {
            return Ok(_personalContactService.GetById(id));
        }

        [Authorize(Roles = "Staff,Agent,Manager,Broker,Admin")]
        [HttpGet("GetByIdWithDetail/{id:int}")]
        public ActionResult<PersonalContactAllDto> GetByIdWithDetail(int id) 
        {
            return Ok(_personalContactService.GetByIdWithDetail(id));
        }

        [Authorize(Roles = "Staff,Agent,Manager,Broker,Admin")]
        [HttpPost]
        public ActionResult<PersonalContactDto> Add([FromBody]CreatePersonalContactDto createPersonalContactDto) 
        {
            string? id = User.GetId();

            if(id == null) 
            {
                return BadRequest("Não está autenticado como empregado.");
            }

            int employeeId = int.Parse(id);

            string? role = User.GetRole();

            if(role == null) 
            {
                return BadRequest("Não está autenticado como empregado.");
            }

            bool isStaff = false;

            if(role == "Staff") 
            {
                isStaff = true;
            }

            CreatePersonalContactServiceDto createPersonalContactServiceDto = new()
            {
                Name = createPersonalContactDto.Name,
                IsPrimary = createPersonalContactDto.IsPrimary,
                Notes = createPersonalContactDto.Notes,
                IsStaff = isStaff,
                EmployeeId = employeeId
            };
            
            return Ok(_personalContactService.Add(createPersonalContactServiceDto));
        }

        [Authorize(Roles = "Staff,Agent,Manager,Broker,Admin")]
        [HttpPost("{personalContactId:int}")]
        public ActionResult<PersonalContactDetailDto> AddDetail([FromRoute]int personalContactId,
            [FromBody] CreatePersonalContactDetailDto createPersonalContactDetailDto) 
        {
            return Ok(_personalContactService.AddDetail(personalContactId, createPersonalContactDetailDto));
        }

        [Authorize(Roles = "Staff,Agent,Manager,Broker,Admin")]
        [HttpPut("AddDetail/{personalContactId:int}/{personalContactDetailId:int}")]
        public ActionResult<PersonalContactDetailDto> UpdateDetail([FromRoute] int personalContactId,
            [FromRoute] int personalContactDetailId, [FromBody] PersonalContactDetailDto personalContactDetailDto)
         
        {
            if(personalContactDetailId != personalContactDetailDto.Id) 
            {
                return BadRequest("Os ids do PersonalContactDetail não coincidem.");
            }

            return Ok(_personalContactService.UpdateDetail(personalContactId, personalContactDetailDto));
        }

        [Authorize(Roles = "Staff,Agent,Manager,Broker,Admin")]
        [HttpDelete("DeleteDetail/{personalContactId:int}/{personalContactDetailId:int}")]
        public ActionResult<PersonalContactDetailDto> DeleteDetail([FromRoute] int personalContactId,
            [FromRoute] int personalContactDetailId)
        {
            return Ok(_personalContactService.DeleteDetail(personalContactId, personalContactDetailId));
        }

        [Authorize(Roles = "Staff,Agent,Manager,Broker,Admin")]
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

        [Authorize(Roles = "Staff,Agent,Manager,Broker,Admin")]
        [HttpDelete]
        public ActionResult<PersonalContactDto> Delete(PersonalContactDto personalContactDto) 
        {
            return Ok(_personalContactService.Delete(personalContactDto));
        }

        [Authorize(Roles = "Staff,Agent,Manager,Broker,Admin")]
        [HttpDelete("{id:int}")]
        public ActionResult<PersonalContactDto> Delete(int id) 
        {
            return Ok(_personalContactService.Delete(id));
        }
    }
}
