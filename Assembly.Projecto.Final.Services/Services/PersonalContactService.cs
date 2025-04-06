using Assembly.Projecto.Final.Domain.Common;
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
            PersonalContact addedPersonalContact;

            using (_unitOfWork) 
            {

                var personalContact = PersonalContact.Create(createPersonalContactDto.Name,
                    createPersonalContactDto.IsPrimary,createPersonalContactDto.Notes);

                Employee employee;

                if(createPersonalContactDto.Role is null) 
                {
                    employee = _unitOfWork.StaffRepository.GetById(createPersonalContactDto.EmployeeId);
                }
                else 
                {
                    employee = _unitOfWork.AgentRepository.GetById(createPersonalContactDto.EmployeeId);
                }

                NotFoundException.When(employee is null,$"{nameof(employee)} não foi encontrado.");

                personalContact.SetEmployee(employee);

                addedPersonalContact = _unitOfWork.PersonalContactRepository.Add(personalContact);

                _unitOfWork.Commit();
            }

            return _mapper.Map<PersonalContactDto>(addedPersonalContact);
        }

        public PersonalContactDto Delete(PersonalContactDto personalContactDto)
        {
            PersonalContact deletedPersonalContact;

            using (_unitOfWork) 
            {

                var foundedPersonalContact = _unitOfWork.PersonalContactRepository.Delete(personalContactDto.Id);

                NotFoundException.When(foundedPersonalContact is null, 
                    $"{nameof(foundedPersonalContact)} não foi encontrado.");

                deletedPersonalContact =_unitOfWork.PersonalContactRepository.Delete(foundedPersonalContact);

                _unitOfWork.Commit();
            }

            return _mapper.Map<PersonalContactDto>(deletedPersonalContact);
        }

        public PersonalContactDto Delete(int id)
        {
            PersonalContact deletedPersonalContact;

            using (_unitOfWork)
            {
                var foundedPersonalContact = _unitOfWork.PersonalContactRepository.Delete(id);

                NotFoundException.When(foundedPersonalContact is null,
                    $"{nameof(foundedPersonalContact)} não foi encontrado.");

                deletedPersonalContact = _unitOfWork.PersonalContactRepository.Delete(id);

                _unitOfWork.Commit();
            }

            return _mapper.Map<PersonalContactDto>(deletedPersonalContact);
        }

        public List<PersonalContactDto> GetAll()
        {
            var list = new List<PersonalContactDto>();

            foreach (var personalContact in _unitOfWork.PersonalContactRepository.GetAll()) 
            {
                var personalContactDto = _mapper.Map<PersonalContactDto>(personalContact);

                list.Add(personalContactDto);
            }

            return list;
        }

        public PersonalContactDto GetById(int id)
        {
            var personalContact = _unitOfWork.PersonalContactRepository.GetById(id);

            return _mapper.Map<PersonalContactDto>(personalContact);
        }

        public PersonalContactDto Update(PersonalContactDto personalContactDto)
        {
            PersonalContact updatedPersonalContact;

            using (_unitOfWork)
            {

                var foundedPersonalContact = _unitOfWork.PersonalContactRepository.Delete(personalContactDto.Id);

                NotFoundException.When(foundedPersonalContact is null,
                    $"{nameof(foundedPersonalContact)} não foi encontrado.");

                foundedPersonalContact.Update(personalContactDto.Name,personalContactDto.IsPrimary,
                    personalContactDto.Notes);

                updatedPersonalContact = _unitOfWork.PersonalContactRepository.Update(foundedPersonalContact);

                _unitOfWork.Commit();
            }

            return _mapper.Map<PersonalContactDto>(updatedPersonalContact);
        }
    }
}
