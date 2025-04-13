using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Services.Interfaces
{
    public interface IAuthenticationService
    {
        public string AuthenticationEmployee(string email, string password);
        public string AuthenticationUser(string email, string password); 
    }
}
