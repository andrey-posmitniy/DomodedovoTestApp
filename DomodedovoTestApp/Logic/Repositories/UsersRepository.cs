using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DomodedovoTestApp.Logic.DataGenerators;
using DomodedovoTestApp.Models;
using DomodedovoTestApp.Properties;
using Microsoft.AspNet.Identity;
using WebGrease.Css.Ast.Selectors;

namespace DomodedovoTestApp.Logic.Repositories
{
    /// <summary>
    /// Репозиторий пользователей
    /// </summary>
    public class UsersRepository
    {
        /// <summary>
        /// Получить общее количество пользователей
        /// </summary>
        public int GetUsersCount()
        {
            using (var dc = GetDataContext())
            {
                return dc.Users.Count();
            }
        }

        /// <summary>
        /// Получить информацию о пользователе
        /// </summary>
        public UserInfo GetUserInfo(int? userId, string email)
        {
            using (var dc = GetDataContext())
            {
                var users = dc.Users.AsQueryable();
                if (userId.HasValue)
                {
                    users = users.Where(o => o.UserId == userId);
                }
                if (!string.IsNullOrEmpty(email))
                {
                    users = users.Where(o => o.Email == email);

                }

                var user = users.Select(o => new UserInfo
                    {
                        UserId = o.UserId,
                        Surname = o.Surname,
                        FirstName = o.FirstName,
                        SecondName = o.SecondName,
                        Phone = o.Phone,
                        Email = o.Email,
                        PictureMedium = o.PictureMedium,
                        PictureLarge = o.PictureLarge,
                        PasswordHash = o.PasswordHash,
                    })
                    .FirstOrDefault();
                return user;
            }
        }

        /// <summary>
        /// Произвести аутентификацию пользователя
        /// </summary>
        /// <returns>true - успешно, false - неуспешно</returns>
        public bool AuthUser(string email, string passwordHash)
        {
            using (var dc = GetDataContext())
            {
                var user = dc.Users.FirstOrDefault(o => o.Email == email);

                return dc.Users.Any(o => o.Email == email && o.PasswordHash == passwordHash);
            }

        }

        /// <summary>
        /// Массово добавить пользователей в БД
        /// </summary>
        public void BulkInsertUsers(UsersFromJson users)
        {

            if (users == null || users.results == null) { return; }

            var dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("Surname", typeof(string)));
            dataTable.Columns.Add(new DataColumn("FirstName", typeof(string)));
            dataTable.Columns.Add(new DataColumn("SecondName", typeof(string)));
            dataTable.Columns.Add(new DataColumn("DateOfBirth", typeof(DateTime)));
            dataTable.Columns.Add(new DataColumn("PasswordHash", typeof(string)));
            dataTable.Columns.Add(new DataColumn("PictureLarge", typeof(string)));
            dataTable.Columns.Add(new DataColumn("PictureMedium", typeof(string)));
            dataTable.Columns.Add(new DataColumn("PictureThumbnail", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Email", typeof(string)));
            dataTable.Columns.Add(new DataColumn("PasswordPlain", typeof(string)));
            dataTable.Columns.Add(new DataColumn("Phone", typeof(string)));

            foreach (var user in users.results)
            {
                var dr = dataTable.NewRow();
                dr["Surname"] = user.name.last;
                dr["FirstName"] = user.name.first;
                dr["DateOfBirth"] = user.dob.date;
                dr["PasswordHash"] = new PasswordHasher().HashPassword(user.login.password);
                dr["PictureLarge"] = user.picture.large;
                dr["PictureMedium"] = user.picture.medium;
                dr["PictureThumbnail"] = user.picture.thumbnail;
                dr["Email"] = user.email;
                dr["PasswordPlain"] = user.login.password;
                dr["Phone"] = user.phone;

                dataTable.Rows.Add(dr);
            }

            using (var connection = new SqlConnection(GetConnectionString()))
            {
                var bulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.KeepIdentity, null);
                foreach (DataColumn column in dataTable.Columns)
                {
                    bulkCopy.ColumnMappings.Add(column.ColumnName, column.ColumnName);
                }
                bulkCopy.DestinationTableName = "Users";
                
                connection.Open();
                bulkCopy.WriteToServer(dataTable);
                connection.Close();
            }
        }


        private UsersDataClassesDataContext GetDataContext()
        {
            return new UsersDataClassesDataContext(GetConnectionString());
        }

        private string GetConnectionString()
        {
            return Settings.Default.UsersDatabaseConnectionString;
        }
    }
}
