using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.Model.Users
{
    public class UsertoRead
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public string Access_role { get; set; }
    }
}
