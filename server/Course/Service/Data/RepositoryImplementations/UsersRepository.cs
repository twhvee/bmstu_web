using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Course.Model;
using RevWorld.Model;
using System.Threading.Tasks;

namespace RevWorld.Service
{
    public class UsersRepository : IUsersRepository, IDisposable
    {
        private readonly ApplicationContext db;

        public UsersRepository(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<int> Create(User item)
        {
            List<User> lst = db.Users.Count() > 0 ? db.Users.ToList() : null;
            //item.ReviewId = db.Reviews.Count() + 1;
            int maxid = 0;
            foreach (User user in lst)
            {
                if (user.UserId > maxid)
                {
                    maxid = user.UserId;
                }
            }
            item.UserId = maxid + 1;
            db.Users.Add(item);
            await db.SaveChangesAsync();
            return item.UserId;
        }

        public async Task<List<User>> TakeAll()
        {
            if (db.Users.Count() > 0)
                return await db.Users.Include(s => s.Reviews).Include(s => s.Comments).ToListAsync();
            else return null;
        }

        public async Task<User> TakeById(int id)
        {
            return await db.Users            
              .Include(s => s.Reviews).ThenInclude(r => r.Book)
              .Include(s => s.Comments)
              .AsNoTracking().FirstAsync(r => r.UserId == id);
        }

        public async Task DeleteById(int id)
        {
            List<User> lst = db.Users.FromSqlRaw("SELECT * from delete_user({0})", id).ToList();
            await db.SaveChangesAsync();
        }
        public async Task<User> FindByName(string name)
        {
            return await db.Users.Include(s => s.Reviews).ThenInclude(r => r.Book)
              .Include(s => s.Comments).AsNoTracking().FirstAsync(search => search.Login == name); 
        }


        public void Dispose()
        {
            db.Dispose();
        }
    }
}
