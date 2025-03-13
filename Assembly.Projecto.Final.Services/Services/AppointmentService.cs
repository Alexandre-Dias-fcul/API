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
        private readonly IUnitOfWork _unitOfWork;
        public AppointmentService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        public Appointment Add(Appointment appointment)
        {
             return _unitOfWork.AppointmentRepository.Add(appointment);
        }

        public Appointment Delete(Appointment appointment)
        {
             return _unitOfWork.AppointmentRepository.Delete(appointment);
        }

        public Appointment? Delete(int id)
        {
            return _unitOfWork.AppointmentRepository.Delete(id);
        }

        public List<Appointment> GetAll()
        {
            return _unitOfWork.AppointmentRepository.GetAll();
        }

        public Appointment? GetById(int id)
        {
            return _unitOfWork.AppointmentRepository.GetById(id);
        }

        public Appointment Update(Appointment appointment)
        {
            return _unitOfWork.AppointmentRepository.Update(appointment);
        }
    }
}
