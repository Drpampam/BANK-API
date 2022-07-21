using CORE.Interfaces;
using DATA.Models;
using System;

namespace CORE.Models
{
    public class Account : IResponse
    {
        public int Id { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public AccountType Type { get; set; }
        public int UserId { get; set; }
        public UserStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal Balance
        {
            get
            {
          
                decimal balance = DataStore.Transactions.Where(x => x.AccountId == Id).Where(x => x.Type == TranType.Credit).Sum(x => x.Amount) -
                    DataStore.Transactions.Where(x => x.AccountId == Id).Where(x => x.Type == TranType.Debit).Sum(x => x.Amount);

                return balance;
            }
        }

        public Account(int id, string accountName, string accountNumber, AccountType type, int userId)
        {
            Id = id;
            AccountName = accountName;
            AccountNumber = accountNumber;
            Type = type;
            UserId = userId;
            Status = UserStatus.Active;
            CreatedAt = DateTime.Now;
        }
    }
}

