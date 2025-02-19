using Assembly.Projecto.Final.Domain.Core.Repositories;
using Assembly.Projecto.Final.Domain.Models;
using Assembly.Projecto.Final.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Services.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        public AppointmentService(IAppointmentRepository appointmentRepository) 
        { 
            _appointmentRepository = appointmentRepository;
        }
        public Appointment Add(Appointment appointment)
        {
             return _appointmentRepository.Add(appointment);
        }

        public Appointment Delete(Appointment appointment)
        {
             return _appointmentRepository.Delete(appointment);
        }

        public Appointment? Delete(int id)
        {
            return _appointmentRepository.Delete(id);
        }

        public List<Appointment> GetAll()
        {
            return _appointmentRepository.GetAll();
        }

        public Appointment? GetById(int id)
        {
            return _appointmentRepository.GetById(id);
        }

        public Appointment Update(Appointment appointment)
        {
            return _appointmentRepository.Update(appointment);
        }
    }
}
