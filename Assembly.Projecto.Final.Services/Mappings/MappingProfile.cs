using Assembly.Projecto.Final.Domain.Common;
using Assembly.Projecto.Final.Domain.Models;
using Assembly.Projecto.Final.Services.Dtos;
using AutoMapper;

namespace Assembly.Projecto.Final.Services.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            // Mapeamento de Person para PersonDto
            CreateMap<Person, PersonDto>().ReverseMap();

            CreateMap<Name, NameDto>().ReverseMap();

            // Mapeamento de Employee para EmployeeDto, herdando o mapeamento de Person para PersonDto
            CreateMap<Employee, EmployeeDto>()
                .IncludeBase<Person, PersonDto>() // Garante que os campos de PersonDto sejam preenchidos
                .ReverseMap();

            // Mapeamento de Agent para AgentDto, herdando o mapeamento de Employee para EmployeeDto
            CreateMap<Agent, AgentDto>()
                 .IncludeBase<Employee, EmployeeDto>()
                 .ReverseMap();

            // Mapeamento de Address para AddressDto
            CreateMap<Address, AddressDto>().ReverseMap();

            // Mapeamento de Account para AccountDto
            CreateMap<Account, AccountDto>().ReverseMap();

            // Mapeamento de Contact para ContactDto
            CreateMap<Contact, ContactDto>().ReverseMap();

            // Mapeamento de EntityLink para EntityLinkDto
            CreateMap<EntityLink, EntityLinkDto>()
                .ForMember(dest => dest.Contacts, opt => opt.MapFrom(src => src.Contacts))
                .ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => src.Addresses))
                .ForMember(dest => dest.Account, opt => opt.MapFrom(src => src.Account))
                .ReverseMap();

            //================================================================

            CreateMap<Person, PersonDtoId>().ReverseMap();

            CreateMap<Employee, EmployeeDtoId>()
                .IncludeBase<Person, PersonDtoId>() 
                .ReverseMap();

            
            CreateMap<Agent, AgentDtoId>()
                 .IncludeBase<Employee, EmployeeDtoId>()
                 .ReverseMap();

            
            CreateMap<Address, AddressDtoId>().ReverseMap();


           
            CreateMap<Contact, ContactDtoId>().ReverseMap();

            
            CreateMap<EntityLink, EntityLinkDtoId>()
                .ForMember(dest => dest.Contacts, opt => opt.MapFrom(src => src.Contacts))
                .ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => src.Addresses))
                .ForMember(dest => dest.Account, opt => opt.MapFrom(src => src.Account))
                .ReverseMap();
        }
    }
}
