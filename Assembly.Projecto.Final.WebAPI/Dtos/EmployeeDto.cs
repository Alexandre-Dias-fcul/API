using Assembly.Projecto.Final.Domain.Models;

namespace Assembly.Projecto.Final.WebAPI.Dtos
{
    public class EmployeeDto:PersonDto
    {
        public DateTime? HiredDate { get;  set; }
        public DateTime? DateOfTermination { get; set; }
        public EntityLinkDto EntityLink { get; set; } = new();
    }
}
