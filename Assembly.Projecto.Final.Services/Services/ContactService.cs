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
    public class ContactService : IContactService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        public ContactService(IUnitOfWork unitOfWork,IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public ContactDto Add(CreateContactDto createContactDto)
        {
            Contact addedContact;

            using(_unitOfWork) 
            {
                _unitOfWork.BeginTransaction();

                var contact = Contact.Create(createContactDto.ContactType,createContactDto.Value);

                addedContact =_unitOfWork.ContactRepository.Add(contact);

                _unitOfWork.Commit();
            }

            return _mapper.Map<ContactDto>(addedContact);
        }

        public ContactDto Delete(ContactDto contactDto)
        {
            Contact deletedContact;

            using (_unitOfWork) 
            {
                _unitOfWork.BeginTransaction();

                var foundedContact = _unitOfWork.ContactRepository.GetById(contactDto.Id);

                if(foundedContact is null) 
                {
                    throw new ArgumentNullException(nameof(foundedContact), "Não foi encontrado.");
                }

                deletedContact = _unitOfWork.ContactRepository.Delete(foundedContact);

                _unitOfWork.Commit();
            }

            return _mapper.Map<ContactDto>(deletedContact);
        }

        public ContactDto Delete(int id)
        {
            Contact deletedContact;

            using(_unitOfWork) 
            {
                _unitOfWork.BeginTransaction();

                var foundedContact = _unitOfWork.ContactRepository.GetById(id);

                if (foundedContact is null)
                {
                    throw new ArgumentNullException(nameof(foundedContact), "Não foi encontrado.");
                }

                deletedContact = _unitOfWork.ContactRepository.Delete(id);

                _unitOfWork.Commit();
            }

            return _mapper.Map<ContactDto>(deletedContact);
        }

        public List<ContactDto> GetAll()
        {

            var list = new List<ContactDto>();

            foreach(var contact in _unitOfWork.ContactRepository.GetAll()) 
            {
                var contactDto = _mapper.Map<ContactDto>(contact);

                list.Add(contactDto);
            }

            return list; 
        }

        public ContactDto GetById(int id)
        {
            var contact = _unitOfWork.ContactRepository.GetById(id);

            return _mapper.Map<ContactDto>(contact);
        }

        public ContactDto Update(ContactDto contactDto)
        {
            Contact updatedContact;

            using (_unitOfWork) 
            {
                _unitOfWork.BeginTransaction();

                var foundedContact = _unitOfWork.ContactRepository.GetById(contactDto.Id);

                if (foundedContact is null)
                {
                    throw new ArgumentNullException(nameof(foundedContact), "Não foi encontrado.");
                }

                foundedContact.Update(contactDto.ContactType,contactDto.Value);

                updatedContact = _unitOfWork.ContactRepository.Update(foundedContact);

                _unitOfWork.Commit();
            }

            return _mapper.Map<ContactDto>(updatedContact);
        }
    }
}
