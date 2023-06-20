using Course.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevWorld.Model
{
    public class Review
    {
         public Review()
        {
           Comments = new List<Comment>();
           
        }

        public int ReviewId { get; set; }
        public int? UserId { get; set; }
        public int? BookId { get; set; }
        public string Title { get; set; }
        public int? RaitingBook { get; set; }
        public int? NumLikes { get; set; }
        public string Review_data { get; set; }
        public DateTime? Public_date { get; set; }

        public virtual User User { get; set; }
        public virtual Book Book { get; set; }

        //public virtual List<TagReview> Tags { get; set; }
        public virtual List<Comment> Comments { get; set; }
    }
}
