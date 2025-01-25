using Assembly.Projecto.Final.Domain.Core.Repositories;
using Assembly.Projecto.Final.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Data.InMemory.Repositories
{
    public class AppointmentRepository:Repository<Appointment,int>,IAppointmentRepository
    {
        private readonly Database _db;

        public AppointmentRepository(Database db):base(db.Appointments)
        {
            _db = db;
        }
    }
}
