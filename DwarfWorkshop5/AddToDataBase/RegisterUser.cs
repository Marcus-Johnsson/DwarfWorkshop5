using DwarfWorkhop5;
using DwarfWorkshop5.DataCheck;
using DwarfWorkshop5.Models;

namespace DwarfWorkshop5.AddToDataBase
{
    public class RegisterUser
    {
        private readonly Helpers _helpers;

        public RegisterUser(Helpers helpers)
        {
            _helpers = helpers;
        }

        public void CreateNewUserStep1(string username, string password)
        {
            using (var mydb = new MyDbContext())
            {
                var user = new User()
                {
                    Gold = 0,
                    Username = username,
                    Password = password,
                    TokenAmount = 2,
                    TotalSale = 0,
                    LastSave = DateTime.UtcNow,
                    Lvl = 1

                };
                mydb.Add(user);
                mydb.SaveChanges();
                LoggInUser(username);
                _helpers.CreateDwarfs();
                CreateStartInventory();

            }

        }
        public void LoggInUser(string username)
        {
            using (var mydb = new MyDbContext())
            {
                var currentUser = mydb.User.Where(p => p.Username == username).FirstOrDefault();

                var session = UserSession.GetInstance();
                session.SetUser(currentUser.Id);
            }

        }
        public void CreateStartInventory()
        {
            var session = UserSession.GetInstance();
            User? loggedInUser = session.GetCurrentUser();
            using (var mydb = new MyDbContext())
            {
           

                mydb.Add(
                    new Inventory
                    {
                        UserId = loggedInUser.Id,
                        ProductId = 1,
                        Quality = false,
                        Quantity = 20
                    });
               
               
            }


        }
    }
}
