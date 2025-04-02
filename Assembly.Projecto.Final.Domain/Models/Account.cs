using Assembly.Projecto.Final.Domain.Common;
using Assembly.Projecto.Final.Domain.Validations;
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
        }

        private Account(string password, string email) : this()
        {
            DomainValidation(password, email);
        }

        private Account(int id, string password, string email) : 
            this(password, email)
        {
            Id = id;
        }

        public static Account Create(string password, string email)
        {
            var account = new Account(password, email);

            return account;
        }

        public static Account Create(int id, string password, string email)
        {
            var account = new Account(id, password, email);

            return account;
        }

        public void Update(string password, string email)
        {
            DomainValidation(password, email);
        }

        public void DomainValidation(string password, string email) 
        {
            DomainExceptionValidation.When(password == null,"Erro: a password é obrigatória.");
            DomainExceptionValidation.When(password != null && password.Length>500, "Erro: a password não pode ter " +
                "mais de 500 caracteres.");
            DomainExceptionValidation.When(email == null, "Erro: o email é obrigatório.");
            DomainExceptionValidation.When(email != null && email.Length > 300, "Erro: o email não pode ter " +
                "mais de 300 caracteres.");

            Password = password;
            Email = email;
        }
        public void SetEntityLink(EntityLink entityLink)
        {
            DomainExceptionValidation.When(entityLink == null, $"Erro: Não foi encontrada a entidade {nameof(entityLink)}.");

            EntityLink = entityLink;
            EntityLinkId = entityLink.Id;
        }
    }
}
