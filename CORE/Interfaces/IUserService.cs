using CORE.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Interfaces
{
    public interface IUserService : IResponse
    {
        public void Create(string firstName, string lastName, string email, string password);
    }
}
