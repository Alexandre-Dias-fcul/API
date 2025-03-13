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
    public class PersonalContactDetailService : IPersonalContactDetailService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PersonalContactDetailService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        public PersonalContactDetail Add(PersonalContactDetail personalContactDetail)
        {
            return _unitOfWork.PersonalContactDetailRepository.Add(personalContactDetail);
        }

        public PersonalContactDetail Delete(PersonalContactDetail personalContactDetail)
        {
            return _unitOfWork.PersonalContactDetailRepository.Delete(personalContactDetail);
        }

        public PersonalContactDetail? Delete(int id)
        {
            return _unitOfWork.PersonalContactDetailRepository.Delete(id);
        }

        public List<PersonalContactDetail> GetAll()
        {
            return _unitOfWork.PersonalContactDetailRepository.GetAll();
        }

        public PersonalContactDetail? GetById(int id)
        {
             return _unitOfWork.PersonalContactDetailRepository.GetById(id);
        }

        public PersonalContactDetail Update(PersonalContactDetail personalContactDetail)
        {
             return _unitOfWork.PersonalContactDetailRepository.Update(personalContactDetail);
        }
    }
}
