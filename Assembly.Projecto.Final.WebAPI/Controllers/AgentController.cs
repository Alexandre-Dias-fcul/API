using Assembly.Projecto.Final.Domain.Common;
using Assembly.Projecto.Final.Domain.Enums;
using Assembly.Projecto.Final.Domain.Models;
using Assembly.Projecto.Final.Services.Dtos;
using Assembly.Projecto.Final.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assembly.Projecto.Final.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private readonly IAgentService _agentService;
        public AgentController(IAgentService agentService) 
        {
            _agentService = agentService;
        }

        [HttpGet]
        public ActionResult<List<AgentDto>> GetAll() 
        {
            var agents = _agentService.GetAllInclude();

            return Ok(agents);
        }

        [HttpGet("{id:int}")]
        public ActionResult<AgentDto> GetById(int id) 
        {
            var agent = _agentService.GetByIdInclude(id);

            return Ok(agent);
        }

        [HttpPost]

        public ActionResult<AgentDto> Create([FromBody] AgentDto agentDto)  
        {
            var agentAdicionado = _agentService.Add(agentDto);

            return Ok(agentAdicionado);
        }

        [HttpPut]
        public ActionResult<AgentDtoId> Update([FromBody] AgentDtoId agentDtoId) 
        {
            var agentAlterado = _agentService.Update(agentDtoId);

            return Ok(agentAlterado);
        }
    }
}
