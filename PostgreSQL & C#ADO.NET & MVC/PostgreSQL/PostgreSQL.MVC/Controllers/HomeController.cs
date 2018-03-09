using PostgreSQL.Entities;
using PostgreSQL.Manager;
using PostgreSQL.MVC.ViewModel;
using System.Web.Mvc;

namespace PostgreSQL.MVC.Controllers
{
    public class HomeController : Controller
    {
        private UserManager userManager = UserManager.CreateAsUserManager();
        public ActionResult Index()
        {
            HomeViewModel vm = new HomeViewModel();
            vm.UserList = userManager.GetUserList();
            vm.User = new tbluser();

            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(HomeViewModel model)
        {
            bool result = userManager.UserInsert(model.User);

            return RedirectToAction("Index");
        }
    }
}