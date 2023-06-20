using Course.Model;
using Microsoft.EntityFrameworkCore;
using RevWorld.Model;
using RevWorld.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course.Service
{
    public class CommentService
    {
        protected ICommentsRepository _commentsRepository;

        public CommentService(ICommentsRepository comments)
        {
            _commentsRepository = comments;
        }
        public async Task<List<Comment>> GetAllComments()
        {
            return await _commentsRepository.TakeAll();
        }

        
        public async Task<Comment> GetComment(int id)
        {
            return await _commentsRepository.TakeById(id);
        }

        public async Task<List<Comment>> GetCommentByReviewId(int id)
        {
            return await _commentsRepository.GetByRev(id);
        }


        public async Task LikesComment(int id)
        {
           await _commentsRepository.UpdateLikes(id);
        }

        public async Task<int> AddComment(Comment com)
        {
           return  await _commentsRepository.Create(com);

        }

        public async Task DeleteComment(int id)
        {
            await _commentsRepository.DeleteById(id);
        }
    }
}
