using Assembly.Projecto.Final.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Domain.Models
{
    public class EmployeeAccount: AuditableEntity<int>
    {
        public string Password { get; private set; }
        public string Email { get; private set; }

        private EmployeeAccount() 
        { 
            Password = string.Empty;
            Email = string.Empty;
            Created = DateTime.Now;
        }

        private EmployeeAccount(string password,string email):this()
        { 
            Email = email;
            Password = password;
        }

        public static EmployeeAccount Create(string password, string email) 
        { 
            var employeeAccount = new EmployeeAccount(password,email);

            return employeeAccount;
        }

        public void Update(string password, string email) 
        { 
            Password = password;
            Email = email;
            Updated = DateTime.Now;
        }
    }
}
