using Microsoft.EntityFrameworkCore;
using RevWorld.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevWorld.Service
{
    public class BookService
    {

        protected IBooksRepository _booksRepository;
        public BookService(IBooksRepository books)
        {
            _booksRepository = books;
        }

        public async Task<List<Book>> GetBooks()
        {
            return  await _booksRepository.TakeAll();
        }

        public async Task<Book> GetBook(int id)
        {
            return await _booksRepository.TakeById(id);
        }

        public async Task<int> CheckBook(string path)
        {
            List<Book> lst= await _booksRepository.TakeAll();
            int flag = 0;
            if (lst.FirstOrDefault(x => x.Path == path) == null)
                flag = 1;
            
            return flag;
        }

        public Book GetBookByName(string name)
        {
            return  _booksRepository.FindByName(name);

        }

        public async Task<int>  AddBook(Book book)
        {
            return await _booksRepository.Create(book);
        }

        public async Task DeleteBook(int id)
        {
            await _booksRepository.DeleteById(id);

        }
    }
}
