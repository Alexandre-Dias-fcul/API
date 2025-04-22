using Assembly.Projecto.Final.Domain.Enums;
using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.EmployeeUserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Services.Dtos.GetDtos
{
    public class AgentWithAgentsDto:EmployeeDto
    {
        public RoleType Role { get; set; }
        public int? SupervisorId { get; set; }
        public List<AgentDto> Agents { get; set; }
    }

}
