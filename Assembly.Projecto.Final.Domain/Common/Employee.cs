using Assembly.Projecto.Final.Domain.Enums;
using Assembly.Projecto.Final.Domain.Interfaces;
using Assembly.Projecto.Final.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Assembly.Projecto.Final.Domain.Common
{
    public abstract class Employee:Person
    {
        public DateTime? HiredDate { get; private set; }
        public DateTime? DateOfTermination { get; private set; }
        public int? EntityLinkId { get; private set; }
        public EntityLink? EntityLink { get; private set; }

        private List<PersonalContact> _personalContacts;
        public IReadOnlyCollection<PersonalContact> PersonalContacts => _personalContacts.AsReadOnly();

        private List<Participant> _participants;
        public IReadOnlyCollection<Participant> Participants => _participants.AsReadOnly();

        protected Employee():base()
        {
            HiredDate = DateTime.MinValue;
            DateOfTermination = DateTime.MinValue;
            EntityLinkId = 0;
        }

        protected Employee(Name name, DateTime dateOfBirth, string gender, string photoFileName, bool isActive,
            DateTime hiredDate, DateTime dateOfTermination) : 
            base(name, dateOfBirth, gender, photoFileName,isActive)
        {
            HiredDate = hiredDate;
            DateOfTermination = dateOfTermination;
            _personalContacts = new();
            _participants = new ();
        }

        protected Employee(int id, Name name, DateTime dateOfBirth, string gender, string photoFileName, bool isActive,
           DateTime hiredDate, DateTime dateOfTermination) : 
            base(id, name, dateOfBirth, gender,photoFileName, isActive)
        {
            HiredDate = hiredDate;
            DateOfTermination = dateOfTermination;
            _personalContacts = new ();
            _participants = new ();
        }
        protected Employee(string firstName, string middleNames, string lastName, DateTime dateOfBirth, string gender,
            string photoFileName, bool isActive, DateTime hiredDate, DateTime dateOfTermination) :
            base(firstName, middleNames, lastName, dateOfBirth, gender, photoFileName, isActive)
        {
            HiredDate = hiredDate;
            DateOfTermination = dateOfTermination;
            _personalContacts = new ();
            _participants = new ();
        }

        protected Employee(int id, string firstName, string middleNames, string lastName, DateTime dateOfBirth,
           string gender, string photoFileName, bool isActive, DateTime hiredDate, DateTime dateOfTermination) :
            base(id, firstName, middleNames, lastName, dateOfBirth, gender, photoFileName, isActive)
        {
            HiredDate = hiredDate;
            DateOfTermination = dateOfTermination;
            _personalContacts = new ();
            _participants = new ();
        }

        public void Update(Name name, DateTime dateOfBirth, string gender, string photoFileName, bool isActive,
            DateTime hiredDate, DateTime dateOfTermination)
        {
            base.Update(name, dateOfBirth, gender, photoFileName, isActive);
            HiredDate = hiredDate;
            DateOfTermination = dateOfTermination;
        }

        public void Update(string firstName, string middleNames, string lastName, DateTime dateOfBirth, string gender,
            string photoFileName, bool isActive, DateTime hiredDate, DateTime dateOfTermination)
        {
            base.Update(firstName, middleNames, lastName, dateOfBirth, gender, photoFileName, isActive);
            HiredDate = hiredDate;
            DateOfTermination = dateOfTermination;
        }

        public void SetEntityLink(EntityLink entityLink) 
        {
            if(entityLink == null) 
            {
                throw new ArgumentNullException();
            }

            EntityLink = entityLink;
            EntityLinkId = entityLink.Id;
        }

        public void AddParticipant(Participant participant)
        {
            if (participant == null)
            {
                throw new ArgumentNullException();
            }

            _participants.Add(participant);
        }

        public void AddPersonalContact(PersonalContact personalContact) 
        {
            if(personalContact == null) 
            { 
                throw new InvalidOperationException();
            }

            _personalContacts.Add(personalContact);
        }
    }
}
