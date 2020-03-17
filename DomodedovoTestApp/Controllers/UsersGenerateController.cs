using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DomodedovoTestApp.Logic.DataGenerators;
using DomodedovoTestApp.Logic.Repositories;
using DomodedovoTestApp.Models;

namespace DomodedovoTestApp.Controllers
{
    public class UsersGenerateController : Controller
    {
        private readonly Lazy<UsersRepository> usersRepository = new Lazy<UsersRepository>(() => new UsersRepository());
        private readonly Lazy<UsersGenerator> usersGenerator = new Lazy<UsersGenerator>(() => new UsersGenerator());


        [HttpGet]
        public ActionResult Index()
        {
            var model = GetModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(UsersGenerateModel model)
        {
            // Генерируем пользователей
            usersGenerator.Value.Generate(model.UsersCountToGenerate);

            // Создаем новую модель для отображения
            var newModel = GetModel();
            newModel.ResultMessage = string.Format("Сгенерировано {0} пользователей", model.UsersCountToGenerate);
            // Возвращаем результат
            return View(newModel);
        }


        /// <summary>
        /// Получить модель для основного представления
        /// </summary>
        private UsersGenerateModel GetModel()
        {
            var model = new UsersGenerateModel
            {
                UsersExistsCount = usersRepository.Value.GetUsersCount(),
                UsersCountToGenerate = 1,
            };
            return model;
        }
    }
}