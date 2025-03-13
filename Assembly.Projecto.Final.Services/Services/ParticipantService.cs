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
    public class ParticipantService : IParticipantService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ParticipantService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        public Participant Add(Participant participant)
        {
            return _unitOfWork.ParticipantRepository.Add(participant);
        }

        public Participant Delete(Participant participant)
        {
            return _unitOfWork.ParticipantRepository.Delete(participant);
        }

        public Participant? Delete(int id)
        {
            return _unitOfWork.ParticipantRepository.Delete(id);
        }

        public List<Participant> GetAll()
        {
            return _unitOfWork.ParticipantRepository.GetAll();
        }

        public Participant? GetById(int id)
        {
            return _unitOfWork.ParticipantRepository.GetById(id);
        }

        public Participant Update(Participant participant)
        {
             return _unitOfWork.ParticipantRepository.Update(participant);
        }
    }
}
