using Assembly.Projecto.Final.Domain.Models;
using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.OtherModelsDtos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Services.Mappings
{
    class PersonalContactMapping : Profile
    {
        public PersonalContactMapping()
        {
            CreateMap<PersonalContact, PersonalContactDto>().ReverseMap();
            CreateMap<PersonalContact, CreatePersonalContactDto>().ReverseMap();
        }
    }
}
