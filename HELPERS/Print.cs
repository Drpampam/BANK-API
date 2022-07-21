
using CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace HELPERS

{
    public class Print
    {
        public static void PrintAccountDetails(List<Account> accounts)
        {
            Console.WriteLine($"| {"---------------",-15} | {"---------------",-15} | {"---------------",-15} | {"---------------",-15} | {"---------------",-15} |");
            Console.WriteLine($"| {"S/N",-15} | {"ACCOUNT NAME",-15} | {"ACCOUNT NUMBER",-15} | {"ACCOUNT TYPE",-15} | {"ACCOUNT BALANCE",-15} |");
            Console.WriteLine($"| {"---------------",-15} | {"---------------",-15} | {"---------------",-15} | {"---------------",-15} | {"---------------",-15} |");
            int num = 0;

            foreach (var account in accounts)
            {
                Thread.Sleep(300);
                Console.WriteLine($"| {++num,-15} | {account.AccountName,-15} | {account.AccountNumber,-15} | {account.Type,-15} | {account.Balance,15:N2} |");
            }
            Console.WriteLine($"| {"---------------------------------------------------------------------------------------",-87} |");
        }

        public static void PrintAccountStatement(Account account, List<Transaction> transactions)
        {
            Console.WriteLine($"ACCOUNT STATEMENT FOR [ {account.AccountName}, {account.AccountNumber} ]");

            Console.WriteLine($"| {"---------------",-15} | {"------------------------------",-30} | {"---------------",-15} | {"---------------",-15} | {"---------------",-15} |");
            Console.WriteLine($"| {"DATE",-15} | {"DESCRIPTION",-30} | {"AMOUNT",-15} | {"TYPE",-15} | {"BALANCE",-15} |");
            Console.WriteLine($"| {"---------------",-15} | {"------------------------------",-30} | {"---------------",-15} | {"---------------",-15} | {"---------------",-15} |");

            if (transactions.Count > 0)
            {
                foreach (var transaction in transactions)
                {
                    Thread.Sleep(300);
                    Write($"| {transaction.CreatedAt.ToString("d"),-15} ");
                    Write($"| {transaction.Description,-30} | ");
                    BackgroundColor = transaction.Type == TranType.Debit ? ConsoleColor.DarkRed : ConsoleColor.DarkGreen;
                    Write($"{transaction.Amount,15:N2}");
                    BackgroundColor = ConsoleColor.Black;
                    Write($" | {transaction.Type,-15} ");
                    WriteLine($"| {transaction.AccountBalance,15:N2} |");
                }

            }
            Console.WriteLine($"| {"------------------------------------------------------------------------------------------------------",-87} |");
        }

        public static void PrintLogo()
        {
            Clear();
            Console.Title = "PAMPAM BANK PLC";
            BackgroundColor = ConsoleColor.Green;
            WriteLine("                                  PAMPAM Bank PLC >>>           ");
            Console.WriteLine("|==============================================================================|");
            Console.WriteLine("\n|==========================WELCOME TO PAMPAM BANK PLC===========================|\n");
            Console.WriteLine("|==============================================================================|");
            
            BackgroundColor = ConsoleColor.DarkGray;
        }
    }
}
