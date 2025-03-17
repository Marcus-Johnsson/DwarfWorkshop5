using DwarfWorkshop5.Models;

namespace DwarfWorkshop5.DataCheck
{
    class UserSession
    {
        private static User? _currentUser;
       
        private static int _userId;


        private static readonly UserSession _instance = new UserSession();

        private UserSession() { }
        public static UserSession GetInstance()
        {
            return _instance;
        }
 
        public void SetUser(int userId)
        {
            _userId = userId;
            using (var mydb = new MyDbContext())
            {
                _currentUser = mydb.User.SingleOrDefault(p => p.Id == _userId);
            }
        }

        public User? GetCurrentUser()
        {
            return _currentUser;
        }
        public static void Logout()
        {
            _currentUser = null;
            _userId = 0;
        }
    }
}

