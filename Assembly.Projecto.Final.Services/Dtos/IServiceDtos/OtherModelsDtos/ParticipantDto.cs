using Assembly.Projecto.Final.Domain.Enums;
using Assembly.Projecto.Final.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Services.Dtos.IServiceDtos.OtherModelsDtos
{
    public class ParticipantDto
    {
        public int Id { get; set; }
        public ParticipantType Role { get; set; }
        public int AppointmentId { get; set; }
        public int EmployeeId { get; set; }
    }
}
