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

                if (foundedAgent is not null) 
                {
                    var participant = Participant.Create(createParticipantDto.Role, foundedAppointment, foundedAgent);

                    addedParticipant =_unitOfWork.ParticipantRepository.Add(participant);
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
            throw new NotImplementedException();
        }

        public ParticipantDto Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<ParticipantDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public ParticipantDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ParticipantDto Update(ParticipantDto participantDto)
        {
            throw new NotImplementedException();
        }
    }
}
