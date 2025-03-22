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
            throw new NotImplementedException();
        }

        public ReassignDto Delete(ReassignDto reassignDto)
        {
            throw new NotImplementedException();
        }

        public ReassignDto Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<ReassignDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public ReassignDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ReassignDto Update(ReassignDto reassignDto)
        {
            throw new NotImplementedException();
        }
    }
}
