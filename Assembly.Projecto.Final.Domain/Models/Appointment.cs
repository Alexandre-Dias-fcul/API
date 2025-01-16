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
        public DateTime DateStart { get; private set; }
        public DateTime DateEnd { get; private set; }
        public TimeOnly HourStart { get; private set; }
        public TimeOnly HourEnd { get; private set; }
        public int BookedBy { get; private set; }

        public Appointment()
        {
            Type = string.Empty;
            Description = string.Empty;
            DateStart = DateTime.MinValue;
            DateEnd = DateTime.MinValue;
            HourStart = new TimeOnly();
            HourEnd = new TimeOnly();
            BookedBy = 0;
            Created= DateTime.Now;
        }

        private Appointment(string type,string description,DateTime dateStart,DateTime dateEnd,TimeOnly hourStart,
            TimeOnly hourEnd,int bookedBy):this() 
        {   
            Type = type;
            Description = description;
            DateStart = dateStart;
            DateEnd = dateEnd;
            HourStart = hourStart;
            HourEnd = hourEnd;
            BookedBy = bookedBy;
        }

        public static Appointment Create(string type, string description, DateTime dateStart, DateTime dateEnd, TimeOnly hourStart,
            TimeOnly hourEnd, int bookedBy) 
        {
            var appointment = new Appointment(type,description,dateStart,dateEnd,hourStart,hourEnd,bookedBy);

            return appointment;
        }

        public void Update(string type, string description, DateTime dateStart, DateTime dateEnd, TimeOnly hourStart,
           TimeOnly hourEnd, int bookedBy)
        {
            Type = type;
            Description = description;
            DateStart = dateStart;
            DateEnd = dateEnd;
            HourStart = hourStart;
            HourEnd = hourEnd;
            BookedBy = bookedBy;
            Updated = DateTime.UtcNow;
        }
    }
}
