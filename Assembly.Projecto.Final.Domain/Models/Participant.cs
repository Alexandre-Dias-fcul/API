using Assembly.Projecto.Final.Domain.Common;
using Assembly.Projecto.Final.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Domain.Models
{
    public class Participant:AuditableEntity<int>
    {
        public ParticipantType Role { get; private set; }
        public Appointment Appointment { get; set; } 
        public Employee Employee { get; set; }
    }
}
