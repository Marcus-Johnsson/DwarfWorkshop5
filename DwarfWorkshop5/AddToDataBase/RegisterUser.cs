using DwarfWorkhop5;
using DwarfWorkshop5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DwarfWorkshop5.AddToDataBase
{
    class RegisterUser
    {
        public static void CreateNewUserStep1(string username, string password)
        {
            var user = new User()
            {
                Gold = 0,
                Username = username,
                Password = password,
                TokenAmount = 0,
                TotalSale = 0,

            };
            using (var mydb = new MyDbContext())
            {
                mydb.Add(user);
                mydb.SaveChanges();
            }
            LoggInUser(username);
        }
        public static void LoggInUser(string username)
        {
            using (var mydb = new MyDbContext())
            {
                var currentUser = mydb.User.Where(p => p.Username == username).FirstOrDefault();

                GetSetData.SetCurrentUser(currentUser.Id);
            }
        }
        public static void CreateStartInventory()
        {
            using(var  mydb = new MyDbContext())
            {

            }
        }
    }
}
