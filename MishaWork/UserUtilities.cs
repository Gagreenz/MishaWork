using MishaWork.Models;
using MishaWork.MyDbContext;

namespace MishaWork
{
    public class UserUtilities
    {
        static User currentUser;

        public static void SetUser(User user)
        {
            currentUser = user;
        }
        public static User GetUser()
        {
            return currentUser;
        }
        //public static UserUtilities()
        //{
        //    if (currentUser == null)
        //    {
        //        d
        //    }
        //}
    }
}
