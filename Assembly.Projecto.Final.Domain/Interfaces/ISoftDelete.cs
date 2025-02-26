using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Domain.Interfaces
{
    public interface ISoftDelete
    {
        public bool IsDeleted { get; }

        public void Delete();
    }
}
