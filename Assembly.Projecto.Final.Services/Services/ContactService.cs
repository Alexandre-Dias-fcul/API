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
        private readonly IUnitOfWork _unitOfWork;
        public ContactService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        public Contact Add(Contact contactRepository)
        {
            return _unitOfWork.ContactRepository.Add(contactRepository);
        }

        public Contact Delete(Contact contact)
        {
            return _unitOfWork.ContactRepository.Delete(contact);
        }

        public Contact? Delete(int id)
        {
            return _unitOfWork.ContactRepository.Delete(id);
        }

        public List<Contact> GetAll()
        {
            return _unitOfWork.ContactRepository.GetAll();
        }

        public Contact? GetById(int id)
        {
            return _unitOfWork.ContactRepository.GetById(id);
        }

        public Contact Update(Contact contact)
        {
            return _unitOfWork.ContactRepository.Update(contact);
        }
    }
}
