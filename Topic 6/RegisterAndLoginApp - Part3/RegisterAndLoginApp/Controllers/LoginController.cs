using Microsoft.AspNetCore.Mvc;
using NLog;
using RegisterAndLoginApp.Models;
using RegisterAndLoginApp.Services;
using RegisterAndLoginApp.Utility;
using Microsoft.AspNetCore.Http;

namespace RegisterAndLoginApp.Controllers
{
    public class LoginController : Controller
    {
        private static Logger logger = LogManager.GetLogger("LoginAppLoggerrule");

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [CustomAuthorization]
        public IActionResult PrivateSectionMustBeLoggedIn()
        {
            return Content(" I am protected method if the proper attribute is applied to me.");
        }

        [LogActionFilter]
        public IActionResult ProcessLogin(UserModel user)
        {
            //MyLogger.GetInstance().Info("Entering the ProcessLogin method.");
            //MyLogger.GetInstance().Info("Parameter: " + user.ToString());

            SecurityService securityService = new SecurityService();


            if (securityService.IsValid(user))
            {

                MyLogger.GetInstance().Info("Login Success");

                HttpContext.Session.SetString("username", user.UserName.ToString());

                return View("LoginSuccess", user);
            }
            else
            {
                MyLogger.GetInstance().Info("Login Failure");

                HttpContext.Session.Remove("username");
                return View("LoginFailure", user);
            }
        }
    }
}
