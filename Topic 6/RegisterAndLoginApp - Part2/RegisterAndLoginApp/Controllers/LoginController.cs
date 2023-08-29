using Microsoft.AspNetCore.Mvc;
using NLog;
using RegisterAndLoginApp.Models;
using RegisterAndLoginApp.Services;
using RegisterAndLoginApp.Utility;

namespace RegisterAndLoginApp.Controllers
{
    public class LoginController : Controller
    {
        private static Logger logger = LogManager.GetLogger("LoginAppLoggerrule");

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProcessLogin(UserModel user)
        {
            MyLogger.GetInstance().Info("Entering the ProcessLogin method.");
            MyLogger.GetInstance().Info("Parameter: " + user.ToString());

            SecurityService securityService = new SecurityService();


            if (securityService.IsValid(user))
            {
                MyLogger.GetInstance().Info("Login Success");
                return View("LoginSuccess", user);
            }
            else
            {
                MyLogger.GetInstance().Info("Login Failure");
                return View("LoginFailure", user);
            }
        }
    }
}
