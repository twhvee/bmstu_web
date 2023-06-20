using Course.Model.Users;
using RevWorld.Model.Reviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Course.Model.Comments
{
    public class CommenttoRead
    {
        public int CommentId { get; set; }

        public int? UserId { get; set; }
        public int? ReviewId { get; set; }
        public int? NumLikes { get; set; }
        public string Comment_data { get; set; }
        public DateTime? Public_date { get; set; }

        public virtual UsertoSave User { get; set; }

        public virtual ReviewtoSave Review { get; set; }
    }
}
