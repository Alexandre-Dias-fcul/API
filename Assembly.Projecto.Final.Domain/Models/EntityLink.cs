using Assembly.Projecto.Final.Domain.Common;
using Assembly.Projecto.Final.Domain.Enums;
using Assembly.Projecto.Final.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Domain.Models
{
    public class EntityLink : AuditableEntity<int>
    {
        private List<Contact> _contacts;
        public IReadOnlyCollection<Contact> Contacts => _contacts.AsReadOnly();

        private List<Address> _addresses;
        public IReadOnlyCollection<Address> Addresses => _addresses.AsReadOnly();
        public Account Account { get; private set; }
        public EntityType EntityType { get; private set; }
        public int? EntityId { get; private set; }
        public Employee Employee { get; private set; }
        public User User { get; private set; }

        private EntityLink()
        {
            EntityType = 0;
            EntityId = 0;
            _contacts = new();
            _addresses = new();


        }

        private EntityLink(EntityType entityType, int? entityId) : this()
        {
            DomainValidation(entityType, entityId);
        }

        private EntityLink(int id, EntityType entityType, int? entityId) :
            this(entityType, entityId)
        {
            Id = id;
        }

        public static EntityLink Create(EntityType entityType, int? entityId)
        {
            var entityLink = new EntityLink(entityType, entityId);

            return entityLink;
        }

        public static EntityLink Create(int id, EntityType entityType, int? entityId)
        {
            var entityLink = new EntityLink(id, entityType, entityId);

            return entityLink;
        }

        public void Update(EntityType entityType, int? entityId)
        {
            DomainValidation(entityType, entityId);
        }

        public void DomainValidation(EntityType entityType, int? entityId)
        {
            DomainExceptionValidation.When(entityId == null || entityId == 0, "Erro: o campo é obrigatório.");

            EntityType = entityType;
            EntityId = entityId;
        }
        public void SetAccount(Account account)
        {
            DomainExceptionValidation.When(account == null, $"Erro: Não foi encontrada a entidade {nameof(account)}.");

            Account = account;
        }

        public void SetEmplyee(Employee employee)
        {
            DomainExceptionValidation.When(employee == null, $"Erro: Não foi encontrada a entidade {nameof(employee)}.");

            Employee = employee;
        }

        public void SetUser(User user)
        {
            DomainExceptionValidation.When(user == null, $"Erro: Não foi encontrada a entidade {nameof(user)}.");

            User = user;
        }

        public void AddAddress(Address address)
        {
            DomainExceptionValidation.When(address == null, $"Erro: Não foi encontrada a entidade {nameof(address)}.");

            _addresses.Add(address);
        }

        public void AddContact(Contact contact)
        {
            DomainExceptionValidation.When(contact == null, $"Erro: Não foi encontrada a entidade {nameof(contact)}.");

            _contacts.Add(contact);
        }

        public void RemoveAccount()
        {
            DomainExceptionValidation.When(Account == null, $"Erro: Não foi encontrada a entidade {nameof(Account)}.");

            Account.Delete();
        }

        public void RemoveAddress(Address address)
        {
            DomainExceptionValidation.When(address == null, $"Erro: Não foi encontrada a entidade {nameof(address)}.");

            DomainExceptionValidation.When(!_addresses.Contains(address), $"Erro: A entidade {nameof(address)} não está associada a este link.");

            _addresses.Remove(address);
        }

        public void RemoveContact(Contact contact)
        {
            DomainExceptionValidation.When(contact == null, $"Erro: Não foi encontrada a entidade {nameof(contact)}.");

            DomainExceptionValidation.When(!_contacts.Contains(contact), $"Erro: A entidade {nameof(contact)} não está associada a este link.");

            _contacts.Remove(contact);
        }
    }
}
