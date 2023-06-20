using Course.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RevWorld.Service
{
    public interface ITagsRepository: BaseRepository<Tag>
    {
        /// <summary>
        /// Searches for a Tag type object with Tagname equal to name.
        /// </summary>
        /// <param name="name">Tag name</param>
        /// <returns>Tag type object.</returns>
        Task<Tag> FindByName(string name);
 
    }
    
}
