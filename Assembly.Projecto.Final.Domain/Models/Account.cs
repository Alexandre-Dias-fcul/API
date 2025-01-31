using Assembly.Projecto.Final.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.Domain.Models
{
    public class Account : AuditableEntity<int>
    {
        public string Password { get; private set; }
        public string Email { get; private set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        private Account()
        {
            Password = string.Empty;
            Email = string.Empty;
            Created = DateTime.Now;
        }

        private Account(string password, string email) : this()
        {
            Password = password;
            Email = email;
        }

        private Account(int id, string password, string email) : this(password, email)
        {
            Id = id;
        }

        public static Account Create(string password, string email)
        {
            var account = new Account(password, email);

            return account;
        }

        public static Account Create(int id, string password, string email)
        {
            var account = new Account(id, password, email);

            return account;
        }


        public void Update(string password, string email)
        {
            Password = password;
            Email = email;
            Updated = DateTime.Now;
        }
    }
}
