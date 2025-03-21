using Assembly.Projecto.Final.Domain.Core.Repositories;
using Assembly.Projecto.Final.Domain.Models;
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
    public class EntityLinkService : IEntityLinkService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        public EntityLinkService(IUnitOfWork unitOfWork,IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public EntityLinkDto Add(CreateEntityLinkDto createEntityLinkDto)
        {
            EntityLink addedEntityLink;

            using (_unitOfWork) 
            {
                _unitOfWork.BeginTransaction();

                var entityLink = EntityLink.Create(createEntityLinkDto.EntityType,createEntityLinkDto.EntityId);

                addedEntityLink = _unitOfWork.EntityLinkRepository.Add(entityLink);

                _unitOfWork.Commit();
            }

            return _mapper.Map<EntityLinkDto>(addedEntityLink);
        }

        public EntityLinkDto Delete(EntityLinkDto entityLinkDto)
        {
            EntityLink deletedEntityLink;

            using(_unitOfWork) 
            {
                _unitOfWork.BeginTransaction();

                var foundedEntityLink = _unitOfWork.EntityLinkRepository.GetById(entityLinkDto.Id);

                if(foundedEntityLink is null) 
                {
                    throw new ArgumentNullException(nameof(foundedEntityLink), "Não foi encontrado.");
                }

                deletedEntityLink = _unitOfWork.EntityLinkRepository.Delete(foundedEntityLink);

                _unitOfWork.Commit();
            }

            return _mapper.Map<EntityLinkDto>(deletedEntityLink);
        }

        public EntityLinkDto Delete(int id)
        {
            EntityLink deletedEntityLink;

            using (_unitOfWork)
            {
                _unitOfWork.BeginTransaction();

                var foundedEntityLink = _unitOfWork.EntityLinkRepository.GetById(id);

                if (foundedEntityLink is null)
                {
                    throw new ArgumentNullException(nameof(foundedEntityLink), "Não foi encontrado.");
                }

                deletedEntityLink = _unitOfWork.EntityLinkRepository.Delete(id);

                _unitOfWork.Commit();
            }

            return _mapper.Map<EntityLinkDto>(deletedEntityLink);
        }

        public List<EntityLinkDto> GetAll()
        {
            var list = new List<EntityLinkDto>();

            foreach(var entityLink in _unitOfWork.EntityLinkRepository.GetAll()) 
            {
                var entityLinkDto = _mapper.Map<EntityLinkDto>(entityLink);

                list.Add(entityLinkDto);
            }

            return list;
        }

        public EntityLinkDto GetById(int id)
        {

            var entityLink = _unitOfWork.EntityLinkRepository.GetById(id);

            return _mapper.Map<EntityLinkDto>(entityLink);
        }

        public EntityLinkDto Update(EntityLinkDto entityLinkDto)
        {
            EntityLink updatedEntityLink;

            using (_unitOfWork)
            {
                _unitOfWork.BeginTransaction();

                var foundedEntityLink = _unitOfWork.EntityLinkRepository.GetById(entityLinkDto.Id);

                if (foundedEntityLink is null)
                {
                    throw new ArgumentNullException(nameof(foundedEntityLink), "Não foi encontrado.");
                }

                foundedEntityLink.Update(entityLinkDto.EntityType, entityLinkDto.EntityId);

                updatedEntityLink = _unitOfWork.EntityLinkRepository.Update(foundedEntityLink);

                _unitOfWork.Commit();
            }

            return _mapper.Map<EntityLinkDto>(updatedEntityLink);
        }
    }
}
