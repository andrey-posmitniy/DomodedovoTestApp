using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.OData.Batch;
using System.Web.Http.OData.Builder;
using DomodedovoTestApp.Models;

namespace DomodedovoTestApp
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<UserGridInfo>("ODataUsers");
            config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
        }
    }
}