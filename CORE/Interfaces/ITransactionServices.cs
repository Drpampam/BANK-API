using CORE.Models;
using CORE.Services.Implementation;
using System;


#nullable enable
namespace CORE.Interfaces
{
    public interface ITransactionService : IResponseService
    {
        public void Create(decimal amount, int acccountId, TranType transType, TranCategory transCategory, string transDesc);
        public Transaction Get(int id);
        List<Transaction> GetAllAccountTransactions(int id);
    }
}
