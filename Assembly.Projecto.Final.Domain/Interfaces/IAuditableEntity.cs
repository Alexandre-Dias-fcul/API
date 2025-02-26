using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Domain.Interfaces
{
    public interface IAuditableEntity<TUserId>
    {
        public DateTime Created { get; }
        public TUserId CreatedBy { get; }
        public DateTime Updated { get;  }
        public TUserId UpdatedBy { get;  }

        void Create(DateTime created);
        void Update(DateTime updated);
    }
}
