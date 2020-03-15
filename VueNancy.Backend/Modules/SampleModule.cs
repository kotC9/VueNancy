using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;
using Nancy;
using Nancy.Configuration;
using Nancy.Extensions;
using Nancy.Json;
using Nancy.ModelBinding;
using Nancy.Responses;
using VueNancy.Backend.Database;
using VueNancy.Backend.Models;

namespace VueNancy.Backend.Modules
{
    public class SampleModule : BaseModule
    {
        public SampleModule()
        {
            AddRoutes();
        }

        private void AddRoutes()
        {
            Post("/login", args =>
            {
                //model binding
                var user = this.Bind<User>();


                return DatabaseCommands.AccountExists(user.Login, user.Password)
                    ? Response.AsJson(new { success = true })
                    : Response.AsJson(new { success = false });
            });

            Post("/add_login", args =>
            {
                var user = this.Bind<User>();
                var httpFiles = Request.Files.ToArray();

                DatabaseCommands.AddCustomDataToDatabase(user.Login, user.Password);

                return HttpStatusCode.OK;
            });
        }
    }
}
