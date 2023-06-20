using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RevWorld.Model;
using RevWorld.Model;
using RevWorld.Model.Books;
using RevWorld.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevWorld.Controllers.API
{
    [ApiController]
   // [Authorize]

    [Route("api/v1/[controller]")]
    public class booksController : ControllerBase
    {
        private static List<Model.Book> Books;
        private readonly BookService bService;



        public  booksController(BookService bService)
        {
            this.bService = bService;
        }

        //[AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<JsonResult> GetBook(int id)
        {
            bool success = true; 
            var book = await bService .GetBook(id);
            if (book == null)
            {
                success = false;
            }
            Model.Books.BooktoRead book1 = new Model.Books.BooktoRead()
            {

                BookId = book.BookId,
                BookName = book.BookName,
                Author = book.Author,
                Path = book.Path
            };
            return success ? new JsonResult(book1) : new JsonResult("Book not found");
        }

        //[AllowAnonymous]
        [HttpGet]
        public async Task<JsonResult> GetAllBooks()
        {
            List<BooktoRead> books = new List<BooktoRead>();
            List<Book> lst = await bService.GetBooks();
            foreach (var bookFromDB in lst)
            {
                BooktoRead book = new BooktoRead()
                {

                    BookId = bookFromDB.BookId,
                    BookName = bookFromDB.BookName,
                    Author = bookFromDB.Author,
                    Path = bookFromDB.Path
                };

                books.Add(book);
            }
            return new JsonResult(books);
        }

        [HttpPost]
        public async Task<JsonResult> AddBook(BooktoSave book)
        {
            Book book1 = new Book
            {
                //BookId = book.BookId,
                BookName = book.BookName,
                Author = book.Author,
                Path = book.Path
            };
            return new JsonResult(await bService.AddBook(book1));
        }

        [HttpDelete("{id}")]
        public async Task<JsonResult> DeleteBook(int id)
        { 
            bool success = true;
            var document = await bService.GetBook(id);

            try
            {
                if (document != null)
                {
                     await bService.DeleteBook(document.BookId);
                }
                else
                {
                    success = false;
                }
            }
            catch (Exception)
            {
                success = false;
            }

            return success ? new JsonResult("Delete successful") : new JsonResult("Delete was not successful");

        }
    }
}
