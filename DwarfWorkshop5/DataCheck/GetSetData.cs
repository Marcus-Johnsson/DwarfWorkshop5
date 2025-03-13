using DwarfWorkshop5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Appointments.DataProvider;

namespace DwarfWorkhop5
{
    class GetSetData
    {
        public static string ConnectionString = @"Server=.\SQLEXPRESS;Database=DwarfWorkShop;Trusted_Connection=True;TrustServerCertificate=true";

        public static int CurrentUser { get; set; }

        public static string GetConnectionString()
        {
            return ConnectionString;
        }

        public static User GetCurrentUser()
        {
            using (var mydb = new MyDbContext())
            {
                var currentUser = mydb.User.Where(p => p.Id == CurrentUser).SingleOrDefault();
                
                return currentUser;
            }
            
        }

        public static void SetCurrentUser(int value)
        {
            CurrentUser = value;
        }

        
    }
}