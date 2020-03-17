using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DomodedovoTestApp.Logic.Repositories;
using DomodedovoTestApp.Models;

namespace DomodedovoTestApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly Lazy<UsersRepository> usersRepository = new Lazy<UsersRepository>(() => new UsersRepository());

        
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult User(int id)
        {
            var user = usersRepository.Value.GetUserInfo(id, null);
            UserCardModel model;
            if (user == null)
            {
                model = new UserCardModel
                {
                    UserId = id,
                    ErrorMessage = "Пользователь не найден",
                };
            }
            else
            {
                model = new UserCardModel
                {
                    UserId = user.UserId,
                    Surname = user.Surname,
                    FirstName = user.FirstName,
                    SecondName = user.SecondName,
                    Phone = user.Phone,
                    Email = user.Email,
                    PictureMedium = user.PictureMedium,
                    PictureLarge = user.PictureLarge,
                };
            }

            return View(model);
        }
    }
}