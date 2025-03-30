using Assembly.Projecto.Final.Domain.Common;
using Assembly.Projecto.Final.Domain.Models;
using Assembly.Projecto.Final.Services.Dtos.GetDtos;
using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.EmployeeUserDtos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Services.Mappings
{
    public class AgentMapping:Profile
    {
        public AgentMapping() 
        {
            CreateMap<Name, NameDto>().ReverseMap();

            CreateMap<Person, PersonDto>().ReverseMap();

            CreateMap<Person, CreatePersonDto>().ReverseMap();

            CreateMap<Employee, EmployeeDto>()
               .IncludeBase<Person, PersonDto>() 
               .ReverseMap();

            CreateMap<Employee, CreateEmployeeDto>()
                .IncludeBase<Person, CreatePersonDto>()
                .ReverseMap();

            CreateMap<Agent, AgentDto>()
                 .IncludeBase<Employee, EmployeeDto>()
                 .ReverseMap();

            CreateMap<Agent, CreateAgentDto>()
                .IncludeBase<Employee, CreateEmployeeDto>()
                .ReverseMap();

            //==============================================

            CreateMap<Employee, EmployeeAllDto>()
              .IncludeBase<Person, PersonDto>()
              .ReverseMap();

            CreateMap<Agent, AgentAllDto>()
                 .IncludeBase<Employee, EmployeeAllDto>()
                 .ReverseMap();

        }
    }
}
