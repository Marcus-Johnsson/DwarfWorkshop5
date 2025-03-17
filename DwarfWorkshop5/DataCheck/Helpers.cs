using DwarfWorkshop5.DataCheck;
using DwarfWorkshop5.Models;
using Microsoft.Data.SqlClient;

namespace DwarfWorkhop5
{
    public class Helpers
    {
        private readonly UserSession _session;

        
        private readonly MyDbContext _mydb;

        public Helpers(MyDbContext dbContext)
        {
            _mydb = dbContext;
            _session = UserSession.GetInstance();
     
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
                var userControll = _mydb.User.Where(p => p.Username == userName && p.Password == password).FirstOrDefault();

                if (userControll != null)
                {
                    var session = UserSession.GetInstance();
                    session.SetUser(userControll.Id);
                    return true;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
            return false;
        }

        public async Task<bool> CheckDwarfAvailable()
        {
            var currentUser = _session.GetCurrentUser();
            var count = _mydb.Dwarfs.Where(p => p.UserId == currentUser.Id
                                     && p.Unlocked == false).Count();
            if (count == 0)
            {
                return false;
            }
            return true;
        }

        public void CreateDwarfs()
        {
            var currentUser = _session.GetCurrentUser();
            

            for (int i = 0; i < 5; i++)
            {
               var newDwarf = new Dwarfs
                {
                    EffifencyRank = 1,
                    QualityRank = 0,
                    Rank = 1,
                    Unlocked = false,
                    UserId = currentUser.Id,
                    Name = GetDwarfName().Result


                };
                _mydb.Dwarfs.Add(newDwarf);
            }
            _mydb.SaveChanges();
        }
        public async Task<string> GetDwarfName()
        {
            Random rng = new Random();
            string[] dwarfNames = { "Thorded Smeltbelly", "Erirhan Boulderhand",
                "Dhonmuki Underjaw", "Yutdrun Merryhand", "Kalmerlun Amberchin", "Dotdrerlun Warjaw",
                "Luddeath Woldhorn", "Yodmola Bonefury", "Grumrelda Lighthead", "Nenmorra Koboldmaster",
            "Loddaelin Caskbelly", "Nargrerra Flintbrand", "Jornealyn Bluntmaul"};

            int nameGen = rng.Next(1, dwarfNames.Count());
            return dwarfNames[nameGen];

        }
    }
}
