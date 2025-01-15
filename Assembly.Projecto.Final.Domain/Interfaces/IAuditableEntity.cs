using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Domain.Interfaces
{
    public interface IAuditableEntity<TUserId>
    {
        public DateTime Created { get; set; }
        public TUserId CreatedBy { get; set; }
        public DateTime Updated { get; set; }
        public TUserId UpdatedBy { get; set; }
    }
}
