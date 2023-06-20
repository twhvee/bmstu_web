using Course.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RevWorld.Service
{
    public interface IUsersRepository: BaseRepository<User>
    {
        /// <summary>
        /// Searches for a Uset type object with Login equal to name.
        /// </summary>
        /// <param name="name">User name</param>
        /// <returns>User type object.</returns>
        public Task<User> FindByName(string name);
    }
}
