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
        private readonly IPersonalContactRepository _personalContactRepository;
        public PersonalContactService(IPersonalContactRepository personalContactRepository) 
        { 
            _personalContactRepository = personalContactRepository;
        }
        public PersonalContact Add(PersonalContact personalContact)
        {
            return _personalContactRepository.Add(personalContact);
        }

        public PersonalContact Delete(PersonalContact personalContact)
        {
            return _personalContactRepository.Delete(personalContact);
        }

        public PersonalContact? Delete(int id)
        {
            return _personalContactRepository.Delete(id);
        }

        public List<PersonalContact> GetAll()
        {
            return _personalContactRepository.GetAll();
        }

        public PersonalContact? GetById(int id)
        {
            return _personalContactRepository.GetById(id);
        }

        public PersonalContact Update(PersonalContact personalContact)
        {
            return _personalContactRepository.Update(personalContact);
        }
    }
}
