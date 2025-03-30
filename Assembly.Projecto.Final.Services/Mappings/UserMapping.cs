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
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<User, UserDto>()
               .IncludeBase<Person, PersonDto>()
               .ReverseMap();

            CreateMap<User, CreateUserDto>()
                .IncludeBase<Person, CreatePersonDto>()
                .ReverseMap();

            CreateMap<User, UserAllDto>()
                 .IncludeBase<Person, PersonDto>()
                 .ReverseMap();
        }
    }
}
