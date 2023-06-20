using Course.Model;
using Microsoft.EntityFrameworkCore;
using RevWorld.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.Service
{
    public class TagReviewService
    {
        private readonly ApplicationContext db;

        public TagReviewService(ApplicationContext db)
        {
            this.db = db;
        }


        public List<TagReview> TakeAll()
        {
            return db.UTagReview.Include(u => u.Tag).Include(u => u.Review).ToList();
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

        public void Create(TagReview item)
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
            db.SaveChangesAsync();
            //return item.ReviewId;
        }

        public void Update(TagReview updatedTagReview)
        {
            using var transaction = db.Database.BeginTransaction();
            try
            {
                db.Entry(updatedTagReview).State = EntityState.Modified;
                db.SaveChangesAsync();
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
            }
        }

        public void Delete(int id)
        {
            var TagReviewToDelete = db.UTagReview
                .Where(x => x.Id == id)
                .FirstOrDefault();

            using var transaction = db.Database.BeginTransaction();
            try
            {
                db.UTagReview.Remove(TagReviewToDelete);
                db.SaveChangesAsync();
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
            }
        }
    }
}
