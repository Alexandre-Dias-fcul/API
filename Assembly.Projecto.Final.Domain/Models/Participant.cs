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
        public Appointment Appointment { get; private set; } 
        public int EmployeeId { get; private set; }
        public Employee Employee { get; private set; }

        private Participant() 
        {
            Role = 0;
        }

        private Participant(ParticipantType role, Appointment appointment, Employee employee) :this()
        {
            Role = role;

            if(appointment == null || employee == null) 
            {
                throw new ArgumentNullException();    
            }

            Appointment = appointment;
            AppointmentId = appointment.Id;
            Employee = employee;
            EmployeeId = employee.Id;
        }

        private Participant(int id,ParticipantType role, Appointment appointment, Employee employee) 
            :this(role,appointment, employee) 
        {
            Id = id;
        }

        private static Participant Created(ParticipantType role, Appointment appointment, 
            Employee employee) 
        {
            var participant = new Participant(role, appointment, employee);

            return participant;
        }

        private static Participant Created(int id,ParticipantType role, Appointment appointment,Employee employee)
        {
            var participant = new Participant(id,role, appointment, employee);

            return participant;
        }

        private void Update(ParticipantType role, Appointment appointment,Employee employee) 
        {
            Role = role;
            Updated = DateTime.Now;

            if (appointment ==null || employee == null) 
            { 
                throw new ArgumentNullException();
            }

            Appointment = appointment;
            AppointmentId = appointment.Id;
            Employee = employee;
            EmployeeId = employee.Id;
        }
    }
}
