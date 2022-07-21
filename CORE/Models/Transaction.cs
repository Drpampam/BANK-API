using CORE.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;


#nullable enable
namespace CORE.Models
{
    public class Transaction : IResponse
    {
        public int Id { get; set; }
        public TranType Type { get; set; }
        public TranCategory Category { get; set; }
        public decimal Amount { get; set; }
        public int AccountId { get; set; }
        public UserStatus Status { get; set; }
        public string Description { get; set; }
        public decimal AccountBalance { get; set; }
        public DateTime CreatedAt { get; set; }

        public Transaction(int id, TranType type, TranCategory category, decimal amount, int accountId, string description)
        {
            Id = id;
            Type = type;
            Category = category;
            Amount = amount;
            AccountId = accountId;
            Status = UserStatus.Active;
            Description = description;
            CreatedAt = DateTime.Now;
        }
    }
}
