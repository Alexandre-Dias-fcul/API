using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Domain.Interfaces
{
    public interface IEntity<TId>
    {
        public TId Id { get; }
    }
}
