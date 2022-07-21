using CORE.Models;
using DATA.Models;

namespace CORE.Verification
{
    public class LoginVerification
    {
        public static User CurrentCustomer { get; set; }

        public static bool Login(string email, string password)
        {
            User user = DataStore.Users.FirstOrDefault(x => x.Email == email && x.Password == password);
            if (user == null) return false;
            else
            {
                CurrentCustomer = user;
                return true;
            }
        }

        public static void Logout()
        {
            CurrentCustomer = null;
        }
    }
}
