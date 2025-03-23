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
    public class PersonalContactService : IPersonalContactService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        public PersonalContactService(IUnitOfWork unitOfWork,IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public PersonalContactDto Add(CreatePersonalContactDto createPersonalContactDto)
        {
            
        }

        public PersonalContactDto Delete(PersonalContactDto personalContactDto)
        {
            throw new NotImplementedException();
        }

        public PersonalContactDto Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<PersonalContactDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public PersonalContactDto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public PersonalContactDto Update(PersonalContactDto personalContactDto)
        {
            throw new NotImplementedException();
        }
    }
}
