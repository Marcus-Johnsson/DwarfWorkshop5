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
        public static string ConnectionString = @"Server=.\SQLEXPRESS;Database=DwarfWorkShop;Trusted_Connection=True;e;TrustServerCertificate=true";

        public static int CurrentUser { get; set; }

        public static string GetConnectionString()
        {
            return ConnectionString;
        }

        public static int GetCurrentUser()
        {
            return CurrentUser;
        }

        public static void SetCurrentUser(int value)
        {
            CurrentUser = value;
        }

        
    }
}