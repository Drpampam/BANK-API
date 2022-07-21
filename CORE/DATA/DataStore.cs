using CORE.Models;

namespace DATA.Models
{
  public class DataStore
    {
        public static List<User> Users { get; set; } = new List<User>();
        public static List<Account> Accounts { get; set; } = new List<Account>();
        public static List<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
