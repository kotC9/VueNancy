using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiteDB;
using VueNancy.Backend.Models;

namespace VueNancy.Backend.Database
{
    public class DatabaseCommands
    {
        /// <param name="login"> auth login</param>
        /// <param name="password">auth password</param>
        /// <returns> true - if account exists, else false</returns>
        public static bool AccountExists(string login, string password)
        {
            using var db = new LiteDatabase(@"Users.db");

            var users = db.GetCollection<User>("users");

            var result = users.FindOne(Query.And(
                Query.EQ("Login", login),
                Query.EQ("Password", password)));

            //not found
            return result != null;
        }

        public static void AddCustomDataToDatabase(string login, string password)
        {
            using var db = new LiteDatabase(@"Users.db");

            var users = db.GetCollection<User>("users");

            users.Insert(new User
            {
                Login = login,
                Password = password
            });
        }
    }
}
