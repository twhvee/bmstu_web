using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using RevWorld.Model;
using Course.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace RevWorld.Service
{
    public class CommentsRepository : ICommentsRepository, IDisposable
    {
        private readonly ApplicationContext db;

        public CommentsRepository(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<int> Create(Comment item)
        {
            List<Comment> lst = db.Comments.Count() > 0 ? db.Comments.ToList() : null;
            //item.ReviewId = db.Reviews.Count() + 1;
            int maxid = 0;
            foreach (Comment com in lst)
            {
                if (com.CommentId > maxid)
                {
                    maxid = com.CommentId;
                }
            }
            item.CommentId = maxid + 1;
            db.Comments.Add(item);
            await db.SaveChangesAsync();
            return item.CommentId;
        }

       

        public async Task<List<Comment>> TakeAll()
        {
            if (db.Comments.Count() > 0)
                return await db.Comments.Include(s => s.Review).Include(s => s.User).ToListAsync();
            else return null;
        }

        public async Task<Comment> TakeById(int id)
        {
            return await db.Comments
                .Include(s => s.Review).ThenInclude(u => u.User)
                .Include(s => s.User).
                AsNoTracking().FirstAsync(r => r.CommentId == id);           
        }

        public async Task DeleteAll()
        {
            db.Comments.RemoveRange(await TakeAll());
            await db.SaveChangesAsync();
        }

 
        public async Task UpdateLikes(int id)
        {
            Comment comment = db.Comments.Find(id);
            if (comment != null)
            {
                comment.NumLikes += 1;
            }
            await db.SaveChangesAsync();
        }

        public async Task<List<Comment>> GetByRev(int id)
        {
            return await db.Comments.Include(s => s.Review).Include(s => s.User).Where(r => r.ReviewId == id).ToListAsync();
            
        }

        

        public async Task DeleteById(int id)
        {
            db.Comments.Remove(await TakeById(id));
            await db.SaveChangesAsync();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
