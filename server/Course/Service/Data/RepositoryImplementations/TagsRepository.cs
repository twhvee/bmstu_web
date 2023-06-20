using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using RevWorld.Model;
using Course.Model;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RevWorld.Service
{
    public class TagsRepository : ITagsRepository, IDisposable
    {
        private readonly ApplicationContext db;

        public TagsRepository(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<int> Create(Tag item)
        {
            List<Tag> lst = db.Tags.Count() > 0 ? db.Tags.ToList() : null;
            //item.ReviewId = db.Reviews.Count() + 1;
            int maxid = 0;
            foreach (Tag tag in lst)
            {
                if (tag.TagId > maxid)
                {
                    maxid = tag.TagId;
                }
            }
            item.TagId = maxid + 1;
            //item.TagId = db.Tags.Count() + 1;
            db.Tags.Add(item);
            await db.SaveChangesAsync();
            return item.TagId;
        }

        public async Task<List<Tag>> TakeAll()
        {
            if (db.Tags.Count() > 0)
                return await db.Tags.ToListAsync();
            else return null;
        }

        public async Task<Tag> TakeById(int id)
        {
            var tag = await db.Tags
                .AsNoTracking().FirstAsync(r => r.TagId == id); 
            return tag;
        }

        public async Task<Tag> FindByName(string name)
        {
            return db.Tags.FirstOrDefault(search => search.TagName == name);
        }


        public async Task DeleteById(int id)
        {
            db.Tags.Remove(await TakeById(id));
            await db.SaveChangesAsync();
        }
 

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
