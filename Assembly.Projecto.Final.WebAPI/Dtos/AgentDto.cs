using Assembly.Projecto.Final.Domain.Enums;
using Assembly.Projecto.Final.Domain.Models;

namespace Assembly.Projecto.Final.WebAPI.Dtos
{
    public class AgentDto:EmployeeDto
    {
        public RoleType Role { get; set; }
        public int? SupervisorId { get; set; }
        
    }
}
