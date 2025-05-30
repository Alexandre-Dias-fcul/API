﻿using Assembly.Projecto.Final.Domain.Models;
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
    public class EntityLinkMapping:Profile
    {
        public EntityLinkMapping() 
        {
            CreateMap<EntityLink, EntityLinkDto>().ReverseMap();
            CreateMap<EntityLink, CreateEntityLinkDto>().ReverseMap();

            //========================================================

            CreateMap<EntityLink, EntityLinkAllDto>()
            .ForMember(dest => dest.Contacts, opt => opt.MapFrom(src => src.Contacts))
            .ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => src.Addresses))
            .ForMember(dest => dest.Account, opt => opt.MapFrom(src => src.Account)).ReverseMap();

        }
    }
}
