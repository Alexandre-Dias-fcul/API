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
        public int AppointmentId { get; private set; }
        public Appointment Appointment { get; set; } 
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        private Participant() 
        {
            Role = 0;
        }

        private Participant(ParticipantType role):this()
        {
            Role = role;
        }

        private Participant(int id,ParticipantType role):this(role) 
        {
            Id = id;
        }

        private static Participant Created(ParticipantType role) 
        {
            var participant = new Participant(role);

            return participant;
        }

        private static Participant Created(int id,ParticipantType role)
        {
            var participant = new Participant(id,role);

            return participant;
        }

        private void Update(ParticipantType role) 
        {
            Role = role;
            Updated = DateTime.Now;
        }
    }
}
