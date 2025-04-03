using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Services.Exceptions
{
    public class CustomApplicationException:Exception
    {
        public CustomApplicationException(string error) : base(error) { }

        public static void When(bool hasError, string error)
        {
            if (hasError)
            {
                throw new ApplicationException(error);
            }
        }
    }
}
