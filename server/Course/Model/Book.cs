using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevWorld.Model
{
    public class Book
    {
        
        public Book()
        {
            Reviews = new List<Review>();
           // Pictures = new HashSet<Picture>();
        }
        
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public string Path { get; set; }

        public virtual List<Review> Reviews { get; set; }
        //public virtual ICollection<Picture> Pictures { get; set; }
    }
}
