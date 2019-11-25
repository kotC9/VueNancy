using System;
using System.Collections.Generic;
using System.Text;
using Nancy;
using Nancy.ModelBinding;
using VueNancy.Backend.Database;
using VueNancy.Backend.Models;

namespace VueNancy.Backend.Modules
{
    public class SampleModule : BaseModule
    {
        public SampleModule()
        {
            Post("/login", args =>
            {
                var user = this.Bind<User>();

                return DatabaseCommands.AccountExists(user.Login, user.Password)
                    ? Response.AsJson(new { success = true })
                    : Response.AsJson(new { success = false });
            });

            Post("/add_login", args =>
            {
                var user = this.Bind<User>();

                DatabaseCommands.AddCustomDataToDatabase(user.Login, user.Password);

                return 0;
            });
        }
    }

}
