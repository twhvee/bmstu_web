using RevWorld.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.Model
{
    public class Comment
    {
        public int CommentId { get; set; }

        public int? UserId { get; set; }
        public int? ReviewId { get; set; }
        public int? NumLikes { get; set; }
        public string Comment_data { get; set; }
        public DateTime? Public_date { get; set; }

        public virtual User User { get; set; }
        public virtual Review Review { get; set; }

        
    }
}
