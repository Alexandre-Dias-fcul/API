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
    public class ParticipantMapping : Profile
    {
        public ParticipantMapping()
        {
            CreateMap<Participant, ParticipantDto>().ReverseMap();
            CreateMap<Participant, CreateParticipantDto>().ReverseMap();
        }
    }
}
