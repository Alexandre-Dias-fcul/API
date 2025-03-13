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
    public class EntityLinkService : IEntityLinkService
    {
        private readonly IUnitOfWork _unitOfWork;
        public EntityLinkService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        public EntityLink Add(EntityLink entityLink)
        {
            return _unitOfWork.EntityLinkRepository.Add(entityLink);   
        }

        public EntityLink Delete(EntityLink entityLink)
        {
            return _unitOfWork.EntityLinkRepository.Delete(entityLink);
        }

        public EntityLink? Delete(int id)
        {
            return _unitOfWork.EntityLinkRepository.Delete(id);
        }

        public List<EntityLink> GetAll()
        {
            return _unitOfWork.EntityLinkRepository.GetAll();
        }

        public EntityLink? GetById(int id)
        {
            return _unitOfWork.EntityLinkRepository.GetById(id);
        }

        public EntityLink Update(EntityLink entityLink)
        {
            return _unitOfWork.EntityLinkRepository.Update(entityLink);
        }
    }
}
