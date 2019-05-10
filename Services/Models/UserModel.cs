using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Services.Models
{
    public class UserModel
    {
        public string Email { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public string TokenAccess { get; set; }
        public string Name { get; internal set; }
    }
}