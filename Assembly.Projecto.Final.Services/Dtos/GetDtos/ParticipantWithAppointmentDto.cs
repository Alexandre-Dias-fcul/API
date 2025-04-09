using Assembly.Projecto.Final.Domain.Enums;
using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.OtherModelsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Services.Dtos.GetDtos
{
    public class ParticipantWithAppointmentDto
    {
        public int Id { get; set; }
        public ParticipantType Role { get; set; }
        public int AppointmentId { get; set; }
        public int EmployeeId { get; set; }
        public AppointmentDto Appointment { get; set; } = new();
    }
}
