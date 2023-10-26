using EnterpriseMaster.BusinessLogic.Interfaces;
using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseMaster.Controllers
{
    public class LoginController : BaseController
    {
        #region MyRegion

        private readonly IHttpContextAccessor httpContextAccessor;
        private IAuthenticationLogic authenticationLogic;
        private IUsersServices usersServices;
        #endregion

        #region Constructor

        public LoginController(
            IHttpContextAccessor _httpContextAccessor,
            IAuthenticationLogic _authenticationLogic,
            IUsersServices _usersServices
            )
        {
            httpContextAccessor = _httpContextAccessor;
            authenticationLogic = _authenticationLogic;
            usersServices = _usersServices;
        }

        #endregion

        #region Methods

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Users user)
        {
            var usersList = usersServices.GetAllAsync().Result;
            var loggingInUser = usersList.Where(item=>item.Email == user.Email).FirstOrDefault();

            if (loggingInUser == null)
            {
                ViewBag.Danger = "User does not exist!";
                return View("Index");
            }

            // Access HttpContext through the _httpContextAccessor
            if (authenticationLogic.AuthenticateAsync(user, usersList).Result)
            {
                var httpContext = httpContextAccessor.HttpContext;
                httpContext.Session.SetString("IsLoggedIn", "true");
                httpContext.Session.SetString("email", user.Email);
                TempData["Success"] = "You are logged in.";
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        #endregion
    }
}
