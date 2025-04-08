using Assembly.Projecto.Final.Domain.Common;
using Assembly.Projecto.Final.Domain.Core.Repositories;
using Assembly.Projecto.Final.Domain.Enums;
using Assembly.Projecto.Final.Domain.Models;
using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.OtherModelsDtos;
using Assembly.Projecto.Final.Services.Exceptions;
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

                Employee employee;

                if (createAppointmentDto.Role is null)
                {
                    employee = _unitOfWork.StaffRepository.GetById(createAppointmentDto.EmployeeId);
                }
                else
                {
                    employee = _unitOfWork.AgentRepository.GetById(createAppointmentDto.EmployeeId);
                }

                NotFoundException.When(employee is null, $"{nameof(employee)} não foi encontrado.");

                var appointment = Appointment.Create(createAppointmentDto.Title,createAppointmentDto.Description,
                    createAppointmentDto.Date,createAppointmentDto.HourStart,createAppointmentDto.HourEnd,
                    createAppointmentDto.Status);

                addedAppointment = _unitOfWork.AppointmentRepository.Add(appointment);

                var participant = Participant.Create(ParticipantType.Organizer,addedAppointment,employee);

                _unitOfWork.ParticipantRepository.Add(participant);

                _unitOfWork.Commit();
            }

            return _mapper.Map<AppointmentDto>(addedAppointment);
        }

        public ParticipantDto AddParticipant(int appointmentId, int employeeId,RoleType? role)
        {
            using (_unitOfWork) 
            {
                var appointment = _unitOfWork.AppointmentRepository.GetById(appointmentId);

                NotFoundException.When(appointment is null,$"{nameof(appointment)} não foi encontrado.");

                Employee employee;

                if(role is null) 
                {
                    employee = _unitOfWork.StaffRepository.GetById(employeeId);
                }
                else 
                {
                    employee = _unitOfWork.AgentRepository.GetById(employeeId);
                }

                NotFoundException.When(employee is null, $"{nameof(employee)} não foi encontrado.");

                var participant = Participant.Create(ParticipantType.Participant, appointment, employee);

                var addedParticipant =_unitOfWork.ParticipantRepository.Add(participant);

                _unitOfWork.Commit();

                return _mapper.Map<ParticipantDto>(addedParticipant);
            }
        }

        public ParticipantDto DeleteParticipant(int appointmentId, int participantId)
        {
            using (_unitOfWork)
            {
                var appointment = _unitOfWork.AppointmentRepository.GetByIdWithParticipants(appointmentId);

                NotFoundException.When(appointment is null, $"{nameof(appointment)} não foi encontrado.");

                var participant = appointment.Participants.FirstOrDefault(a => a.Id == participantId);

                NotFoundException.When(participant is null, $"{nameof(participant)} não foi encontrado.");

                CustomApplicationException.When(participant.Role == ParticipantType.Organizer,
                    $" Não pode apagar o organizador do appointment.");

                var deletedParticipant =_unitOfWork.ParticipantRepository.Delete(participant);

                _unitOfWork.Commit();

                return _mapper.Map<ParticipantDto>(deletedParticipant);
              
            }
        }

        public AppointmentDto Delete(AppointmentDto appointmentDto)
        {
            Appointment deletedAppointment;

            using (_unitOfWork) 
            {
                _unitOfWork.BeginTransaction();

                var foundedAppointment = _unitOfWork.AppointmentRepository.GetByIdWithParticipants(appointmentDto.Id);

                NotFoundException.When(foundedAppointment is null, $"{nameof(foundedAppointment)} não foi encontrado.");

                foreach(var participant in foundedAppointment.Participants) 
                {
                    _unitOfWork.ParticipantRepository.Delete(participant);
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

                var foundedAppointment = _unitOfWork.AppointmentRepository.GetByIdWithParticipants(id);

                NotFoundException.When(foundedAppointment is null, $"{nameof(foundedAppointment)} não foi encontrado.");

                foreach (var participant in foundedAppointment.Participants)
                {
                    _unitOfWork.ParticipantRepository.Delete(participant);
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
                var foundedAppointment = _unitOfWork.AppointmentRepository.GetById(appointmentDto.Id);

                NotFoundException.When(foundedAppointment is null, $"{nameof(foundedAppointment)} não foi encontrado.");

                foundedAppointment.Update(appointmentDto.Title, appointmentDto.Description,
                    appointmentDto.Date, appointmentDto.HourStart,appointmentDto.HourEnd,
                    appointmentDto.Status);

                updatedAppointment = _unitOfWork.AppointmentRepository.Update(foundedAppointment);

                _unitOfWork.Commit();
            }

            return _mapper.Map<AppointmentDto>(updatedAppointment);
        }
    }
}
