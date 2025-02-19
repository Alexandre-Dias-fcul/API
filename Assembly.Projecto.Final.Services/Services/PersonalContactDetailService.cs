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
        private readonly IPersonalContactDetailRepository _personalContactDetailRepository;
        public PersonalContactDetailService(IPersonalContactDetailRepository personalContactDetailRepository) 
        {
            _personalContactDetailRepository = personalContactDetailRepository;
        }
        public PersonalContactDetail Add(PersonalContactDetail personalContactDetail)
        {
            return _personalContactDetailRepository.Add(personalContactDetail);
        }

        public PersonalContactDetail Delete(PersonalContactDetail personalContactDetail)
        {
            return _personalContactDetailRepository.Delete(personalContactDetail);
        }

        public PersonalContactDetail? Delete(int id)
        {
            return _personalContactDetailRepository.Delete(id);
        }

        public List<PersonalContactDetail> GetAll()
        {
            return _personalContactDetailRepository.GetAll();
        }

        public PersonalContactDetail? GetById(int id)
        {
             return _personalContactDetailRepository.GetById(id);
        }

        public PersonalContactDetail Update(PersonalContactDetail personalContactDetail)
        {
             return _personalContactDetailRepository.Update(personalContactDetail);
        }
    }
}
