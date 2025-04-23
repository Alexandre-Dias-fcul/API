using Assembly.Projecto.Final.Domain.Enums;
using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.EmployeeUserDtos;
using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.OtherModelsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Services.Dtos.GetDtos
{
    public class AgentWithListingsDto:EmployeeDto
    {
        public RoleType Role { get; set; }
        public int? SupervisorId { get; set; }
        public List<ListingDto> Listings { get; set; }
    }
}
