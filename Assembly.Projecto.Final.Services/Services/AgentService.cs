using Assembly.Projecto.Final.Domain.Common;
using Assembly.Projecto.Final.Domain.Core.Repositories;
using Assembly.Projecto.Final.Domain.Enums;
using Assembly.Projecto.Final.Domain.Models;
using Assembly.Projecto.Final.Services.Dtos;
using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.EmployeeUserDtos;
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
    public class AgentService : IAgentService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        public AgentService(IUnitOfWork unitOfWork, IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public AgentDto Add(CreateAgentDto createAgentDto)
        {
            Agent addedAgent;

            using (_unitOfWork) 
            {
                _unitOfWork.BeginTransaction();

                var name = Name.Create(createAgentDto.Name.FirstName,createAgentDto.Name.MiddleNames,
                    createAgentDto.Name.LastName);

                var agent = Agent.Create(name, createAgentDto.DateOfBirth, createAgentDto.Gender,
                    createAgentDto.PhotoFileName, createAgentDto.IsActive,createAgentDto.HiredDate, 
                    createAgentDto.DateOfTermination, createAgentDto.Role);

                if (createAgentDto.SupervisorId is not null) 
                {
                    var supervisor = _unitOfWork.AgentRepository.GetById((int)createAgentDto.SupervisorId);

                    if(supervisor is null) 
                    {
                        throw new ArgumentNullException(nameof(supervisor), "Não foi encontrado.");
                    }

                    agent.SetSupervisor(supervisor);
                }

                addedAgent = _unitOfWork.AgentRepository.Add(agent);

                _unitOfWork.Commit();
            }

            return _mapper.Map<AgentDto>(addedAgent);
        }

        public AgentDto Delete(AgentDto agentDto)
        {
            Agent deletedAgent;

            using(_unitOfWork) 
            {
                _unitOfWork.BeginTransaction();

                var foundedAgent = _unitOfWork.AgentRepository.GetById(agentDto.Id);

                if(foundedAgent is null) 
                {
                    throw new ArgumentNullException(nameof(foundedAgent), "Não foi encontrado.");
                }

                deletedAgent =_unitOfWork.AgentRepository.Delete(foundedAgent);

                _unitOfWork.Commit();
            }

            return _mapper.Map<AgentDto>(deletedAgent);
        }

        public AgentDto Delete(int id)
        {
            Agent deletedAgent;

            using (_unitOfWork)
            {
                _unitOfWork.BeginTransaction();

                var foundedAgent = _unitOfWork.AgentRepository.GetById(id);

                if (foundedAgent is null)
                {
                    throw new ArgumentNullException(nameof(foundedAgent), "Não foi encontrado.");
                }

                deletedAgent = _unitOfWork.AgentRepository.Delete(id);

                _unitOfWork.Commit();
            }

            return _mapper.Map<AgentDto>(deletedAgent);
        }

        public List<AgentDto> GetAll()
        {
            var list = new List<AgentDto>();

            foreach (var agent in _unitOfWork.AgentRepository.GetAll())
            {
                var agentDto = _mapper.Map<AgentDto>(agent);

                list.Add(agentDto);
            }

            return list;
        }

        public AgentDto GetById(int id)
        {
            var agent = _unitOfWork.AgentRepository.GetById(id);

            return _mapper.Map<AgentDto>(agent);
        }

        public AgentDto Update(AgentDto agentDto)
        {
            Agent updatedAgent;

            using (_unitOfWork)
            {
                _unitOfWork.BeginTransaction();

                var foundedAgent = _unitOfWork.AgentRepository.GetById(agentDto.Id);

                if(foundedAgent is null) 
                {
                    throw new ArgumentNullException(nameof(foundedAgent), "Não foi encontrado.");
                }

                foundedAgent.Update(agentDto.Name.FirstName,agentDto.Name.MiddleNames,agentDto.Name.LastName,
                    agentDto.DateOfBirth,agentDto.Gender,agentDto.PhotoFileName,agentDto.IsActive);

                if (agentDto.SupervisorId is not null)
                {
                    var supervisor = _unitOfWork.AgentRepository.GetById((int)agentDto.SupervisorId);

                    if (supervisor is null)
                    {
                        throw new ArgumentNullException(nameof(supervisor), "Não foi encontrado.");
                    }

                    foundedAgent.SetSupervisor(supervisor);
                }

                updatedAgent = _unitOfWork.AgentRepository.Update(foundedAgent);

                _unitOfWork.Commit();
            }

            return _mapper.Map<AgentDto>(updatedAgent);
        }
    }
}
