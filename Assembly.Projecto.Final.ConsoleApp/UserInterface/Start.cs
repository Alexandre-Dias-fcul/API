using Assembly.Projecto.Final.ConsoleApp.UserInterface.BackOffice;
using Assembly.Projecto.Final.Domain.Core.Repositories;
using Assembly.Projecto.Final.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.ConsoleApp.UserInterface
{
    public class Start
    {
        private readonly IUserService _userService;

        public Start(IUserService userService)
        {
            _userService = userService;
        }

        public void Run()
        {
            Console.WriteLine("1.Admin panel");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    new Admin(_userService).Run();
                    break;
                case "2":
                    break;
                default:
                    break;
            }
        }
    }
}
