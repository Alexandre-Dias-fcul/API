using Assembly.Projecto.Final.Domain.Common;
using Assembly.Projecto.Final.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Domain.Models
{
    public class Address: AuditableEntity<int>
    {
        public string Street { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }
        public string PostalCode { get; private set; }

        private List<EntityLink> _entityLinks;
        public IReadOnlyCollection<EntityLink> EntityLinks => _entityLinks.AsReadOnly();

        private Address()
        {
            Street = string.Empty;
            City = string.Empty;
            Country = string.Empty;
            PostalCode = string.Empty;
            _entityLinks = new ();
        }

        private Address(string street, string city, string country, string postalCode) : this()
        {
            DomainValidation(street, city, country, postalCode);
        }

        private Address(int id, string street, string city, string country, string postalCode) :
            this(street, city, country, postalCode)
        {
            Id = id;
        }
        public static Address Create(string street, string city, string country, string postalCode)
        {
            var address = new Address(street, city, country, postalCode);

            return address;
        }

        public static Address Create(int id, string street, string city, string country, string postalCode)
        {
            var address = new Address(id, street, city, country, postalCode);

            return address;
        }

        public void Update(string street, string city, string country, string postalCode)
        {
            DomainValidation(street,city,country,postalCode);
        }

        public void DomainValidation(string street, string city, string country, string postalCode) 
        {
            DomainExceptionValidation.When(street == null, "Erro: o nome da rua é obrigatória.");
            DomainExceptionValidation.When(street != null && street.Length > 200, "Erro: o nome da rua não pode ter " +
                "mais de 200 caracteres.");
            DomainExceptionValidation.When(city == null, "Erro: o nome da cidade é obrigatória.");
            DomainExceptionValidation.When(city != null && city.Length>200, "Erro: o nome da cidade não pode ter " +
                "mais de 200 caracteres.");
            DomainExceptionValidation.When(country == null, "Erro: o nome do país é obrigatório.");
            DomainExceptionValidation.When(country != null && country.Length > 200, "Erro: o nome do país não pode " +
                "ter mais de 200 caracteres.");
            DomainExceptionValidation.When(postalCode == null, "Erro: o código postal é obrigatório.");
            DomainExceptionValidation.When(postalCode != null && postalCode.Length>10, "Erro: o código postal não " +
                "pode ter mais de 10 caracteres.");

            Street = street;
            City = city;
            Country = country;
            PostalCode = postalCode;
        }
        public void AddEntityLink(EntityLink entityLink) 
        {
            if (entityLink == null)
            {
                throw new ArgumentNullException();
            }

            _entityLinks.Add(entityLink);
        }
    }
}
