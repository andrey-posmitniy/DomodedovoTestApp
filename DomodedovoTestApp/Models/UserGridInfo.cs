using System;

namespace DomodedovoTestApp.Models
{
    /// <summary>
    /// Информация о пользователе для отображения в гриде
    /// </summary>
    public class UserGridInfo
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PictureThumbnail { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}