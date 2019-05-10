using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts
{
    public interface IUserLogic : IBaseLogic<User>
    {
        User Login(string email, string pass);
    }
}
