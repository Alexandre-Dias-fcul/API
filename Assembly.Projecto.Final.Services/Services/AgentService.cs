using Assembly.Projecto.Final.Domain.Common;
using Assembly.Projecto.Final.Domain.Core.Repositories;
using Assembly.Projecto.Final.Domain.Enums;
using Assembly.Projecto.Final.Domain.Models;
using Assembly.Projecto.Final.Services.Dtos;
using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.EmployeeUserDtos;
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

        public AgentDto Add(CreateAgentDto obj)
        {
            throw new NotImplementedException();
        }

        public AgentDto Delete(AgentDto obj)
        {
            throw new NotImplementedException();
        }

        public AgentDto Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<AgentDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public AgentDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public AgentDto Update(AgentDto obj)
        {
            throw new NotImplementedException();
        }
    }
}
