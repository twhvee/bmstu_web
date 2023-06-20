using Course.Model;
using Course.Model.Users;
using Course.Service;
using Course.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RevWorld.Model;
using RevWorld.Model.Books;
using RevWorld.Model.Reviews;
using RevWorld.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RevWorld.Controllers
{
   // [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")] 
    public class reviewsController : ControllerBase
    {
        private static List<Review> Reviews;
        private readonly ReviewService revService;
        private readonly BookService bookService;
        private readonly TagReviewService trService;
        private readonly TagService tService;


        public reviewsController(ReviewService revService, TagReviewService trService, TagService tService, BookService bookService)
        {
            this.revService = revService;
            this.trService = trService;
            this.tService = tService;
            this.bookService = bookService;

        }



       // [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<JsonResult> Get(int id)
        {
            var revFromDB = await revService.GetReview(id);

            List<Tag> lsttag = new List<Tag>();

            List<TagReview> lst =  trService.TakeAll();

            foreach (TagReview tagrev in lst)
            {
                if (tagrev.ReviewId == revFromDB.ReviewId)
                {
                    Tag tag = await tService.GetTag((int)tagrev.TagId);
                    lsttag.Add(tag);
                }
            }

            ReviewtoRead rev = new ReviewtoRead
            {
                ReviewId = revFromDB.ReviewId,
                UserId = revFromDB.UserId,
                BookId = revFromDB.BookId,
                Title = revFromDB.Title,
                RaitingBook = revFromDB.RaitingBook,
                NumLikes = revFromDB.NumLikes,
                Public_date = revFromDB.Public_date,
                Review_data = revFromDB.Review_data,

                Book = new BooktoRead
                {
                    BookId = revFromDB.Book.BookId,
                    BookName = revFromDB.Book.BookName,
                    Author = revFromDB.Book.Author,
                    Path = revFromDB.Book.Path
                },

                User = new UsertoSave
                {
                    UserId = revFromDB.User.UserId,
                    Login = revFromDB.User.Login,
                    Avatar = revFromDB.User.Avatar

                },

                Tags = lsttag,
            };
            
            
            return new JsonResult(rev); 
        }

        //[AllowAnonymous]
        [HttpGet]
        public async Task<JsonResult> GetAllReviews()
        {
            List<ReviewtoRead> revs = new List<ReviewtoRead>();
            List<Review> lstrev = await revService.GetAllReviews();
            foreach (var revFromDB in lstrev)
            {
                List<Tag> lsttag = new List<Tag>();

                List<TagReview> lst = trService.TakeAll();

                foreach (TagReview tagrev in lst)
                {
                    if (tagrev.ReviewId == revFromDB.ReviewId)
                    {
                        Tag tag = await tService.GetTag((int)tagrev.TagId);
                        lsttag.Add(tag);
                    }
                } 

                ReviewtoRead rev = new ReviewtoRead()
                {

                    ReviewId = revFromDB.ReviewId,
                    UserId = revFromDB.UserId,
                    BookId = revFromDB.BookId,
                    Title = revFromDB.Title,
                    RaitingBook = revFromDB.RaitingBook,
                    NumLikes = revFromDB.NumLikes,
                    Review_data = revFromDB.Review_data,

                    Public_date = revFromDB.Public_date,

                    Book = new BooktoRead
                    {
                        BookId = revFromDB.Book.BookId,
                        BookName = revFromDB.Book.BookName,
                        Author = revFromDB.Book.Author,
                        Path = revFromDB.Book.Path
                    },

                    User = new UsertoSave
                    {
                        UserId = revFromDB.User.UserId,
                        Login = revFromDB.User.Login,
                        Avatar = revFromDB.User.Avatar,

                    },

                    Tags = lsttag,
                };

                revs.Add(rev);
            }
            return new JsonResult(revs);
        }

       // [AllowAnonymous]
        [HttpGet("findByTags")]
        public async Task<JsonResult> ReviewsByTag(string Tag)
        {
            bool success = true;
            List<ReviewtoRead> lstrev = new List<ReviewtoRead>();
            List<Review> lstTag = await revService.FilterReviewsByTag(Tag);
            if (lstTag == null)
            {
                success = false;
            }
            else
            {
                foreach (var revFromDB in lstTag)
                {
                    List<Tag> lsttag = new List<Tag>();

                    List<TagReview> lst =  trService.TakeAll();

                    foreach (TagReview tagrev in lst)
                    {
                        if (tagrev.ReviewId == revFromDB.ReviewId)
                        {
                            Tag tag = await tService.GetTag((int)tagrev.TagId);
                            lsttag.Add(tag);
                        }
                    }

                    ReviewtoRead rev = new ReviewtoRead()
                    {

                        ReviewId = revFromDB.ReviewId,
                        UserId = revFromDB.UserId,
                        BookId = revFromDB.BookId,
                        Title = revFromDB.Title,
                        RaitingBook = revFromDB.RaitingBook,
                        NumLikes = revFromDB.NumLikes,
                        Public_date = revFromDB.Public_date,

                        Book = new BooktoRead
                        {
                            BookId = revFromDB.Book.BookId,
                            BookName = revFromDB.Book.BookName,
                            Author = revFromDB.Book.Author,
                            Path = revFromDB.Book.Path
                        },

                        User = new UsertoSave
                        {
                            UserId = revFromDB.User.UserId,
                            Login = revFromDB.User.Login,
                            Avatar = revFromDB.User.Avatar,

                        }, 

                        Tags = lsttag,
                    };

                    lstrev.Add(rev);
                }
            }          
            return success ? new JsonResult(lstrev) : new JsonResult("Reviews not found");
        }

        [HttpPatch("{id}")]
        public async Task<JsonResult> LikesReview(int id)
        {
            /*
            Review revFromDB = new Review
            {
                ReviewId = rev.ReviewId,
                UserId = rev.UserId,
                BookId = rev.BookId,
                Title = rev.Title,
                RaitingBook = rev.RaitingBook,
                NumLikes = rev.NumLikes,
                Public_date = rev.Public_date
            };
            */
            await revService.LikesReview(id);
            return new JsonResult("Update success");
        }

        [HttpPost]
        public async Task<JsonResult> AddReview(MyrevModel rev)
        {
                Book book = bookService.GetBookByName(rev.BooKName);
                if (book != null)
                {
                    Review review = new Review { UserId = rev.UserId, BookId = book.BookId, RaitingBook = rev.RaitingBook, Title = rev.Title, Review_data = rev.Review_data, Public_date = (DateTime?)DateTime.Today, NumLikes = 0 };
                    int idrev = await revService.AddReview(review);
                    await revService.AddReviewTagAsync(rev.Tags, idrev);
            }
     

            //ReviewId = rev.ReviewId,
          
            return new JsonResult("add good");
        }

        [HttpDelete("{id}")]
        public async Task<JsonResult> DeleteReview(int id)
        {
            bool success = true;
            var document = await revService.GetReview(id);

            try
            {
                if (document != null)
                {
                   await revService.DeleteReview(id);
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
           
            //_commentsRepository.DeleteByReviewId(rev.ReviewId);
        }

    }
}
