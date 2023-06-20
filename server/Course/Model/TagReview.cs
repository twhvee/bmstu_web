using RevWorld.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Course.Model
{
    public class TagReview
    {
        public int Id { get; set; }

        [ForeignKey("Tag")]
        public int? TagId { get; set; }
        public virtual Tag Tag { get; set; }

        [ForeignKey("Review")]
        public int? ReviewId { get; set; }
        public virtual Review Review { get; set; }
    }
}
