using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using RevWorld.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace RevWorld.Service
{
    public class BooksRepository : IBooksRepository, IDisposable
    {
        private readonly ApplicationContext db;

        public BooksRepository(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<int> Create(Book item)
        {
            List<Book> lst = db.Books.Count() > 0 ? db.Books.ToList() : null;
            //item.ReviewId = db.Reviews.Count() + 1;
            int maxid = 0;
            foreach (Book book in lst)
            {
                if (book.BookId > maxid)
                {
                    maxid = book.BookId;
                }
            }
            item.BookId = maxid + 1;
            db.Books.Add(item);
            await db.SaveChangesAsync();
            return item.BookId;
        }

        public async Task<List<Book>> TakeAll()
        {
            if (db.Books.Count() > 0)
                return await db.Books.Include(s => s.Reviews).ToListAsync();
            else return null; 
        }

        public async Task<Book> TakeById(int id)
        {
            Book book = await db.Books.Include(s => s.Reviews).ThenInclude(u => u.User).AsNoTracking().FirstAsync(r => r.BookId == id);
            return book;
        }

        public Book FindByName(string name)
        {
            return db.Books.FirstOrDefault(search => search.BookName == name);
        }

        public async Task DeleteById(int id)
        {
            List<Book> lst = db.Books.FromSqlRaw("SELECT * from delete_book({0})", id).ToList();
            await db.SaveChangesAsync();
        }
   
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
