using Assembly.Projecto.Final.Domain.Core.Repositories;
using Assembly.Projecto.Final.Domain.Enums;
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
    public class ParticipantService : IParticipantService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public ParticipantService(IUnitOfWork unitOfWork,IMapper mapper) 
        {
            _unitOfWork = unitOfWork;

            _mapper = mapper;
        }

        public ParticipantDto Add(CreateParticipantDto createParticipantDto)
        {
            Participant addedParticipant;

            using (_unitOfWork) 
            {
                _unitOfWork.BeginTransaction();

                var foundedAppointment = _unitOfWork.AppointmentRepository.GetById(createParticipantDto.AppointmentId);

                if (foundedAppointment is null) 
                {
                    throw new ArgumentNullException(nameof(foundedAppointment), "Não foi encontrado.");
                }

                var foundedAgent = _unitOfWork.AgentRepository.GetById(createParticipantDto.EmployeeId);

                var foundedStaff = _unitOfWork.StaffRepository.GetById(createParticipantDto.EmployeeId);

                if (foundedAgent is null && foundedStaff is null)
                {
                    throw new ArgumentNullException( "Não foi encontrado o empregado.");
                }
                else if(foundedAgent is not null && foundedStaff is not null) 
                {
                    throw new ArgumentNullException("Erro.");
                }

                if (foundedAgent is not null)
                {
                    var participant = Participant.Create(createParticipantDto.Role, foundedAppointment, foundedAgent);

                    addedParticipant = _unitOfWork.ParticipantRepository.Add(participant);
                }
                else
                {
                    var participant = Participant.Create(createParticipantDto.Role, foundedAppointment, foundedStaff);

                    addedParticipant = _unitOfWork.ParticipantRepository.Add(participant);
                }

                _unitOfWork.Commit();
            }

            return _mapper.Map<ParticipantDto>(addedParticipant);
        }

        public ParticipantDto Delete(ParticipantDto participantDto)
        {
            Participant deletedParticipant;

            using (_unitOfWork) 
            {
                _unitOfWork.BeginTransaction();

                var foundedParticipant = _unitOfWork.ParticipantRepository.GetById(participantDto.Id);

                if(foundedParticipant is null) 
                {
                    throw new ArgumentNullException(nameof(foundedParticipant),"Não foi encontrado.");
                }

                deletedParticipant = _unitOfWork.ParticipantRepository.Delete(foundedParticipant);

                _unitOfWork.Commit();
            }

            return _mapper.Map<ParticipantDto>(deletedParticipant);
        }

        public ParticipantDto Delete(int id)
        {
            Participant deletedParticipant;

            using (_unitOfWork)
            {
                _unitOfWork.BeginTransaction();

                var foundedParticipant = _unitOfWork.ParticipantRepository.GetById(id);

                if (foundedParticipant is null)
                {
                    throw new ArgumentNullException(nameof(foundedParticipant), "Não foi encontrado.");
                }

                deletedParticipant = _unitOfWork.ParticipantRepository.Delete(id);

                _unitOfWork.Commit();
            }

            return _mapper.Map<ParticipantDto>(deletedParticipant);
        }

        public List<ParticipantDto> GetAll()
        {
            var list = new List<ParticipantDto>();

            foreach (var participant in _unitOfWork.ParticipantRepository.GetAll()) 
            {
                var participantDto = _mapper.Map<ParticipantDto>(participant);

                list.Add(participantDto);
            }

            return list;
        }

        public ParticipantDto GetById(int id)
        {
            var participant = _unitOfWork.ParticipantRepository.GetById(id);

            return _mapper.Map<ParticipantDto>(participant);
        }

        public ParticipantDto Update(ParticipantDto participantDto)
        {
            Participant updatedParticipant;

            using (_unitOfWork)
            {
                _unitOfWork.BeginTransaction();

                var foundedParticipant = _unitOfWork.ParticipantRepository.GetById(id);

                if (foundedParticipant is null)
                {
                    throw new ArgumentNullException(nameof(foundedParticipant), "Não foi encontrado.");
                }

                var foundedAppointment = _unitOfWork.AppointmentRepository.GetById(participantDto.AppointmentId);

                if (foundedAppointment is null)
                {
                    throw new ArgumentNullException(nameof(foundedAppointment), "Não foi encontrado.");
                }

                var foundedAgent = _unitOfWork.AgentRepository.GetById(participantDto.EmployeeId);

                var foundedStaff = _unitOfWork.StaffRepository.GetById(participantDto.EmployeeId);

                if (foundedAgent is null && foundedStaff is null)
                {
                    throw new ArgumentNullException("Não foi encontrado o empregado.");
                }
                else if (foundedAgent is not null && foundedStaff is not null)
                {
                    throw new ArgumentNullException("Erro.");
                }

                if (foundedAgent is not null)
                {
                    foundedParticipant.Update(participantDto.Role, foundedAppointment, foundedAgent);

                    updatedParticipant = _unitOfWork.ParticipantRepository.Update(foundedParticipant);
                }
                else
                {
                    foundedParticipant.Update(participantDto.Role, foundedAppointment, foundedStaff);

                    updatedParticipant = _unitOfWork.ParticipantRepository.Update(foundedParticipant);
                }

                _unitOfWork.Commit();
            }

            return _mapper.Map<ParticipantDto>(updatedParticipant);
        }
    }
}
