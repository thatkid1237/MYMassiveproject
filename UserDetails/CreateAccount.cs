using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

using Linkedlistsstory.UserDetails.AppStorage;
using BCrypt.Net;

namespace Linkedlistsstory.UserDetails
{
    public class CreateAccount
    {
        public static void Add(string username, string password)
        {
            using var db = new APPDbContext();
            if (db.Accounts.Any(a => a.Username == username))
            {
                throw new InvalidOperationException("Username already exists.");
            }

            var newUser = new AccountData
            {
                Username = username,
                Password = BCrypt.Net.BCrypt.HashPassword(password)
            };

            db.Accounts.Add(newUser);
            db.SaveChanges();
        }
    }
}
