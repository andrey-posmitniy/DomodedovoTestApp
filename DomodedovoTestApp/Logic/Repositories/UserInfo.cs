using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DomodedovoTestApp.Logic.Repositories
{
    /// <summary>
    /// Информация о юзере
    ///  </summary>
    public class UserInfo
    {
        public int UserId { get; set; }
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string PictureMedium { get; set; }
        public string PictureLarge { get; set; }
        public string PasswordHash { get; set; }
    }
}