using Assembly.Projecto.Final.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Domain.Models
{
    public class Account : AuditableEntity<int>
    {
        public string Password { get; private set; }
        public string Email { get; private set; }
        public int EntityLinkId { get; private set; }
        public EntityLink EntityLink { get; private set; }
        private Account()
        {
            Password = string.Empty;
            Email = string.Empty;
            Created = DateTime.Now;
        }

        private Account(string password, string email,EntityLink entityLink,int entityLinkId) : this()
        {
            Password = password;
            Email = email;
            EntityLink = entityLink;
            EntityLinkId = entityLinkId;
        }

        private Account(int id, string password, string email, EntityLink entityLink, int entityLinkId) : 
            this(password, email,entityLink,entityLinkId)
        {
            Id = id;
        }

        public static Account Create(string password, string email, EntityLink entityLink, int entityLinkId)
        {
            var account = new Account(password, email, entityLink, entityLinkId);

            return account;
        }

        public static Account Create(int id, string password, string email, EntityLink entityLink, int entityLinkId)
        {
            var account = new Account(id, password, email, entityLink, entityLinkId);

            return account;
        }


        public void Update(string password, string email, EntityLink entityLink, int entityLinkId)
        {
            Password = password;
            Email = email;
            EntityLink = entityLink;
            EntityLinkId = entityLinkId;
            Updated = DateTime.Now;
        }
    }
}
