﻿using Assembly.Projecto.Final.Domain.Models;
using Assembly.Projecto.Final.Services.Dtos;
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
    public interface IAgentService:IService<CreateAgentDto,AgentDto,int>
    {
        public ContactDto ContactAdd(int agentId, CreateContactDto createContactDto);
        public AddressDto AddressAdd(int agentId, CreateAddressDto createAddressDto);
        public AccountDto AccountAdd(int agentId, CreateAccountDto createAccountDto);
        public AccountDto AccountUpdate(int agentId, UpdateAccountDto updateAccountDto);
        public ContactDto ContactUpdate(int agentId, ContactDto contactDto);
        public AddressDto AddressUpdate(int agentId, AddressDto addressDto);
        public AgentAllDto GetByIdWithAll(int id);
        public AgentWithPersonalContactsDto GetByIdWithPersonalContacts(int id);
        public AgentWithParticipantsDto GetByIdWithParticipants(int id);

        public AgentWithListingsDto GetByIdWithListings(int id);
        public AgentWithAgentsDto? GetByIdWithAgents(int id);
    }
}
