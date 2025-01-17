using Assembly.Projecto.Final.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Domain.Models
{
    public class UserAccount: AuditableEntity<int>
    {
        public string Password { get; private set; }
        public string Email { get;  private set; }

        private UserAccount() 
        { 
            Password = string.Empty;
            Email = string.Empty;
            Created = DateTime.Now;
        }

        private UserAccount(string password,string email):this() 
        { 
            Password = password;
            Email = email;
        }

        private UserAccount(int id,string password, string email) : this(password,email)
        {
            Id = id;
        }

        public static UserAccount Create(string password,string email) 
        {
            var userAccount = new UserAccount(password,email);

            return userAccount;
        }

        public static UserAccount Create(int id,string password, string email)
        {
            var userAccount = new UserAccount(id,password, email);

            return userAccount;
        }


        public void Update(string password,string email) 
        {
            Password = password;
            Email = email;
            Updated = DateTime.Now;
        }
    }
}
