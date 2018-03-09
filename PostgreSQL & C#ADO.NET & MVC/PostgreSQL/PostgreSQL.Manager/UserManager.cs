using PostgreSQL.Entities;
using PostgreSQL.Service;
using System.Collections.Generic;
using System.Linq;

namespace PostgreSQL.Manager
{
    public class UserManager
    {
        private static UserManager _userManager;
        private static object lockObject = new object();

        private UserManager() { }

        public static UserManager CreateAsUserManager()
        {
            lock (lockObject)
                return _userManager ?? (_userManager = new UserManager());
        }

        tblUserService userService = new tblUserService();
        public List<tbluser> GetUserList()
        {
            return userService.GetList().Objects.ToList();
        }

        public bool UserInsert(tbluser user)
        {
            try
            {
                userService.Insert(user);
                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }
    }
}