using RevWorld.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.Model
{
    public class User
    {
        public User()
        {
            Reviews = new List<Review>();
            Comments = new List<Comment>();
        }
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Avatar { get; set; }
        public string Access_role { get; set; }

        
        public virtual List<Review> Reviews { get; set; }
        public virtual List<Comment> Comments { get; set; }
    }
}
