using Assembly.Projecto.Final.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Domain.Core.Repositories
{
    public interface IStaffRepository:IRepository<Staff,int>
    {
        public Staff? GetByIdWithAddresses(int id);

        public Staff? GetByIdWithAccount(int id);

        public Staff? GetByIdWithContacts(int id);

        public Staff? GetByIdWithAll(int id);

        public Staff? GetByIdWithPersonalContacts(int id);

        public Staff? GetByIdWithParticipants(int id);
    }
}
