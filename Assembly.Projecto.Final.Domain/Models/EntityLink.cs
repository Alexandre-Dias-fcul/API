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
        public List<Contact> Contacts { get; set; }
        public List<Address> Addresses { get; set; }
        public Account Account { get; set; }
        public EntityType EntityType { get; private set; }
        public int? EntityId { get; private set; }

        public EntityLink()
        {
            EntityType = 0;
            Contacts = new List<Contact>();
            Addresses = new List<Address>();

        }

        private EntityLink(EntityType entityType, int entityId) : this()
        {
            EntityType = entityType;
            EntityId = entityId;
        }

        private EntityLink(int id, EntityType entityType, int entityId) : this(entityType, entityId)
        {
            Id = id;
            EntityId = entityId;
        }

        public static EntityLink Create(EntityType entityType, int entityId)
        {
            var entityLink = new EntityLink(entityType, entityId);

            return entityLink;
        }

        public static EntityLink Create(int id, EntityType entityType, int entityId)
        {
            var entityLink = new EntityLink(id, entityType, entityId);

            return entityLink;
        }

        public void Update(EntityType entityType, int entityId)
        {
            EntityType = entityType;
            EntityId = entityId;
        }
    }
}
