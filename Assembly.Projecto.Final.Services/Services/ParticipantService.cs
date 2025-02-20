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
        private readonly IParticipantRepository _participantRepository;

        public ParticipantService(IParticipantRepository participantRepository) 
        { 
            _participantRepository = participantRepository;
        }
        public Participant Add(Participant participant)
        {
            return _participantRepository.Add(participant);
        }

        public Participant Delete(Participant participant)
        {
            return _participantRepository.Delete(participant);
        }

        public Participant? Delete(int id)
        {
            return _participantRepository.Delete(id);
        }

        public List<Participant> GetAll()
        {
            return _participantRepository.GetAll();
        }

        public Participant? GetById(int id)
        {
            return _participantRepository.GetById(id);
        }

        public Participant Update(Participant participant)
        {
             return _participantRepository.Update(participant);
        }
    }
}
