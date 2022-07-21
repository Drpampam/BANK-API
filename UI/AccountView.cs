using CORE.Verification;
using CORE.Interfaces;
using CORE.Services;
using CORE.Models;
using HELPERS; 
using static System.Console;
using static CORE.Interfaces.IAccountServices;
using CORE.Services.Implementation;

namespace UI
{
    public class AccountView
    {
        
        private static readonly IAccountServices _accountService = new AccountService();
        private static readonly ITransactionService _transactionService = new TransactionService();

        public static void DisplayAccountMenu()
        {
            Print.PrintLogo();
            WriteLine("Select an option to continue:");
            WriteLine("\t1. View Accounts\n\t2. Create new Savings or Current account\n\t3. Logout");
            Write("==> ");
            string answer= ReadLine();

            var user = LoginVerification.CurrentCustomer;

            if (answer == "1")
            {
                ViewAccountMenu(user);
            }
            else if (answer == "2")
            {
                DisplayCreateAccountMenu(user);
            }else if (answer == "3")
            {
                LoginVerification.Logout();
            }
        }

        public static void DisplayCreateAccountMenu(User user)
        {
            WriteLine("Select account type:");
            WriteLine("\t1. Savings\n\t2. Current\n");
            Write("==> ");
            string answer = ReadLine();

            if (answer == "1" || answer == "2")
            {
                WriteLine("Creating account. Please wait ..."); 
                Thread.Sleep(1500);

                _accountService.Create(answer);
                var account = _accountService.Get(AccountService.IdCount);

                WriteLine("Account successfully created. Your account details are:");
                WriteLine($"\t- Account Name: {account.AccountName}\n\t- Account Number: {account.AccountNumber} \n\t- Account Type: {account.Type}");
                Write("Press Enter to continue: ");
                ReadLine();

                DisplayAccountMenu();
            }
        }

        public static void ViewAccountMenu(User user)
        {
            var accounts = _accountService.GetAllUserAccounts(user.Id);
            Print.PrintAccountDetails(accounts);

            Write("Select an account to continue: ");
            var answer = ReadLine();
            int.TryParse(answer, out int num);

            if (num > 0 && num <= accounts.Count)
            {
                var account = accounts[num-1];
                SingleAccount(account);
            }

        }

        public static void SingleAccount(Account account)
        {
            Print.PrintLogo();
            WriteLine($"\t- Account Name: {account.AccountName}\t- Account Number: {account.AccountNumber} \t- Account Type: {account.Type}");
            WriteLine("Select an action to continue:");
            WriteLine("\t1. Deposit\t2. Withdraw\n\t3. Transfer\t4. Request Statement\n\t5. Get Balance\t6. Main Menu");
            Write("==> ");
            var answer = ReadLine();

            if (answer == "1")
            {
                DepositMenu(account);
            }
            else if (answer == "2")
            {
                WithdrawInterface(account);
            }
            else if (answer == "3")
            {
                TransferInterface(account);
            }else if (answer == "4")
            {
                DisplayAccountStatement(account);
            }else if (answer == "5")
            {
                DisplayAccountBalance(account);
            }else if (answer == "6")
            {
                DisplayAccountMenu();
            }
        }

        public static void DepositMenu(Account account)
        {
            Write("Amount to deposit: ");
            var answer = ReadLine();

            if (decimal.TryParse(answer, out decimal amount))
            {
                try
                {
                    _accountService.Deposit(amount, account.Id);

                    WriteLine("Deposit transaction successful");
                }
                catch (Exception e)
                {
                    WriteLine(e.Message);
                }
            }

            Write("Press Enter to continue: ");
            ReadLine();
            SingleAccount(account);
        }

        public static void WithdrawInterface(Account account)
        {
            Write("Amount to withdraw: ");
            var answer = ReadLine();

            if (decimal.TryParse(answer, out decimal amount))
            {
                try
                {
                    _accountService.Withdraw(amount, account.Id);
                    WriteLine("Withdrawal transaction successful");
                }
                catch (Exception e)
                {
                    WriteLine(e.Message);
                }
            }

            Write("Press Enter to continue: ");
            ReadLine();
            SingleAccount(account);
        }

        public static void TransferInterface(Account account)
        {
            Write("Enter amount: ");
            var answer = ReadLine();

            if(!decimal.TryParse(answer, out decimal amount))
            {
                WriteLine("Invalid input");
                SingleAccount(account);
            }

            Write("Enter destination account: ");
            var answer2 = ReadLine();
            var destinationAccount= Validate.CheckAccountExists(answer2, out string message);

            if(destinationAccount == null)
            {
                WriteLine(message);
                Write("Press Enter to continue: ");
                ReadLine();

                SingleAccount(account);
            }
            else
            {
                try
                {
                    _accountService.Transfer(amount, account.Id, destinationAccount.Id);
                    WriteLine("Transfer transaction successful");
                }
                catch (Exception e)
                {
                    WriteLine(e.Message);
                }

                Write("Press Enter to continue: ");
                ReadLine();
                SingleAccount(account);
            }
        }

        public static void DisplayAccountStatement(Account account)
        {
            Print.PrintLogo();

            var transactions = _transactionService.GetAllAccountTransactions(account.Id);

            Print.PrintAccountStatement(account, transactions);

            Write("Press Enter to continue: ");
            ReadLine();

            SingleAccount(account);
        }

        public static void DisplayAccountBalance(Account account)
        {
            WriteLine($"Available balance for account {account.AccountNumber}: {account.Balance:N2}");

            Write("Press Enter to continue: ");
            ReadLine();

            SingleAccount(account);
        }
    }
}
