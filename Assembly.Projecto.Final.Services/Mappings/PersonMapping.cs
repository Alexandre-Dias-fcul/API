using Assembly.Projecto.Final.Domain.Common;
using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.EmployeeUserDtos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Services.Mappings
{
    class PersonMapping : Profile
    {
        public PersonMapping()
        {
            CreateMap<Name, NameDto>().ReverseMap();

            CreateMap<Person, PersonDto>().ReverseMap();

            CreateMap<Person, CreatePersonDto>().ReverseMap();
        }
    }
}
