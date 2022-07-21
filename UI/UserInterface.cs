using Microsoft.Extensions.Options;
using CORE.Verification;
using CORE.Interfaces;
using CORE.Services;
using CORE.Models;
using CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using HELPERS;

namespace UI
{
    public class UserInterface
    {
   
        public static void Run()
        {

            bool running = true;

            while (running)
            {
                while (LoginVerification.CurrentCustomer == null)
                {
                    Print.PrintLogo();
                    AuthView.DisplayAuthMenu();
                }

                AccountView.DisplayAccountMenu();
            }
        }
    }
}
