using Model;
using Service;
using Service.ServiceClass;
using System.Web.Mvc;

namespace BaseWebProjectLayer.Controllers
{
    //[Authorize]
    public class UserController : Controller
    {
        private static IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetUser(string name)
        {
            var userDetail = new User() { Name = "karthik", Password = "kannan" };
            var user = _userService.Login(userDetail);
            //var wcfUserModel = new UserServiceWCF().Login(userDetail);
            return Json(user, JsonRequestBehavior.AllowGet);
        }
    }
}
