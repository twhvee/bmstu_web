using Course.Model;
using Course.Model.Users;
using Course.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RevWorld.Service;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace Course.Controllers.API
{
   // [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class usersController : ControllerBase
    {
        private static List<User> Users;
        private readonly UserService userService;
        public usersController(UserService userService)
        {
            this.userService = userService;
        }





       // [AllowAnonymous]
        [HttpGet("{id:int}")]
        public async Task<JsonResult> GetUser(int id)
        {
            bool success = true;
            var user = await userService.GetUser(id);
            if (user == null)
            {
                success = false;
            }

            UsertoSave User = new UsertoSave()
            {
                UserId = user.UserId,
                Login = user.Login,
                Password = user.Password,
                Avatar = user.Avatar,
                Access_role = user.Access_role

            };
            return success ? new JsonResult(User) : new JsonResult("User not found");
        }

        [HttpGet("{username}")]
        public async Task<JsonResult> GetUserByName(string username)
        {
            bool success = true;
            var user = await userService.GetUserByName(username);
            if (user == null)
            {
                success = false;
            }
            UsertoSave User = new UsertoSave()
            {
                UserId = user.UserId,
                Login = user.Login,
                Password = user.Password,
                Avatar = user.Avatar,
                Access_role = user.Access_role

            };
            return success ? new JsonResult(User) : new JsonResult("User not found");
        }
       // [AllowAnonymous]
        [HttpPost("register")]
        public async Task<JsonResult> Register(RegisterModel model)
        {
            User user;
            bool success = false;
            string role = "user";
            if (model.Type == "Да")
                role = "author";
            if (ModelState.IsValid)
            {
                int flag = await userService.CheckUserData(model.Login, model.Email, model.Password, EncryptPassword(model.Password));
                if (flag == 1)
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                if (flag == 2)
                    ModelState.AddModelError("", "Пользователь с такой почтой уже существует");
                if (flag == 3 || flag == 4)
                    ModelState.AddModelError("", "Измените пароль");
                if (flag == 0)
                {
                    user = new User { Login = model.Login, Password = EncryptPassword(model.Password), Avatar = model.Avatar, Email = model.Email, Access_role = role };
                    await userService.AddUser(user);
                    //await Authenticate(user);
                    success = true;
                }
            }
            return success ? new JsonResult("Registration successful") : new JsonResult("Add not successful");
        }

        [HttpGet]
        public async Task<JsonResult> GetAllUsersAsync()
        {
            List<User> lst = await userService.GetAllUsers();
            List<UsertoRead> users = new List<UsertoRead>();
            foreach (var userFromDB in lst)
            {
                UsertoRead user = new UsertoRead()
                {
                    UserId = userFromDB.UserId,
                    Login = userFromDB.Login,
                    Password = userFromDB.Password,
                    Avatar = userFromDB.Avatar,

                };

                users.Add(user);
            }
            return new JsonResult(users);
        }

        public static string EncryptPassword(string Password)
        {
            var data = Encoding.UTF8.GetBytes(Password);
            using SHA512 shaM = new SHA512Managed();
            var hashedInputBytes = shaM.ComputeHash(data);
            var hashedInputStringBuilder = new StringBuilder(128);
            foreach (var b in hashedInputBytes)
                hashedInputStringBuilder.Append(b.ToString("X2"));
            return hashedInputStringBuilder.ToString();
        }


       // [AllowAnonymous]
        [HttpPost("auth")]
        public async Task<IActionResult> TokenAsync(AuthModel model)
        {
            var identity = await GetIdentity(model.Login, model.Password);
            if (identity == null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }

            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };

            return new JsonResult(response);
        }

       // [AllowAnonymous]
        private async Task<ClaimsIdentity> GetIdentity(string username, string password)
        {
            List<User> users = await userService.GetAllUsers();
            User person = users.FirstOrDefault(x => x.Login == username && x.Password == EncryptPassword(password));
            User person1 = users.FirstOrDefault(x => x.Login == username && x.Password == password);

            if ( person1 != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person1.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, person1.Access_role)
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }
            else if (person != null )
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, person.Access_role)
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            // если пользователя не найдено
            return null;
        }


        [HttpDelete("{id}")]
        public async Task<JsonResult> DeleteUser(int id)
        {
            bool success = true;
            var document = await userService.GetUser(id);

            try
            {
                if (document != null)
                {
                    await userService.DeleteUser(document.UserId);
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
