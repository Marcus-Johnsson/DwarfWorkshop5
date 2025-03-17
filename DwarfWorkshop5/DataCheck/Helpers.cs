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
    public class Helpers
    {
        private readonly MyDbContext _mydb;

        public Helpers(MyDbContext dbContext)
        { 
            _mydb = dbContext;
        }
        public static async Task<bool> CheckUsername(string username)
        {
            await Task.Delay(500); // Important for not overloading database

            using (var connection = new SqlConnection(GetSetData.GetConnectionString()))
            {

                await connection.OpenAsync();
                string query = "SELECT COUNT(*) FROM [User] WHERE Username = @Username";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    int count = (int)await command.ExecuteScalarAsync();

                    return count == 0;
                }
            }
        }

        public async Task<bool> SignInUser(string userName, string password)
        {
            try
            {
                var  userControll = _mydb.User.Where(p => p.Username == userName && p.Password == password).FirstOrDefault();

                if(userControll != null)
                {
                    GetSetData.SetCurrentUser(userControll.Id);
                    return true;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }
        public static void DwarfAvailable()
        {
            using (var mydb = new MyDbContext())
            {
                var currentUser = GetSetData.GetCurrentUser();
                var dwarf = mydb.Dwarfs.Where(p => p.UserId == currentUser.Id && p.Unlocked == false).FirstOrDefault();

                dwarf.Unlocked = true;

                mydb.SaveChanges();

            }
        }

        public void CreateDwarfs()
        {
            for (int i = 0; i < 5; i++)
            {
                new Dwarfs
                {
                    EffifencyRank = 1,
                    QualityRank = 0,
                    Rank = 1,
                    Unlocked = false,
                    UserId = GetSetData.GetCurrentUser().Id

                };
                _mydb.SaveChanges();
            }
        }
    }
}
