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
    public class PersonalContactService : IPersonalContactService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PersonalContactService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        public PersonalContact Add(PersonalContact personalContact)
        {
            return _unitOfWork.PersonalContactRepository.Add(personalContact);
        }

        public PersonalContact Delete(PersonalContact personalContact)
        {
            return _unitOfWork.PersonalContactRepository.Delete(personalContact);
        }

        public PersonalContact? Delete(int id)
        {
            return _unitOfWork.PersonalContactRepository.Delete(id);
        }

        public List<PersonalContact> GetAll()
        {
            return _unitOfWork.PersonalContactRepository.GetAll();
        }

        public PersonalContact? GetById(int id)
        {
            return _unitOfWork.PersonalContactRepository.GetById(id);
        }

        public PersonalContact Update(PersonalContact personalContact)
        {
            return _unitOfWork.PersonalContactRepository.Update(personalContact);
        }
    }
}
