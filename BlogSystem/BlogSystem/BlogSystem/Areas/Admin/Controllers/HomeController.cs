using BlogSystem.Admin.Models;
using BlogSystem.Admin.Reusable;
using BlogSystem.Reusable;
using BlogSystem.Reusable.Extentions;
using Service.IServices;
using Service.Properties;
using Service.Services;
using Service.Utilities;
using System.Web.Mvc;

namespace BlogSystem.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        private static IUserService _userService;

        public HomeController()
        {
            _userService = new UserService();
        }

        [Route("", Name = ControllerActionRouteNames.Admin.Home.DASHBOARD)]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("login", Name = "Login")]
        public ActionResult Login()
        {
            var model = new LoginViewModel
            {
                LoginUrl = Url.RouteUrl("Login"),
                RedirectUrl = Request.QueryString["RedirectUrl"]
            };

            return View(model);
        }

        [HttpPost]
        [Route("login")]
        public ActionResult Login(LoginViewModel model)
        {
            var user = _userService.GetByEmailAndPassword(model.Email, model.Password?.ToMD5());

            if (user == null)
            {
                model.ErrorMessage = Resources.ValidationInvalidEmailOrPassword;
                model.Password = null;
            }
            else if (!user.IsActive)
            {
                model.ErrorMessage = Resources.ValidationInvalidEmailOrPassword;
                model.Password = null;
            }
            else
            {
                Session[AppSettings.AuthenticatedUserKey] = user;
                return Redirect(model.RedirectUrl ?? "/");
            }

            return View(model);
        }

        [Route("logout", Name = "Logout")]
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToRoute("Dashboard");
        }
    }
}