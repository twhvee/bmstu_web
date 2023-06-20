
using Course.Model;
using Course.Model.Users;
using RevWorld.Model.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevWorld.Model.Reviews
{
    public class ReviewtoRead
    {
        public int ReviewId { get; set; }
        public int? UserId { get; set; }
        public int? BookId { get; set; }
        public string Title { get; set; }
        public int? RaitingBook { get; set; }
        public int? NumLikes { get; set; }
        public string Review_data { get; set; }
        public DateTime? Public_date { get; set; }

        public virtual UsertoSave User { get; set; }

        public virtual List<Tag> Tags { get; set; }
        public virtual BooktoRead Book { get; set; }
    }
}
