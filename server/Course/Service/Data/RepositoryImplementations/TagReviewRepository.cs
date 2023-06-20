using Course.Model;
using Microsoft.EntityFrameworkCore;
using RevWorld.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevWorld.Service
{
    public class TagReviewRepository  : ITagReviewRepository, IDisposable
    {
        private readonly ApplicationContext db;

        public TagReviewRepository(ApplicationContext db)
        {
            this.db = db;
        }


        public async Task<List<TagReview>> TakeAll()
        {
            if (db.UTagReview.Count() > 0)
                return await db.UTagReview.Include(u => u.Tag).Include(u => u.Review).ToListAsync();
            else return null;
        }

        public async Task<TagReview> TakeById(int id)
        {
            return await  db.UTagReview
                .AsNoTracking().FirstAsync(r => r.Id == id);
        }
        public TagReview TakeByRevId(int id)
        {
            return db.UTagReview
                .Where(u => u.ReviewId == id)
                .FirstOrDefault();
        }

        public TagReview TakeByTagId(int id)
        {
            return db.UTagReview
                .Where(u => u.TagId == id)
                .FirstOrDefault();
        }

        public async Task<int> Create(TagReview item)
        {
            List<TagReview> lst = db.UTagReview.Count() > 0 ? db.UTagReview.ToList() : null;
            //item.ReviewId = db.Reviews.Count() + 1;
            int maxid = 0;
            foreach (TagReview tr in lst)
            {
                if (tr.Id > maxid)
                {
                    maxid = tr.Id;
                }
            }
            item.Id = maxid + 1;
            db.UTagReview.Add(item);
            await db.SaveChangesAsync();
            return item.Id;
        }

        public async Task DeleteById(int id)
        {
            db.UTagReview.Remove(await TakeById(id));
            await db.SaveChangesAsync();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
