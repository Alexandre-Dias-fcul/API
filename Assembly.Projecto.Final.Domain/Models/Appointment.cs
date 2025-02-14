using Assembly.Projecto.Final.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Domain.Models
{
    public class Appointment:AuditableEntity<int>
    {
        public string Type { get; private set; }
        public string Description { get; private set; }
        public DateTime Date { get; private set; }
        public TimeOnly HourStart { get; private set; }
        public TimeOnly HourEnd { get; private set; }
        public string Status { get; private set; }
        public int BookedBy { get; private set; }
        public List<Participant> Participants { get; private set; }

        public Appointment()
        {
            Type = string.Empty;
            Description = string.Empty;
            Date = DateTime.MinValue;
            HourStart = new TimeOnly();
            HourEnd = new TimeOnly();
            Status = string.Empty;
            BookedBy = 0;
            Participants = new (); 
            Created= DateTime.Now;
        }

        private Appointment(string type,string description,DateTime date,TimeOnly hourStart,TimeOnly hourEnd,
            string status,int bookedBy):this() 
        {   
            Type = type;
            Description = description;
            Date = date;
            HourStart = hourStart;
            HourEnd = hourEnd;
            Status = status;
            BookedBy = bookedBy;
        }

        private Appointment(int id,string type, string description, DateTime date, TimeOnly hourStart,TimeOnly hourEnd,
           String status,int bookedBy) : this(type,description,date,hourStart,hourEnd,status,bookedBy)
        {
            Id = Id;
        }

        public static Appointment Create(string type, string description, DateTime date, TimeOnly hourStart,
            TimeOnly hourEnd,string status, int bookedBy) 
        {
            var appointment = new Appointment(type,description,date,hourStart,hourEnd,status,bookedBy);

            return appointment;
        }

        public static Appointment Create(int id,string type, string description, DateTime date, 
            TimeOnly hourStart,TimeOnly hourEnd, string status,int bookedBy)
        {
            var appointment = new Appointment(id,type, description, date, hourStart, hourEnd,status, bookedBy);

            return appointment;
        }

        public void Update(string type, string description, DateTime date, TimeOnly hourStart, TimeOnly hourEnd, 
            string status, int bookedBy)
        {
            Type = type;
            Description = description;
            Date = date;
            HourStart = hourStart;
            HourEnd = hourEnd;
            BookedBy = bookedBy;
            Status = status;
            Updated = DateTime.Now;
        }
    }
}
