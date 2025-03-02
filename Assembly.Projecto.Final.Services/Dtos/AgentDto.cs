using Assembly.Projecto.Final.Domain.Enums;



namespace Assembly.Projecto.Final.Services.Dtos
{
    public class AgentDto:EmployeeDto
    {
        public RoleType Role { get; set; }
        public int? SupervisorId { get; set; }
        
    }
}
