using Assembly.Projecto.Final.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Services.Dtos.IServiceDtos.OtherModelsDtos
{
    public class CreateAppointmentDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public TimeOnly HourStart { get; set; }
        public TimeOnly HourEnd { get; set; }
        public StatusType Status { get; set; }
        public RoleType? Role { get; set; }
        public int EmployeeId { get; set; }
    }
}
