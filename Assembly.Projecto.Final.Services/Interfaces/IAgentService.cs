using Assembly.Projecto.Final.Domain.Models;
using Assembly.Projecto.Final.Services.Dtos;
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
        public void AgentContactAdd(int userId, CreateContactDto createContactDto);
        public void AgentAddressAdd(int userId, CreateAddressDto createAddressDto);
        public void AgentAccountAdd(int userId, CreateAccountDto createAccountDto);
      
    }
}
