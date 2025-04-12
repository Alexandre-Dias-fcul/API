﻿using Assembly.Projecto.Final.Domain.Models;
using Assembly.Projecto.Final.Services.Dtos.GetDtos;
using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.EmployeeUserDtos;
using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.OtherModelsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Services.Interfaces
{
    public interface IStaffService:IService<CreateStaffDto,StaffDto,int>
    {
        public ContactDto ContactAdd(int staffId, CreateContactDto createContactDto);
        public AddressDto AddressAdd(int staffId, CreateAddressDto createAddressDto);
        public AccountDto AccountAdd(int staffId, CreateAccountDto createAccountDto);
        public AccountDto AccountUpdate(int staffId, UpdateAccountDto UpdateAccountDto);
        public ContactDto ContactUpdate(int staffId, ContactDto contactDto);
        public AddressDto AddressUpdate(int staffId, AddressDto addressDto);
        public StaffAllDto GetByIdWithAll(int id);
        public StaffWithPersonalContactsDto GetByIdWithPersonalContacts(int id);
        public StaffWithParticipantsDto GetByIdWithParticipants(int id);
    }
}
