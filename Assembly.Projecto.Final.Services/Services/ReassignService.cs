using Assembly.Projecto.Final.Domain.Core.Repositories;
using Assembly.Projecto.Final.Domain.Models;
using Assembly.Projecto.Final.Services.Dtos.IServiceDtos.OtherModelsDtos;
using Assembly.Projecto.Final.Services.Exceptions;
using Assembly.Projecto.Final.Services.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Services.Services
{
    public class ReassignService : IReassignService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        public ReassignService(IUnitOfWork unitOfWork,IMapper mapper) 
        {
            _unitOfWork = unitOfWork;

            _mapper = mapper;
        }

        public ReassignDto Add(CreateReassignDto createReassignDto)
        {
            Reassign addedReassign;

            using (_unitOfWork) 
            {

                var reassign = Reassign.Create(createReassignDto.OlderEmployeeId,createReassignDto.NewEmployeeId,
                    createReassignDto.ReassignBy,createReassignDto.ReassignmentDate);

                addedReassign = _unitOfWork.ReassignRepository.Add(reassign);

                _unitOfWork.Commit();
            }

            return _mapper.Map<ReassignDto>(addedReassign);
        }

        public ReassignDto Delete(ReassignDto reassignDto)
        {
            Reassign deletedReassign;

            using (_unitOfWork) 
            {

                var foundedReassign = _unitOfWork.ReassignRepository.GetById(reassignDto.Id);

                NotFoundException.When(foundedReassign is null,$"{nameof(foundedReassign)} não foi encontrado.");

                deletedReassign = _unitOfWork.ReassignRepository.Delete(foundedReassign);

                _unitOfWork.Commit();
            }

            return _mapper.Map<ReassignDto>(deletedReassign);
        }

        public ReassignDto Delete(int id)
        {
            Reassign deletedReassign;

            using (_unitOfWork)
            {

                var foundedReassign = _unitOfWork.ReassignRepository.GetById(id);

                NotFoundException.When(foundedReassign is null, $"{nameof(foundedReassign)} não foi encontrado.");

                deletedReassign = _unitOfWork.ReassignRepository.Delete(id);

                _unitOfWork.Commit();
            }

            return _mapper.Map<ReassignDto>(deletedReassign);
        }

        public List<ReassignDto> GetAll()
        {
            var list = new List<ReassignDto>();

            foreach (var reassign in _unitOfWork.ReassignRepository.GetAll()) 
            {
                var reassignDto = _mapper.Map<ReassignDto>(reassign);

                list.Add(reassignDto);
            }

            return list;
        }

        public ReassignDto GetById(int id)
        {
            var reassign = _unitOfWork.ReassignRepository.GetById(id);

            return _mapper.Map<ReassignDto>(reassign);
        }

        public ReassignDto Update(ReassignDto reassignDto)
        {
            Reassign updatedReassign;

            using (_unitOfWork)
            {

                var foundedReassign = _unitOfWork.ReassignRepository.GetById(reassignDto.Id);

                NotFoundException.When(foundedReassign is null, $"{nameof(foundedReassign)} não foi encontrado.");

                foundedReassign.Update(reassignDto.OlderEmployeeId,reassignDto.NewEmployeeId,
                    reassignDto.ReassignBy,reassignDto.ReassignmentDate);

                updatedReassign = _unitOfWork.ReassignRepository.Update(foundedReassign);

                _unitOfWork.Commit();
            }

            return _mapper.Map<ReassignDto>(updatedReassign);
        }
    }
}
