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
                var authKey = "0";

                Console.WriteLine($"\nlogin attempt:");
                Console.WriteLine($"login: {user.Login}");
                Console.WriteLine($"pass: {user.Password}");

                return !DatabaseCommands.AccountExists(user.Login, user.Password, ref user)
                    ? Response.AsJson(new { success = false })
                    : Response.AsJson(new { success = true });
            });
        }
    }

}
