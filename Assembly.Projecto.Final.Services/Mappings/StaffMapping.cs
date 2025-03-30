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
    public class StaffMapping : Profile
    {
         public StaffMapping()
        {
            CreateMap<Staff, StaffDto>()
                 .IncludeBase<Employee, EmployeeDto>()
                 .ReverseMap();

            CreateMap<Staff, CreateStaffDto>()
                .IncludeBase<Employee, CreateEmployeeDto>()
                .ReverseMap();

            CreateMap<Staff, StaffAllDto>()
               .IncludeBase<Employee, EmployeeAllDto>()
               .ReverseMap();
        }
    }
}
