using Assembly.Projecto.Final.Domain.Common;
using Assembly.Projecto.Final.Domain.Enums;
using Assembly.Projecto.Final.Domain.Validations;
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
            DomainValidadion(role, appointment, employee);
        }

        private Participant(int id,ParticipantType role, Appointment appointment, Employee employee) 
            :this(role,appointment, employee) 
        {
            Id = id;
        }

        public static Participant Create(ParticipantType role, Appointment appointment, 
            Employee employee) 
        {
            var participant = new Participant(role, appointment, employee);

            return participant;
        }

        public static Participant Create(int id,ParticipantType role, Appointment appointment,Employee employee)
        {
            var participant = new Participant(id,role, appointment, employee);

            return participant;
        }

        public void Update(ParticipantType role, Appointment appointment,Employee employee) 
        {
            DomainValidadion(role, appointment, employee);
        }

        public void DomainValidadion(ParticipantType role, Appointment appointment, Employee employee) 
        {
            DomainExceptionValidation.When(appointment == null, "Erro: appointment não pode ser nulo.");
            DomainExceptionValidation.When(employee == null, "Erro: Employee não pode ser nulo.");

            Role = role;
            Appointment = appointment;
            AppointmentId = appointment.Id;
            Employee = employee;
            EmployeeId = employee.Id;
        }
    }
}
