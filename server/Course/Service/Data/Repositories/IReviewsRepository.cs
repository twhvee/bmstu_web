using RevWorld.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RevWorld.Service
{
    public interface IReviewsRepository: BaseRepository<Review>
    {
        /// <summary>
        /// Returns objects of the Review type that have certain tag values.
        /// </summary>
        /// <param name="name">Tag Name</param>
        /// <returns>List of Review type objects.</returns>
        Task<List<Review>> FindByTag(string name);

        /// <summary>
        /// Increases the NumLikes value by 1.
        /// </summary>
        /// <param name="revid">ID of the object to update.</param>
        Task UpdateLikes(int revid);
    }
}
