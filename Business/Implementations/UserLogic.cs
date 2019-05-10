using Business.Contracts;
using Data.Contracts;
using Data.Implementations;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementations
{
    public class UserLogic : BaseLogic<User, UserRepository>, IUserLogic
    {
        private readonly IUserRepository userRepository;

        public UserLogic(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public User Login(string email, string pass)
        {
            return this.userRepository.Login(email, pass);
        }
    }
}
