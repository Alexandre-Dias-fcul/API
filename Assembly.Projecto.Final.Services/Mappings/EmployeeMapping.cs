using Assembly.Projecto.Final.Domain.Common;
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
    public class EmployeeMapping : Profile
    {
        public EmployeeMapping()
        {
            CreateMap<Employee, EmployeeDto>()
              .IncludeBase<Person, PersonDto>()
              .ReverseMap();

            CreateMap<Employee, CreateEmployeeDto>()
                .IncludeBase<Person, CreatePersonDto>()
                .ReverseMap();

            CreateMap<Employee, EmployeeAllDto>()
              .IncludeBase<Person, PersonDto>()
              .ReverseMap();
        }
    }
}
