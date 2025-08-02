using Assembly.Projecto.Final.Domain.Common;
using Assembly.Projecto.Final.Domain.Enums;
using Assembly.Projecto.Final.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Domain.Models
{
    public class PersonalContactDetail : AuditableEntity<int>
    {
        public ContactType ContactType { get; private set; }
        public string Value { get; private set; }
        public int PersonalContactId { get; private set; }
        public PersonalContact PersonalContact { get; private set; }

        private PersonalContactDetail()
        {
            ContactType = 0;
            Value = string.Empty;
        }

        private PersonalContactDetail(ContactType contactType, string value) : this()
        {
            DomainValidation(contactType, value);
        }

        private PersonalContactDetail(int id, ContactType contactType, string value) : this(contactType, value)
        {
            Id = Id;
        }
        public static PersonalContactDetail Create(ContactType contactType, string value)
        {
            var personalContactDetail = new PersonalContactDetail(contactType, value);

            return personalContactDetail;
        }

        public static PersonalContactDetail Create(int id, ContactType contactType, string value)
        {
            var personalContactDetail = new PersonalContactDetail(id, contactType, value);

            return personalContactDetail;
        }

        public void Update(ContactType contactType, string value)
        {
            DomainValidation(contactType, value);
        }

        public void DomainValidation(ContactType contactType, string value) 
        {
            DomainExceptionValidation.When(value == null,"Erro: o contacto é obrigatório.");
            DomainExceptionValidation.When(value != null && value.Length>300,"Erro: o contacto não pode ter mais de " +
                "300 caracteres.");
            DomainExceptionValidation.When(contactType == ContactType.Email && !EmailValido(value),
                "Erro: o email informado é inválido.");
            DomainExceptionValidation.When(contactType == ContactType.Phone && !IsValidEuPhoneNumber(value),
                "Erro: o número de telefone informado é inválido. Deve ser um número válido da União Europeia.");

            ContactType = contactType;
            Value = value;
        }

        public void SetPersonalContact(PersonalContact personalContact) 
        {
            DomainExceptionValidation.When(personalContact == null, 
                $"Erro: Não foi encontrada a entidade {nameof(personalContact)}.");

            PersonalContact = personalContact;
            PersonalContactId = personalContact.Id;
        }

        private static bool EmailValido(string email)
        {
            if ((email == null) || (email.Length < 4))
                return false;

            var partes = email.Split('@');
            if (partes.Length < 2) return false;

            var pre = partes[0];

            if (pre.Length == 0) return false;

            var validadorPre = new Regex("^[a-zA-Z0-9_.-/+]+$");

            if (!validadorPre.IsMatch(pre))
                return false;

            // gmail.com, outlook.com, terra.com.br, etc.
            var partesDoDominio = partes[1].Split('.');
            if (partesDoDominio.Length < 2) return false;

            var validadorDominio = new Regex("^[a-zA-Z0-9-]+$");
            for (int indice = 0; indice < partesDoDominio.Length; indice++)
            {
                var parteDoDominio = partesDoDominio[indice];

                // Evitando @gmail...com
                if (parteDoDominio.Length == 0) return false;

                if (!validadorDominio.IsMatch(parteDoDominio))
                    return false;
            }

            return true;
        }

        private static readonly string[] EuCountryCodes = {
        "+30", "+31", "+32", "+33", "+34", "+35", "+36", "+39", "+40", "+41",
        "+43", "+44", "+45", "+46", "+47", "+48", "+49", "+351", "+352", "+353",
        "+354", "+355", "+356", "+357", "+358", "+359"
        };

        private static bool IsValidEuPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return false;

            // Remove espaços, hífens, parênteses
            var cleaned = Regex.Replace(phoneNumber, @"[\s\-\(\)]", "");

            // Verifica se começa com um prefixo válido da UE
            bool startsWithEuPrefix = false;
            foreach (var code in EuCountryCodes)
            {
                if (cleaned.StartsWith(code))
                {
                    startsWithEuPrefix = true;
                    cleaned = cleaned.Substring(code.Length); // remove o prefixo
                    break;
                }
            }

            if (!startsWithEuPrefix)
                return false;

            // Verifica se o resto são apenas dígitos e o comprimento razoável
            return Regex.IsMatch(cleaned, @"^\d{6,12}$");
        }
    }
}
