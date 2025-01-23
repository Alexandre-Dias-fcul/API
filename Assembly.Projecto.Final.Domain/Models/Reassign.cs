using Assembly.Projecto.Final.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Domain.Models
{
    public class Reassign : AuditableEntity<int>
    {
        public int OlderEmployeeId { get; private set; }
        public int NewEmployeeId { get; private set; }
        public int ReassignBy { get; private set; }
        public DateTime ReassignmentDate { get; private set; }
        public Listing Listing { get;  set; }

        private Reassign() 
        {
            OlderEmployeeId = 0;
            NewEmployeeId = 0;
            ReassignBy = 0;
            ReassignmentDate = DateTime.MinValue;
            Created = DateTime.MinValue;
        }

        private Reassign(int olderEmplyeeId,int newEmployeeId,int reassignBy,DateTime reassigmentDate):this() 
        {
            OlderEmployeeId = olderEmplyeeId;
            NewEmployeeId = newEmployeeId;
            ReassignBy = reassignBy;
            ReassignmentDate = reassigmentDate;
        }

        private Reassign(int id,int olderEmplyeeId, int newEmployeeId, int reassignBy, DateTime reassigmentDate) : this()
        {
            Id = id;
        }

        public static Reassign Create(int olderEmplyeeId, int newEmployeeId, int reassignBy, DateTime reassigmentDate)
        {
            var reassign = new Reassign(olderEmplyeeId, newEmployeeId, reassignBy, reassigmentDate);

            return reassign;
        }
        public static Reassign Create(int id,int olderEmplyeeId, int newEmployeeId, int reassignBy, DateTime reassigmentDate) 
        { 
            var reassign = new Reassign(id,olderEmplyeeId,newEmployeeId,reassignBy,reassigmentDate);

            return reassign;
        }

        public void Update(int olderEmplyeeId, int newEmployeeId, int reassignBy, DateTime reassigmentDate)
        {
            OlderEmployeeId = olderEmplyeeId;
            NewEmployeeId = newEmployeeId;
            ReassignBy = reassignBy;
            ReassignmentDate = reassigmentDate;
            Updated = DateTime.Now;
        }
    }
}
