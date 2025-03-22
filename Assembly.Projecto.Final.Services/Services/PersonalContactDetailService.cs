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
    public class PersonalContactDetailService : IPersonalContactDetailService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        public PersonalContactDetailService(IUnitOfWork unitOfWork,IMapper mapper) 
        {
            _unitOfWork = unitOfWork;

            _mapper = mapper;
        }

        public PersonalContactDetailDto Add(CreatePersonalContactDetailDto obj)
        {
            throw new NotImplementedException();
        }

        public PersonalContactDetailDto Delete(PersonalContactDetailDto obj)
        {
            throw new NotImplementedException();
        }

        public PersonalContactDetailDto Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<PersonalContactDetailDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public PersonalContactDetailDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public PersonalContactDetailDto Update(PersonalContactDetailDto obj)
        {
            throw new NotImplementedException();
        }
    }
}
