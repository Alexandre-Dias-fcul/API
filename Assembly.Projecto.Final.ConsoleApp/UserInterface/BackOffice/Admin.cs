using Assembly.Projecto.Final.Domain.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.ConsoleApp.UserInterface.BackOffice
{
    public class Admin
    {
        private readonly IUserRepository _userRepository;

        public Admin(IUserRepository userRepository) 
        { 
            _userRepository = userRepository;
        }

        public void Run() 
        {
            Console.WriteLine("Welcome Admin");
        }
    }
}
