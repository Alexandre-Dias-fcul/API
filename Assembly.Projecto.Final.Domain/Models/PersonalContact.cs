using Assembly.Projecto.Final.Domain.Common;
using Assembly.Projecto.Final.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Domain.Models
{
    public class PersonalContact:AuditableEntity<int>
    {
        public string Name { get; private set; }
        public bool IsPrimary {  get; private set; }
        public string Notes { get; private set; }

        private List<PersonalContactDetail> _personalContactDetails;
        public IReadOnlyCollection<PersonalContactDetail> PersonalContactDetails =>
                                                                 _personalContactDetails.AsReadOnly();
        public int EmployeeId { get; private set; }
        public Employee Employee { get; private set; }

        private PersonalContact()
        {
            Name = string.Empty;
            IsPrimary = false;
            Notes = string.Empty;
            _personalContactDetails = new();
        }

        private PersonalContact(string name,bool isPrimary, string notes) : this()
        {
            DomainValidation(name, isPrimary, notes);
        }

        private PersonalContact(int id, string name, bool isPrimary, string notes) 
            : this(name,isPrimary,notes)
        {
           Id = id;
        }

        public static PersonalContact Create(string name, bool isPrimary, string notes)
        {
            var personalContact = new PersonalContact(name, isPrimary, notes);

            return personalContact;
        }

        public static PersonalContact Create(int id, string name, bool isPrimary, string notes)
        {
            var personalContact = new PersonalContact(id, name, isPrimary, notes);

            return personalContact;
        }

        public void Update(string name, bool isPrimary, string notes)
        {
            DomainValidation(name,isPrimary,notes);
        }

        public void DomainValidation(string name, bool isPrimary, string notes) 
        {

            DomainExceptionValidation.When(name == null,"Erro: o nome do contacto é obrigatório.");
            DomainExceptionValidation.When(name != null && name.Length>500," Erro: o nome do contacto não pode ter " +
                "mais de 500 caracters.");
            DomainExceptionValidation.When(notes != null && notes.Length>2000,"Erro: as notas não podem ter mais de " +
                "2000 caracteres. ");

            Name = name;
            IsPrimary = isPrimary;
            Notes = notes;
        }

        public void SetEmployee(Employee employee) 
        {
            if (employee == null)
            {
                throw new ArgumentNullException();
            }

            Employee = employee;
        }

        public void AddPersonalContactDetail(PersonalContactDetail personalContactDetail)
        {
            if(personalContactDetail == null) 
            {
                throw new ArgumentNullException();
            }

            _personalContactDetails.Add(personalContactDetail);
        }
    }
}
