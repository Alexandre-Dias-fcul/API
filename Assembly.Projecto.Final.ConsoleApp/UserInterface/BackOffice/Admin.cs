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

            Console.WriteLine("1 - Adicionar User.");

            Console.WriteLine("2 - Get User By Id.");

            Console.WriteLine("3 - Delete User by Id.");

            Console.Write(">");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    var user = User.Create("Ana", "Maria", "Antunes", DateTime.Now, "Feminino", string.Empty, true);
                    user.Contacts.Add(Contact.Create(ContactType.Email, "Ana@gmail.com"));
                    user.Addresses.Add(Address.Create("Rua Afonso Costa", "Lisboa", "Portugal", "2345-456"));
                    user.Account = Account.Create("123", "Ana@gmail.com");

                    _userService.Add(user);
                    break;

                case "2":
                    Console.WriteLine("Qual o id de usuário:");

                    int id = Convert.ToInt32(Console.ReadLine());

                    if (id > 0)
                    {
                        var userFound = _userService.GetById(id);

                        if (userFound != null)
                        {
                            Console.WriteLine($" Name: {userFound.Name.FirstName} {userFound.Name.LastName}");
                        }
                    }
                    break;

                case "3":
                    Console.WriteLine("Qual o id de usuário:");

                    int id2 = Convert.ToInt32(Console.ReadLine());

                    if (id2 > 0)
                    {
                        var userFound = _userService.GetById(id2);

                        if (userFound != null)
                        {
                            _userService.Delete(userFound);
                        }
                    }
                    break;

                default: break;
            }
        }
    }
}
