using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.Data.SqlClient;

namespace DwarfWorkhop5
{
    class Helpers
    {
        public static bool UsernameAvailable(string RegisterUsername)
        {
            string inputUsername = RegisterUsername;
            using (var connection = new SqlConnection(GetSetData.GetConnectionString()))
            {
                string query = "SELECT COUNT(*) FROM Users WHERE Username = @inputUsername";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@inputUsername", inputUsername);
                    int count = (int)command.ExecuteScalar();
                    return count == 0;
                }
            }
        }
    }
}
