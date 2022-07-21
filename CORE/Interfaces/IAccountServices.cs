using CORE.Models;
using CORE.Services.Implementation;
using System.Collections.Generic;


#nullable enable
namespace CORE.Interfaces
{
  

        public interface IAccountServices : IResponseService
        {
            void Create(string type);
            Account Get(int id);
            public void Deposit(decimal amount, int accountId);
            public void Withdraw(decimal amount, int accountId);
            public void Transfer(decimal amount, int accountId, int destinationAccountId);
            List<Account> GetAllUserAccounts(int id);
        }
    }

