using CORE.Interfaces;
using CORE.Models;
using DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Services.Implementation
{
    public class UserService : IUserService
    {

        public static int IdCount { get; set; }
        public void Create(string firstName, string lastName, string email, string password)
        {
            IdCount++;

            var user = new User(IdCount, firstName, lastName, email, password);

            DataStore.Users.Add(user);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(int id)
        {
            throw new NotImplementedException();
        }

        public IResponse Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
