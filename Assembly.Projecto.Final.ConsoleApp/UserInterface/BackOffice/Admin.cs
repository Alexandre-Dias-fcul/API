using Assembly.Projecto.Final.Domain.Core.Repositories;
using Assembly.Projecto.Final.Domain.Enums;
using Assembly.Projecto.Final.Domain.Models;
using Assembly.Projecto.Final.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assembly.Projecto.Final.ConsoleApp.UserInterface.BackOffice
{
    public class Admin
    {
        private readonly IUserService _userService;

        public Admin(IUserService userService)
        {
            _userService = userService;
        }

        public async void Run()
        {
            Console.WriteLine("Welcome Admin");

            Console.WriteLine("1 - Adicionar Agent.");

            Console.WriteLine("2 - Get Agent By Id.");

            Console.WriteLine("3 - Delete Agent by Id.");

            Console.Write(">");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1": var agent = Agent.Create("Ana","Maria","Costa",DateTime.Now,"Feminino","",true,DateTime.Now,
                                                    DateTime.Now,RoleType.Agent,null,null,null,null);


                          var entityLink = EntityLink.Create(EntityType.Employee,agent.Id);

                          var account = Account.Create("123", "ana@gmail.com", entityLink,entityLink.Id);

                          

                    break;

                case "2":
                    
                    break;

                case "3":
                    
                    break;

                default: break;
            }
        }
    }
}
