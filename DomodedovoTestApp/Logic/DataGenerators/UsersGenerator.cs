using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using DomodedovoTestApp.Logic.Repositories;
using DomodedovoTestApp.Properties;
using Newtonsoft.Json;

namespace DomodedovoTestApp.Logic.DataGenerators
{
    /// <summary>
    /// Класс, генерирующий в БД пользователей.
    /// Источник: https://randomuser.me
    /// </summary>
    public class UsersGenerator
    {
        private readonly Lazy<UsersRepository> usersRepository = new Lazy<UsersRepository>(() => new UsersRepository());


        public void Generate(int count)
        {
            // Получаем из генератора данные в 
            var json = GetJsonData(count);
            var usersFromJson = JsonConvert.DeserializeObject<UsersFromJson>(json);
            usersRepository.Value.BulkInsertUsers(usersFromJson);
        }

        /// <summary>
        /// Получить данные о пользователях в JSON-формате
        /// </summary>
        /// <returns></returns>
        private string GetJsonData(int count)
        {
            var url = string.Format(Settings.Default.GenerateUsersUrl, count);

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                return result;
            }
        }
    }
}