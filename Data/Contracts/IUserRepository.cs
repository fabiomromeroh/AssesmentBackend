using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User Login(string email, string pass);
    }
}
