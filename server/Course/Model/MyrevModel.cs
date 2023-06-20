using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Course.ViewModel
{
    public class MyrevModel
    {
        [Required(ErrorMessage = "Не указанo сщдержание")]
        [Display(Name = "Комментарий")]
        public string Review_data { get; set; }

        [Required(ErrorMessage = "Не указан заголовок")]
        [Display(Name = "Комментарий")]
        public string Title { get; set; }

        public string Tags { get; set; }

        [Required(ErrorMessage = "Не указана книга")]
        [Display(Name = "Комментарий")]
        public string BooKName { get; set; }

        [Required(ErrorMessage = "Не указан рейтинг")]
        [Display(Name = "Комментарий")]
        public int RaitingBook { get; set; }

        public int UserId { get; set; }
    }
}
