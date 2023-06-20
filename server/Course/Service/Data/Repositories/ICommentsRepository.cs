using Course.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RevWorld.Service
{
    public interface ICommentsRepository: BaseRepository<Comment>
    {
        /// <summary>
        /// Increases the NumLikes value by 1.
        /// </summary>
        /// <param name="comid">ID of the object to update.</param>
        Task UpdateLikes(int comid);

        Task<List<Comment>> GetByRev(int id);

    }
}
