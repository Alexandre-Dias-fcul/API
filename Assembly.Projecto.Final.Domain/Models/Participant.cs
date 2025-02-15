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

        private Participant(ParticipantType role, Appointment appointment, int appointmentId, Employee employee, 
            int employeeId) :this()
        {
            Role = role;
            Appointment = appointment;
            AppointmentId = appointmentId;
            Employee = employee;
            EmployeeId = employeeId;
        }

        private Participant(int id,ParticipantType role, Appointment appointment, int appointmentId, Employee employee,
            int employeeId) :this(role,appointment, appointmentId, employee, employeeId) 
        {
            Id = id;
        }

        private static Participant Created(ParticipantType role, Appointment appointment, int appointmentId, 
            Employee employee,int employeeId) 
        {
            var participant = new Participant(role, appointment, appointmentId, employee, employeeId);

            return participant;
        }

        private static Participant Created(int id,ParticipantType role, Appointment appointment, int appointmentId,
            Employee employee, int employeeId)
        {
            var participant = new Participant(id,role, appointment, appointmentId, employee, employeeId);

            return participant;
        }

        private void Update(ParticipantType role, Appointment appointment, int appointmentId,
            Employee employee, int employeeId) 
        {
            Role = role;
            Updated = DateTime.Now;
            Appointment = appointment;
            AppointmentId = appointmentId;
            Employee = employee;
            EmployeeId = employeeId;
        }
    }
}
