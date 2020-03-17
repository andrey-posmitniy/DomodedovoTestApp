using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace DomodedovoTestApp.Models
{
    /// <summary>
    /// Модель страницы генерации пользователей
    /// </summary>
    public class UsersGenerateModel
    {
        /// <summary>
        /// Количество уже существующих пользователей
        /// </summary>
        [Display(Name = "Количество уже существующих пользователей")]
        public int UsersExistsCount { get; set; }

        /// <summary>
        /// Количество пользователей для генерации
        /// </summary>
        [Display(Name = "Количество пользователей для генерации")]
        public int UsersCountToGenerate { get; set; }

        /// <summary>
        /// Результат генерации
        /// </summary>
        [Display(Name = "Результат генерации")]
        public string ResultMessage { get; set; }
    }
}