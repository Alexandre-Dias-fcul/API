﻿using Assembly.Projecto.Final.Domain.Common;
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
        public byte[] PasswordHash { get; private set; }
        public byte[] PasswordSalt { get; private set; }
        public string Email { get; private set; }
        public int EntityLinkId { get; private set; }
        public EntityLink EntityLink { get; private set; }
        private Account()
        {
           
            Email = string.Empty;
        }

        private Account(byte[] passwordHash,byte[] passwordSalt, string email) : this()
        {
            DomainValidation(passwordHash, passwordSalt,email);
        }

        private Account(int id, byte[] passwordHash,byte[] passwordSalt, string email) : 
            this(passwordHash,passwordSalt, email)
        {
            Id = id;
        }

        public static Account Create(byte[] passwordHash, byte[] passwordSalt, string email)
        {
            var account = new Account(passwordHash, passwordSalt, email);

            return account;
        }

        public static Account Create(int id, byte[] passwordHash, byte[] passwordSalt, string email)
        {
            var account = new Account(id, passwordHash,passwordSalt, email);

            return account;
        }

        public void Update(byte[] passwordHash, byte[] passwordSalt, string email)
        {
            DomainValidation(passwordHash,passwordSalt, email);
        }

        public void DomainValidation(byte[] passwordHash, byte[] passwordSalt, string email) 
        {
            DomainExceptionValidation.When(passwordHash == null,"Erro: a passwordHash é obrigatória.");
            DomainExceptionValidation.When(passwordHash != null && passwordHash.Length>500, "Erro: a passwordHash " +
                "não pode ter mais de 500 caracteres.");
            DomainExceptionValidation.When(passwordSalt == null, "Erro: a passwordSalt é obrigatória.");
            DomainExceptionValidation.When(passwordSalt != null && passwordSalt.Length > 500, "Erro: a passwordSalt " +
                "não pode ter mais de 500 caracteres.");
            DomainExceptionValidation.When(email == null, "Erro: o email é obrigatório.");
            DomainExceptionValidation.When(email != null && email.Length > 300, "Erro: o email não pode ter " +
                "mais de 300 caracteres.");

            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
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
