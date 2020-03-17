using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DomodedovoTestApp.Models
{
    /// <summary>
    /// Модель для страницы конкретного пользователя
    /// </summary>
    public class UserCardModel
    {
        public int UserId { get; set; }

        [Display(Name = "Фамилия")]
        public string Surname { get; set; }
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        [Display(Name = "Отчество")]
        public string SecondName { get; set; }
        [Display(Name = "Телефон")]
        public string Phone { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        
        public string PictureMedium { get; set; }
        public string PictureLarge { get; set; }

        /// <summary>
        /// Текст ошибки, произошедшей при получении пользователя
        /// </summary>
        public string ErrorMessage { get; set; }


        public string FullName
        {
            get
            {
                return string.Format("{0} {1} {2}", Surname, FirstName, SecondName)
                    .Trim();
            }
        }
    }
}