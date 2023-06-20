using Course.Model;
using Course.Model.Comments;
using Course.Model.Users;
using Course.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RevWorld.Model;
using RevWorld.Model.Reviews;
using RevWorld.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.Controllers.API
{
    [ApiController]
    //[Authorize]
    [Route("api/v1/[controller]")]
    public class commentsController : ControllerBase
    {
         private static List<Comment> Comments;
         private readonly CommentService comService;

        public commentsController(CommentService comService)
        {
            this.comService = comService;
        }
            //[AllowAnonymous]
            [HttpGet]
            public async Task<JsonResult> GetAllComments()
            {
                List<CommenttoRead> coms = new List<CommenttoRead>();
                List<Comment> lst = await comService.GetAllComments();
                foreach (var comFromDB in lst)
                {
                    CommenttoRead com = new CommenttoRead
                    {
                        CommentId = comFromDB.CommentId,
                        UserId = comFromDB.UserId,
                        ReviewId = comFromDB.ReviewId,
                        NumLikes = comFromDB.NumLikes,
                        Comment_data = comFromDB.Comment_data,
                        Public_date = comFromDB.Public_date,


                        Review = new ReviewtoSave
                        {
                            //ReviewId = comFromDB.Review.ReviewId,
                            UserId = comFromDB.Review.UserId,
                            BookId = comFromDB.Review.BookId,
                            Title = comFromDB.Review.Title,
                            RaitingBook = comFromDB.Review.RaitingBook,
                            NumLikes = comFromDB.Review.NumLikes,
                            Public_date = comFromDB.Review.Public_date,
                        },


                        User = new UsertoSave
                        {
                            UserId = comFromDB.User.UserId,
                            Login = comFromDB.User.Login,
                            Avatar = comFromDB.User.Avatar,

                        }
                    };

                    coms.Add(com);
                }
            return new JsonResult(coms);
            }

        

           // [AllowAnonymous]
            [HttpGet("{id}")]
            public async Task<JsonResult> GetCommentById(int id)
            {
            List<CommenttoRead> coms = new List<CommenttoRead>();
            List<Comment> comFromDB = await comService.GetCommentByReviewId(id);

            foreach (var com in comFromDB)
            {

                CommenttoRead newcom = new CommenttoRead
                {
                    CommentId = com.CommentId,
                    UserId = com.UserId,
                    ReviewId = com.ReviewId,
                    NumLikes = com.NumLikes,
                    Comment_data = com.Comment_data,
                    Public_date = com.Public_date,

                    User = new UsertoSave
                    {
                        UserId = com.User.UserId,
                        Login = com.User.Login,
                        Avatar = com.User.Avatar,

                    }
                };
                coms.Add(newcom);
            }

            return new JsonResult(coms);
            }

        /*
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<JsonResult> GetCommentById(int id)
        {

            Comment comFromDB = await comService.GetComment(id);
            CommenttoRead com = new CommenttoRead
            {
                CommentId = comFromDB.CommentId,
                UserId = comFromDB.UserId,
                ReviewId = comFromDB.ReviewId,
                NumLikes = comFromDB.NumLikes,
                Comment_data = comFromDB.Comment_data,
                Public_date = comFromDB.Public_date,


                Review = new ReviewtoSave
                {
                    //ReviewId = comFromDB.Review.ReviewId,
                    UserId = comFromDB.Review.UserId,
                    BookId = comFromDB.Review.BookId,
                    Title = comFromDB.Review.Title,
                    RaitingBook = comFromDB.Review.RaitingBook,
                    NumLikes = comFromDB.Review.NumLikes,
                    Public_date = comFromDB.Review.Public_date,
                },


                User = new UsertoSave
                {
                    UserId = comFromDB.User.UserId,
                    Login = comFromDB.User.Login,
                    Avatar = comFromDB.User.Avatar,

                }
            };

            return new JsonResult(com);
        }
        */
        [HttpPatch("{id}")]
            public async  Task<JsonResult> LikesComment(int id)
            {
                bool success = true;
                var document = await comService .GetComment(id);
                try
                {
                    if (document != null)
                    {
                        await comService.LikesComment(document.CommentId);
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
                return success ? new JsonResult("Update success") : new JsonResult("Update comment not found");
            }

            [HttpPost]
            public async Task<JsonResult> AddComment(CommenttoSave com)
            {
                Comment com1 = new Comment()
                {

                    //ReviewId = rev.ReviewId,
                   
                    UserId = com.UserId,
                    ReviewId = com.ReviewId,
                    NumLikes = com.NumLikes,
                    Comment_data = com.Comment_data,
                    Public_date = com.Public_date,
                };
            return new JsonResult(await comService.AddComment(com1));
            }

            [HttpDelete("{id}")]
            public async Task<JsonResult> DeleteComment(int id)
            {
                bool success = true;
                var document = await comService .GetComment(id);

                try
                {
                    if (document != null)
                    {
                       await comService.DeleteComment(document.CommentId);
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
                //comService.DeleteComment(com.CommentId);
               
            }

        }
 }

