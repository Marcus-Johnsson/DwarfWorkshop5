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


        public static string GetConnectionString()
        {
            return ConnectionString;
        }

      

        
    }
}