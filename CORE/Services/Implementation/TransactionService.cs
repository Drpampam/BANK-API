using CORE.Interfaces;
using CORE.Models;
using DATA.Models;

namespace CORE.Services
{
    public class TransactionService : ITransactionService
    {

        public static int IdCount { get; set; }
        public void Create(decimal amount, int acccountId, TranType transType, TranCategory transCategory, string transDesc)
        {
            IdCount++;
            var trans = new Transaction(IdCount, transType, transCategory, amount, acccountId, transDesc);

            DataStore.Transactions.Add(trans);

            var account = DataStore.Accounts.First(x => x.Id == acccountId);
            trans.AccountBalance = account.Balance;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(int id)
        {
            throw new NotImplementedException();
        }

        public Transaction Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Transaction> GetAllAccountTransactions(int transId)
        {
            return DataStore.Transactions.Where(x => x.AccountId == transId).ToList();
        }
    }
}
