using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Course.Model
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Не указан логин")]
        [Display(Name = "Логин")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Не указана почта")]
        [Display(Name = "Почта")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указана фото для аватара")]

        [Display(Name = "Аватар")]
        public string Avatar { get; set; }

        [Display(Name = "Зарегистрироваться как автор?")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

       
    }
}
