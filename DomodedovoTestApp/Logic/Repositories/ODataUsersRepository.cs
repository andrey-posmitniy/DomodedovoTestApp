using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DomodedovoTestApp.Models;
using DomodedovoTestApp.Properties;

namespace DomodedovoTestApp.Logic.Repositories
{
    public class ODataUsersRepository : IDisposable
    {
        private UsersDataClassesDataContext dc = new UsersDataClassesDataContext(Settings.Default.UsersDatabaseConnectionString);


        public IQueryable<UserGridInfo> GetUsers()
        {
            var users = dc.Users
                .Select(o => new UserGridInfo
                {
                    UserId = o.UserId,
                    FullName = o.Surname 
                        + " " + o.FirstName 
                        + ((o.SecondName + " ") ?? "")
                        ,
                    DateOfBirth = o.DateOfBirth.Value,
                    PictureThumbnail = o.PictureThumbnail,
                    Email = o.Email,
                    Password = o.PasswordPlain,
                });
            return users;
        }


        public void Dispose()
        {
            if (dc != null)
            {
                dc.Dispose();
            }
        }
    }
}