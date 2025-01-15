using Assembly.Projecto.Final.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Domain.Common
{
    public class AuditableEntity<TId> : Entity<TId>,IAuditableEntity<int>
    {
        public DateTime Created { get ; set; }
        public int CreatedBy { get; set; }
        public DateTime Updated { get; set; }
        public int UpdatedBy { get; set; }
    }
}
