using RevWorld.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace  RevWorld.Service
{
    public interface IBooksRepository : BaseRepository<Book>
    {
        /// <summary>
        /// Searches for a Book type object with BookName equal to name.
        /// </summary>
        /// <param name="name">Book name</param>
        /// <returns>Book type object.</returns>
        Book FindByName(string name);
    }
}
