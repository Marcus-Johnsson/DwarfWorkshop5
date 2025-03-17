using DwarfWorkshop5.Models;

namespace DwarfWorkshop5.DataCheck
{
    class UserSession
    {
        private static User _currentUser;

        public static User GetCurrentUser()
        {
            if (_currentUser == null)
            {
                using (var mydb = new MyDbContext())
                {
                    _currentUser = mydb.User.SingleOrDefault(p => p.Id == _userId);
                }
            }
            return _currentUser;
        }

        private static int _userId;

        public static void SetCurrentUser(int userId)
        {
            _userId = userId;
            using (var mydb = new MyDbContext())
            {
                _currentUser = mydb.User.SingleOrDefault(p => p.Id == userId);
            }
        }

        public static void Logout()
        {
            _currentUser = null;
            _userId = 0;
        }
    }
}

