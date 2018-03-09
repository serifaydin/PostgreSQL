using PostgreSQL.Entities;
using System.Collections.Generic;

namespace PostgreSQL.MVC.ViewModel
{
    public class HomeViewModel
    {
        public List<tbluser> UserList { get; set; }
        public tbluser User { get; set; }
    }
}