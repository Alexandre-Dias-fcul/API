using Assembly.Projecto.Final.Domain.Core.Repositories;
using Assembly.Projecto.Final.Domain.Models;
using Assembly.Projecto.Final.Services.Dtos;
using Assembly.Projecto.Final.Services.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Services.Services
{
    public class AgentService : IAgentService
    {
        private readonly IAgentRepository _agentRepository;

        private readonly IMapper _mapper;
        public AgentService(IAgentRepository agentRepository,IMapper mapper) 
        { 
            _agentRepository = agentRepository;
            _mapper = mapper;
        }
        public Agent Add(Agent agent)
        {
            return _agentRepository.Add(agent);
        }

        public Agent Delete(Agent agent)
        {
            return _agentRepository.Delete(agent);
        }

        public Agent? Delete(int id)
        {
            return _agentRepository.Delete(id);
        }

        public List<Agent> GetAll()
        {
             return _agentRepository.GetAll();
        }

        public List<AgentDto> GetAllInclude()
        {
            var agents = _agentRepository.GetAllInclude();

            var agentDtos = _mapper.Map<List<AgentDto>>(agents);

            return agentDtos;
        }

        public Agent? GetById(int id)
        {
             return _agentRepository.GetById(id);
        }

        public Agent Update(Agent agent)
        {
             return _agentRepository.Update(agent);
        }
    }
}
