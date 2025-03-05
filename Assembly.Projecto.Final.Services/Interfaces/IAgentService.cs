using Assembly.Projecto.Final.Domain.Models;
using Assembly.Projecto.Final.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Services.Interfaces
{
     public interface IAgentService:IServiceProvisorio<AgentDto,AgentDtoId,int>
    {
        List<AgentDtoId> GetAllInclude();

        AgentDtoId? GetByIdInclude(int id);

        List<ManagerAgentDto> GetAllManagerAgents(int idManager);
    }
}
