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
    public class UserService
    {
        
        protected IUsersRepository _usersRepository;

        public UserService( IUsersRepository users)
        {         
            _usersRepository = users;
        }
        public async Task<int> AddUser(User user)
        {
            return await _usersRepository.Create(user);
        }

        public async Task<User> CheckUser(User user)
        {
            return await _usersRepository.FindByName(user.Login);
        }

        public async Task<User> GetUser(int id)
        {
            return await _usersRepository.TakeById(id);
        }

        public async Task DeleteUser(int id)
        {
            await _usersRepository.DeleteById(id);

        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _usersRepository.TakeAll();
        }

        public async Task<User> GetUserByName(string name)
        {
            return await _usersRepository.FindByName(name);

        }

        public async Task<int> CheckUserData(string login, string email, string pass, string epass)
        {
            List<User> lst = await _usersRepository.TakeAll();
            int flag = 0;
            if (lst.FirstOrDefault(x => x.Login == login) != null)
                flag = 1;
            if (lst.FirstOrDefault(x => x.Email == email) != null)
                flag = 2;
            if (lst.FirstOrDefault(x => x.Password == pass) != null)
                flag = 3;
            if (lst.FirstOrDefault(x => x.Password == epass) != null)
                flag = 4;
            return flag;                       
        }

    }
}
