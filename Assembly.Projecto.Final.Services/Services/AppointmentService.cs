using Assembly.Projecto.Final.Domain.Core.Repositories;
using Assembly.Projecto.Final.Domain.Models;
using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.OtherModelsDtos;
using Assembly.Projecto.Final.Services.Interfaces;
using AutoMapper;
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
        private IMapper _mapper;
        public AppointmentService(IUnitOfWork unitOfWork,IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public AppointmentDto Add(CreateAppointmentDto createAppointmentDto)
        {
            Appointment addedAppointment;

            using (_unitOfWork) 
            {
                _unitOfWork.BeginTransaction();

                var appointment = Appointment.Create(createAppointmentDto.Title,createAppointmentDto.Description,
                    createAppointmentDto.Date,createAppointmentDto.HourStart,createAppointmentDto.HourEnd,
                    createAppointmentDto.Status,createAppointmentDto.BookedBy);

                addedAppointment = _unitOfWork.AppointmentRepository.Add(appointment);

                _unitOfWork.Commit();
            }

            return _mapper.Map<AppointmentDto>(addedAppointment);
        }

        public AppointmentDto Delete(AppointmentDto appointmentDto)
        {
            Appointment deletedAppointment;

            using (_unitOfWork) 
            {
                _unitOfWork.BeginTransaction();

                var foundedAppointment = _unitOfWork.AppointmentRepository.GetById(appointmentDto.Id);

                if (foundedAppointment is null) 
                {
                    throw new ArgumentNullException(nameof(foundedAppointment), "Não foi encontrado.");
                }

                deletedAppointment =_unitOfWork.AppointmentRepository.Delete(foundedAppointment);

                _unitOfWork.Commit();
            }

            return _mapper.Map<AppointmentDto>(deletedAppointment);
        }

        public AppointmentDto Delete(int id)
        {
            Appointment deletedAppointment;

            using( _unitOfWork) 
            {
                _unitOfWork.BeginTransaction();

                var foundedAppointment = _unitOfWork.AppointmentRepository.GetById(id);

                if(foundedAppointment is null) 
                {
                    throw new ArgumentNullException(nameof(foundedAppointment), "Não foi encontrado.");
                }

                deletedAppointment = _unitOfWork.AppointmentRepository.Delete(id);

                _unitOfWork.Commit();
            }

            return _mapper.Map<AppointmentDto>(deletedAppointment);
        }

        public List<AppointmentDto> GetAll()
        {
            var list = new List<AppointmentDto>();

            foreach(var appointment in _unitOfWork.AppointmentRepository.GetAll()) 
            {
                var appointmentDto = _mapper.Map<AppointmentDto>(appointment);

                list.Add(appointmentDto);
            }

            return list;
        }

        public AppointmentDto GetById(int id)
        {
            var appointment = _unitOfWork.AppointmentRepository.GetById(id);

            return _mapper.Map<AppointmentDto>(appointment);
        }

        public AppointmentDto Update(AppointmentDto appointmentDto)
        {
            Appointment updatedAppointment;

            using (_unitOfWork)
            {
                _unitOfWork.BeginTransaction();

                var foundedAppointment = _unitOfWork.AppointmentRepository.GetById(appointmentDto.Id);

                if (foundedAppointment is null)
                {
                    throw new ArgumentNullException(nameof(foundedAppointment), "Não foi encontrado.");
                }

                foundedAppointment.Update(appointmentDto.Title, appointmentDto.Description,
                    appointmentDto.Date, appointmentDto.HourStart,appointmentDto.HourEnd,
                    appointmentDto.Status, appointmentDto.BookedBy);

                updatedAppointment = _unitOfWork.AppointmentRepository.Update(foundedAppointment);

                _unitOfWork.Commit();
            }

            return _mapper.Map<AppointmentDto>(updatedAppointment);
        }
    }
}
