using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Services.Exceptions
{
    public class NotFoundException : CustomApplicationException
    {
        public NotFoundException(string error) : base(error)
        {

        }
        public static new void When(bool hasError, string error)
        {
            if (hasError)
            {
                throw new NotFoundException(error);
            }
        }
    }
}
