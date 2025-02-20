using Assembly.Projecto.Final.Domain.Common;
using Assembly.Projecto.Final.Domain.Enums;
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
        public List<Contact> Contacts { get;private set; }
        public List<Address> Addresses { get; private set; }
        public Account Account { get; private set; }
        public EntityType EntityType { get; private set; }
        public int? EntityId { get; private set; }
        public Employee Employee { get; private set; }
        public User User { get; private set; }

        private EntityLink()
        {
            EntityType = 0;
            Contacts = new ();
            Addresses = new ();

        }

        private EntityLink(EntityType entityType, int? entityId) : this()
        {
            EntityType = entityType;
            EntityId = entityId;
        }

        private EntityLink(int id, EntityType entityType, int entityId) : 
            this(entityType, entityId)
        {
            Id = id;
            EntityId = entityId;
        }

        public static EntityLink Create(EntityType entityType, int entityId)
        {
            var entityLink = new EntityLink(entityType, entityId);

            return entityLink;
        }

        public static EntityLink Create(int id, EntityType entityType, int entityId, Account account)
        {
            var entityLink = new EntityLink(id, entityType, entityId);

            return entityLink;
        }

        public void Update(EntityType entityType, int entityId)
        {
            EntityType = entityType;
            EntityId = entityId;
        }

        public void SetAccount(Account account) 
        { 
            if(account == null) 
            {
                throw new ArgumentNullException();
            }
                
            Account = account;
        }

        public void SetEmplyee(Employee employee) 
        {
            if(employee == null)
            {
                throw new ArgumentNullException();
            }

            Employee = employee;
        }

        public void SetUser(User user) 
        {
            if(user == null) 
            {
                throw new ArgumentNullException();
            }

            User = user;
        }
    }
}
