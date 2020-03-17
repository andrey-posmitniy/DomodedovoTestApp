using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.OData;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using DomodedovoTestApp.Logic.Repositories;
using DomodedovoTestApp.Models;

namespace DomodedovoTestApp.Controllers
{
    public class ODataUsersController : ODataController
    {
        private readonly ODataUsersRepository usersRepository = new ODataUsersRepository();


        [EnableQuery]
        public IQueryable<UserGridInfo> GetODataUsers()
        {
            return usersRepository.GetUsers();
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                usersRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}