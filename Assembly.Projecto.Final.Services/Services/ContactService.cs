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
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        public ContactService(IContactRepository contactRepository) 
        {
            _contactRepository = contactRepository;
        }
        public Contact Add(Contact contactRepository)
        {
            return _contactRepository.Add(contactRepository);
        }

        public Contact Delete(Contact contact)
        {
            return _contactRepository.Delete(contact);
        }

        public Contact? Delete(int id)
        {
            return _contactRepository.Delete(id);
        }

        public List<Contact> GetAll()
        {
            return _contactRepository.GetAll();
        }

        public Contact? GetById(int id)
        {
            return _contactRepository.GetById(id);
        }

        public Contact Update(Contact contact)
        {
            return _contactRepository.Update(contact);
        }
    }
}
