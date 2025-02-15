using Assembly.Projecto.Final.Domain.Common;
using Assembly.Projecto.Final.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
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

        private EntityLink()
        {
            EntityType = 0;
            Contacts = new ();
            Addresses = new ();

        }

        private EntityLink(EntityType entityType, int? entityId, Account account) : this()
        {
            EntityType = entityType;
            EntityId = entityId;
            Account = account;
        }

        private EntityLink(int id, EntityType entityType, int entityId, Account account) : 
            this(entityType, entityId,account)
        {
            Id = id;
            EntityId = entityId;
            Account = account;
        }

        public static EntityLink Create(EntityType entityType, int entityId, Account account)
        {
            var entityLink = new EntityLink(entityType, entityId,account);

            return entityLink;
        }

        public static EntityLink Create(int id, EntityType entityType, int entityId, Account account)
        {
            var entityLink = new EntityLink(id, entityType, entityId,account);

            return entityLink;
        }

        public void Update(EntityType entityType, int entityId, Account account)
        {
            EntityType = entityType;
            EntityId = entityId;
            Account = account;
        }
    }
}
