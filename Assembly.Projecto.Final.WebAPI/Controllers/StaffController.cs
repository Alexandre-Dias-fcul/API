﻿using Assembly.Projecto.Final.Domain.Core.Repositories;
using Assembly.Projecto.Final.Services.Dtos.GetDtos;
using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.EmployeeUserDtos;
using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.OtherModelsDtos;
using Assembly.Projecto.Final.Services.Interfaces;
using Assembly.Projecto.Final.Services.Services;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("GetByIdWithPersonalContacs/{id:int}")]
        public ActionResult<StaffWithPersonalContactsDto> GetByIdWithPersonalContacts(int id)
        {
            return Ok(_staffService.GetByIdWithPersonalContacts(id));
        }

        [HttpGet("GetByIdWithParticipants/{id:int}")]
        public ActionResult<StaffWithParticipantsDto> GetByIdWithParticipants(int id)
        {
            return Ok(_staffService.GetByIdWithParticipants(id));
        }

        [HttpPost("AddAddress/{staffId:int}")]
        public ActionResult<AddressDto> AddAdress(int staffId, [FromBody] CreateAddressDto createAddressDto)
        {
            var addressDto = _staffService.AddressAdd(staffId, createAddressDto);

            return Ok(addressDto);
        }

        [HttpPost("AddContact/{staffId:int}")]
        public ActionResult<ContactDto> AddContact(int staffId, [FromBody] CreateContactDto createContactDto)
        {
            var contactDto = _staffService.ContactAdd(staffId, createContactDto);

            return Ok(contactDto);
        }

        [HttpPost("AddAccount/{staffId:int}")]
        [AllowAnonymous]
        public ActionResult<AccountDto> AddAccount(int staffId, [FromBody] CreateAccountDto createAccountDto)
        {
            var accountDto = _staffService.AccountAdd(staffId, createAccountDto);

            return Ok(accountDto);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult<StaffDto> Add([FromBody] CreateStaffDto createStaffDto)
        {
            var staffDto = _staffService.Add(createStaffDto);

            return Ok(staffDto);
        }

        [HttpPut("{id:int}")]
        public ActionResult<StaffDto> Update([FromRoute] int id, [FromBody] StaffDto staffDto)
        {
            if(id != staffDto.Id) 
            {
                return BadRequest("Os ids do staff não coincidem.");
            }

            var updatedStaffDto = _staffService.Update(staffDto);

            return Ok(updatedStaffDto);
        }

        [HttpPut("UpdateAddress/{staffId:int}/{addressId:int}")]
        public ActionResult<AddressDto> UpdateAddress([FromRoute] int staffId, [FromRoute] int addressId,
           [FromBody] AddressDto addressDto)
        {
            if (addressId != addressDto.Id)
            {
                return BadRequest("Os ids do address não coincidem.");
            }

            var updatedAddressDto = _staffService.AddressUpdate(staffId, addressDto);

            return Ok(updatedAddressDto);
        }

        [HttpPut("UpdateContact/{staffId:int}/{contactId:int}")]
        public ActionResult<ContactDto> UpdateContact([FromRoute] int staffId, [FromRoute] int contactId,
            [FromBody] ContactDto contactDto)
        {
            if (contactId != contactDto.Id)
            {
                return BadRequest("Os ids do contact não coincidem.");
            }

            var updatedContactDto = _staffService.ContactUpdate(staffId, contactDto);

            return Ok(updatedContactDto);
        }

        [HttpPut("UpdateAccount/{staffId:int}")]
        public ActionResult<AccountDto> UpdateAccount([FromRoute] int staffId, [FromBody] UpdateAccountDto updateAccountDto)
        {
            var updatedAccount = _staffService.AccountUpdate(staffId, updateAccountDto);

            return updatedAccount;
        }
    }
}
