using CORE.Interfaces;
using CORE.Models;
using CORE.Services;
using CORE.Verification;
using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using HELPERS;
using CORE.Services.Implementation;

namespace UI
{
    public class AuthView
    {
        private static readonly IUserService _userService = new UserService();
        public static void DisplayAuthMenu()
        {
            WriteLine("Welcome, select an option to continue:");
            WriteLine("\t1. Login\n\t2. Register\n\t3. Exit");
            Write("==> ");

            string reply = ReadLine();

            if (reply == "1")
            {
                Login();
            }
            else if (reply == "2")
            {
                Register();
            }else if (reply == "3")
            {
                Environment.Exit(0);
            }
        }

        public static bool Login()
        {
            int count = 0;

            while (count < 3)
            {
                WriteLine("Enter your details to login");
                Write("Email: ");
                string email = ReadLine();

                Write("Password: ");
                string password = ReadLine();

                if (LoginVerification.Login(email, password)) return true;

                WriteLine("Invalid email or password");
                count++;
            }
            return false;
        }

        public static void Register()
        {
            bool invalid = true;
            int count = 0;

            while (invalid && count < 3)
            {
                Write("Firstname: ");
                string firstName = ReadLine();

                Write("Lastname: ");
                string lastName = ReadLine();

                Write("Email: ");
                string email = ReadLine();

                Write("Password: ");
                string password = ReadLine();

                bool detailsValid = Validate.Register(firstName, lastName, email, password, out List<string> messages);

                if (detailsValid)
                {
                    _userService.Create(firstName, lastName, email, password);
                    LoginVerification.Login(email, password);
                    invalid = false;
                }
                else
                {
                    WriteLine();
                    foreach (var message in messages)
                    {
                        WriteLine(message);
                    }
                    count++;
                    continue;
                }
            }
        }
    }
}
