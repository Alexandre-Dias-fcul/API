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
    
    public class AgentController : BaseController
    {
        private readonly IAgentService _agentService;
        public AgentController(IAgentService agentService) 
        {
            _agentService = agentService;
        }

        [HttpGet]
        public ActionResult<List<AgentDto>> GetAllInclude() 
        {
            var agents = _agentService.GetAllInclude();

            return Ok(agents);
        }

        [HttpGet("{id:int}")]
        public ActionResult<AgentDto> GetByIdInclude(int id) 
        {
            var agent = _agentService.GetByIdInclude(id);

            return Ok(agent);
        }

        [HttpGet("GetAllAgentsByManagerId{idManager:int}")]
        public ActionResult<ManagerAgentDto> GetAllManagerAgents(int idManager) 
        {
            var agents = _agentService.GetAllManagerAgents(idManager);

            return Ok(agents);
        }

        [HttpGet("GetAllListingsByEmployeeId{idEmployee:int}")]
        public ActionResult<AgentListingDto> GetAllListingsByEmployeeId(int idEmployee) 
        {
            var agent = _agentService.GetAllListingByEmployeeId(idEmployee);

            return Ok(agent);
        }

        [HttpPatch("Reassign")]
        public ActionResult Reassign([FromBody] ReassignRequestDto reassignRequestDto) 
        {
            _agentService.ManagerReassign(reassignRequestDto.ManagerId, reassignRequestDto.AgentId);

            return Ok();
        }

        [HttpPost]
        public ActionResult<AgentDto> Create([FromBody] AgentDto agentDto)  
        {
            var agent = _agentService.Add(agentDto);

            return Ok(agent);
        }

        [HttpPut]
        public ActionResult<AgentDtoId> Update([FromBody] AgentDtoId agentDtoId) 
        {
            var agent = _agentService.Update(agentDtoId);

            return Ok(agent);
        }
    }
}
