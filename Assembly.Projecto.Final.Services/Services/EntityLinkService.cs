using Assembly.Projecto.Final.Domain.Core.Repositories;
using Assembly.Projecto.Final.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Services.Services
{
    public class EntityLinkService : IEntityLinkRepository
    {
        private readonly IEntityLinkRepository _entityLinkRepository;
        public EntityLinkService(IEntityLinkRepository entityLinkRepository) 
        {
            _entityLinkRepository = entityLinkRepository;
        }
        public EntityLink Add(EntityLink entityLink)
        {
            return _entityLinkRepository.Add(entityLink);   
        }

        public EntityLink Delete(EntityLink entityLink)
        {
            return _entityLinkRepository.Delete(entityLink);
        }

        public EntityLink? Delete(int id)
        {
            return _entityLinkRepository.Delete(id);
        }

        public List<EntityLink> GetAll()
        {
            return _entityLinkRepository.GetAll();
        }

        public EntityLink? GetById(int id)
        {
            return _entityLinkRepository.GetById(id);
        }

        public EntityLink Update(EntityLink entityLink)
        {
            return _entityLinkRepository.Update(entityLink);
        }
    }
}
