using Assembly.Projecto.Final.Domain.Models;
using Assembly.Projecto.Final.Services.Dtos.GetDtos;
using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.OtherModelsDtos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Services.Mappings
{
    public class AppointmentMapping:Profile
    {
        public AppointmentMapping() 
        {
            CreateMap<Appointment, AppointmentDto>().ReverseMap();
            CreateMap<Appointment, CreateAppointmentDto>().ReverseMap();

            CreateMap<Appointment, AppointmentAllDto>()
             .ForMember(dest => dest.Participans, opt => opt.MapFrom(src => src.Participants))
             .ReverseMap();
        }
    }
}
