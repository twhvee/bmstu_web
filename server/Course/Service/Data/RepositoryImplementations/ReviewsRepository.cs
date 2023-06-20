using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RevWorld.Model;
using Course.Model;
using System.Threading.Tasks;

namespace RevWorld.Service
{
    public class ReviewRepository : IReviewsRepository, IDisposable
    {
        private readonly ApplicationContext db;

        public ReviewRepository(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<int> Create(Review item)
        {
            List<Review> lst = db.Reviews.Count() > 0 ? db.Reviews.ToList() : null;
            //item.ReviewId = db.Reviews.Count() + 1;
            int maxid = 0;
            foreach (Review rev in lst)
            {
                if (rev.ReviewId > maxid)
                {
                    maxid = rev.ReviewId;
                }
            }
            item.ReviewId = maxid + 1;
            db.Reviews.Add(item);
            await db.SaveChangesAsync();
            return item.ReviewId;
            
        }
        public async Task DeleteAll()
        {
            db.Reviews.RemoveRange(await TakeAll());
            await db.SaveChangesAsync();
        }
        public async Task<List<Review>> TakeAll()
        {
            if (db.Reviews.Count() > 0)
                return await db.Reviews.Include(s => s.Book).Include(s => s.Comments).Include(s => s.User).ToListAsync();
            else return null;          
        }

        public async Task<Review> TakeById(int id)
        {
            return await  db.Reviews         
                .Include(s => s.Book).
                Include(s => s.User).
                Include(s => s.Comments).ThenInclude(u => u.User).AsNoTracking().FirstAsync(r => r.ReviewId == id); 
        }
        public async Task DeleteById(int id)
        {
      
            List<Review> lst = db.Reviews.FromSqlRaw("SELECT * from delete_review({0})", id).ToList();
            await db.SaveChangesAsync();
            //db.delete_review4(id);        
        }
        public async Task UpdateLikes(int id)
        {
            Review review = db.Reviews.Find(id);
            if (review != null)
            {
                review.NumLikes += 1;
            }
            await db.SaveChangesAsync();
        }


        public async Task<List<Review>> FindByTag(string name)
        {
            List<Review> lrev = new List<Review>();
            Tag tag = await db.Tags.Where(r => r.TagName == name).FirstAsync() ;
            if (tag != null)
            {
                
                List<TagReview> ltagrev = db.UTagReview.Include(u => u.Tag).Include(u => u.Review).ToList();
                foreach (TagReview tagrev in ltagrev)
                {
                    if (tagrev.TagId == tag.TagId)
                    {
                        lrev.Add(db.Reviews.Where(r => r.ReviewId == tagrev.ReviewId).Include(s => s.Book).Include(s => s.Comments).Include(s => s.User).FirstOrDefault());
                    }
                }
                
                /*
                List<Review> lst = db.Reviews.FromSqlRaw("select review.reviewid, review.userid, review.bookid, review.title, review.numlikes,review.review_data, review.public_date, review.raitingbook from tag join tag_to_review on tag.tagid = tag_to_review.tagid join review on review.reviewid = tag_to_review.reviewid where tag.tagname = {0}", name).ToList();
                */
                return lrev.Count() > 0 ? lrev.ToList() : null;
            }
                    
            return null;
        }


        public void Dispose()
        {
            db.Dispose();
        }
    }
}
