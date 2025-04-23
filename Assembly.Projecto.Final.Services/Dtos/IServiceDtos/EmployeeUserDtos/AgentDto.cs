using Assembly.Projecto.Final.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Services.Dtos.IServiceDtos.EmployeeUserDtos
{
    public class AgentDto:EmployeeDto
    {
        public RoleType Role { get; set; }
        public int? SupervisorId { get; set; }

    }
}
