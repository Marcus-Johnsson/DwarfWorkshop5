using DwarfWorkhop5;
using DwarfWorkshop5.Models;

namespace DwarfWorkshop5.AddToDataBase
{
    public class RegisterUser
    {


        public void CreateNewUserStep1(string username, string password)
        {
            using (var mydb = new MyDbContext())
            {
                var user = new User()
                {
                    Gold = 0,
                    Username = username,
                    Password = password,
                    TokenAmount = 0,
                    TotalSale = 0,
                    LastSave = DateTime.UtcNow,
                    Lvl = 1

                };
                mydb.Add(user);
                mydb.SaveChanges();

                LoggInUser(username);
                CreateStartInventory();
            }

        }
        public void LoggInUser(string username)
        {
            using (var mydb = new MyDbContext())
            {
                var currentUser = mydb.User.Where(p => p.Username == username).FirstOrDefault();

                GetSetData.SetCurrentUser(currentUser.Id);
            }

        }
        public void CreateStartInventory()
        {
            using (var mydb = new MyDbContext())
            {
                var currentUser = GetSetData.GetCurrentUser();

                mydb.Add(new Inventory

                {   
                    UserId = currentUser.Id,
                    ProductId = 1,
                    Quality = false,
                    Quantity = 20
                });
                mydb.SaveChanges();
            }


        }
    }
}
