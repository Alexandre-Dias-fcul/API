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

        public PersonalContactDetailDto Add(CreatePersonalContactDetailDto createPersonalContactDetailDto)
        {
            PersonalContactDetail addedPersonalContactDetail;

            using(_unitOfWork) 
            {
                _unitOfWork.BeginTransaction();

                var personalContactDetail = PersonalContactDetail.Create(createPersonalContactDetailDto.ContactType,
                    createPersonalContactDetailDto.Value);

                addedPersonalContactDetail = _unitOfWork.PersonalContactDetailRepository.Add(personalContactDetail);

                _unitOfWork.Commit();
            }

            return _mapper.Map<PersonalContactDetailDto>(addedPersonalContactDetail);
        }

        public PersonalContactDetailDto Delete(PersonalContactDetailDto personalContactDetailDto)
        {
            PersonalContactDetail deletedPersonalContactDetail;

            using (_unitOfWork) 
            {
                _unitOfWork.BeginTransaction();

                var foundedPersonalContactDetail = _unitOfWork.PersonalContactDetailRepository
                        .GetById(personalContactDetailDto.Id);

                if(foundedPersonalContactDetail is null) 
                {
                    throw new ArgumentNullException(nameof(foundedPersonalContactDetail), "Não foi encontrado.");
                }

                deletedPersonalContactDetail = _unitOfWork.PersonalContactDetailRepository
                       .Delete(foundedPersonalContactDetail);

                _unitOfWork.Commit();
            }

            return _mapper.Map<PersonalContactDetailDto>(deletedPersonalContactDetail);
        }

        public PersonalContactDetailDto Delete(int id)
        {
            PersonalContactDetail deletedPersonalContactDetail;

            using (_unitOfWork)
            {
                _unitOfWork.BeginTransaction();

                var foundedPersonalContactDetail = _unitOfWork.PersonalContactDetailRepository.GetById(id);

                if (foundedPersonalContactDetail is null)
                {
                    throw new ArgumentNullException(nameof(foundedPersonalContactDetail), "Não foi encontrado.");
                }

                deletedPersonalContactDetail = _unitOfWork.PersonalContactDetailRepository.Delete(id);

                _unitOfWork.Commit();
            }

            return _mapper.Map<PersonalContactDetailDto>(deletedPersonalContactDetail);
        }

        public List<PersonalContactDetailDto> GetAll()
        {
            var list = new List<PersonalContactDetailDto>();

            foreach(var personalContactDetail in _unitOfWork.PersonalContactDetailRepository.GetAll()) 
            {
                var personalContactDetailDto = _mapper.Map<PersonalContactDetailDto>(personalContactDetail);

                list.Add(personalContactDetailDto);
            }

            return list;
        }

        public PersonalContactDetailDto GetById(int id)
        {
            var personalContactDetail = _unitOfWork.PersonalContactDetailRepository.GetById(id);

            return _mapper.Map<PersonalContactDetailDto>(personalContactDetail);
        }

        public PersonalContactDetailDto Update(PersonalContactDetailDto personalContactDetailDto)
        {
            PersonalContactDetail updatedPersonalContactDetail;

            using (_unitOfWork)
            {
                _unitOfWork.BeginTransaction();

                var foundedPersonalContactDetail = _unitOfWork.PersonalContactDetailRepository.GetById(id);

                if (foundedPersonalContactDetail is null)
                {
                    throw new ArgumentNullException(nameof(foundedPersonalContactDetail), "Não foi encontrado.");
                }

                foundedPersonalContactDetail.Update(personalContactDetailDto.ContactType,
                    personalContactDetailDto.Value);

                updatedPersonalContactDetail = _unitOfWork.PersonalContactDetailRepository
                         .Update(foundedPersonalContactDetail);

                _unitOfWork.Commit();
            }

            return _mapper.Map<PersonalContactDetailDto>(updatedPersonalContactDetail);
        }
    }
}
