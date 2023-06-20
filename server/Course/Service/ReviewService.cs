using Course.Model;
using Microsoft.EntityFrameworkCore;
using RevWorld.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using Course.Service;

namespace RevWorld.Service
{
    public class ReviewService
    {
        protected IReviewsRepository _reviewsRepository;
        protected ITagsRepository _tagsRepository;
        protected ITagReviewRepository _trService;


        public ReviewService(IReviewsRepository reviews, ITagsRepository tags, ITagReviewRepository trService)
        {
            _reviewsRepository = reviews;
            _tagsRepository = tags;
            _trService = trService;
        }
        public async Task<List<Review>> GetAllReviews()
        {
            return await _reviewsRepository.TakeAll();
        }

        public async Task<Review> GetReview(int id)
        {
            return await _reviewsRepository.TakeById(id);
        }

        public async Task<List<Review>> FilterReviewsByTag(string name)
        {
            List<Review> lst = await _reviewsRepository.FindByTag(name);
            if (lst != null)
            {
                return lst;
            }
            return null;
        }

        public async void AddReviewTag(string stags, int idrev)
        {
            string[] tags = stags.Split(' ');
            foreach (var tagitem in tags)
            {
                Tag tag =  await _tagsRepository.FindByName(tagitem);
                if (tag is null)
                {
                    Tag t = new Tag { TagName = tagitem };
                    int id = await _tagsRepository.Create(t);
                    TagReview trev = new TagReview { TagId = id, ReviewId = idrev };
                    await _trService.Create(trev);
                }
                else
                {
                    TagReview trev = new TagReview { TagId = tag.TagId, ReviewId = idrev };
                    await _trService.Create(trev);
                }
            }
        }

        public async Task LikesReview(int id)
        {
           await _reviewsRepository.UpdateLikes(id);
        }

        public async Task<int> AddReview(Review rev)
        {
            return await _reviewsRepository.Create(rev);
        }

        public async Task AddReviewTagAsync(string stags, int idrev)
        {
            string[] tags = stags.Split(' ');
            foreach (var tagitem in tags)
            {
                Tag tag = await _tagsRepository.FindByName(tagitem);
                if (tag is null)
                {
                    Tag t = new Tag { TagName = tagitem };
                    int id = await _tagsRepository.Create(t);
                    TagReview trev = new TagReview { TagId = id, ReviewId = idrev };
                    await _trService.Create(trev);
                }
                else
                {
                    TagReview trev = new TagReview { TagId = tag.TagId, ReviewId = idrev };
                    await _trService.Create(trev);
                }              
            }
        }

        public async Task DeleteReview(int id)
        {
            await _reviewsRepository.DeleteById(id);
           
        }
    }
}

