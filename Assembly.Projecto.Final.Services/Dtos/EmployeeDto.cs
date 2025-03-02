

namespace Assembly.Projecto.Final.Services.Dtos
{
    public class EmployeeDto:PersonDto
    {
        public DateTime? HiredDate { get;  set; }
        public DateTime? DateOfTermination { get; set; }
        public EntityLinkDto EntityLink { get; set; } = new();
    }
}
