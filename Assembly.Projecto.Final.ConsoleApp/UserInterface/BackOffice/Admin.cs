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
        public Admin()
        {
     
        }

        public async void Run()
        {
            Console.WriteLine("Welcome Admin");

            Console.WriteLine("1 - Adicionar Agent.");

            Console.WriteLine("2 - Adicionar Manager.");

            Console.WriteLine("3 - Ver Managers.");

            Console.Write(">");

            string opcao = Console.ReadLine();

            switch (opcao)
            {  
                case "1":
                   

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
