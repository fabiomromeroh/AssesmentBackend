using Data.Base;
using Data.Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementations
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {

        public User Login(string email, string pass)
        {
            using (AssesmentContext Context = new AssesmentContext())
            {
                return Context.Users.Where(x => x.Email == email && x.Password == pass).FirstOrDefault();
            }
        }
    }
}
