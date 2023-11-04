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
        private IErrorLogsServices errorLogsServices;
        #endregion

        #region Constructor

        public LoginController(
            IHttpContextAccessor _httpContextAccessor,
            IAuthenticationLogic _authenticationLogic,
            IUsersServices _usersServices,
            IErrorLogsServices _errorLogService
            )
        {
            httpContextAccessor = _httpContextAccessor;
            authenticationLogic = _authenticationLogic;
            usersServices = _usersServices;
            errorLogsServices = _errorLogService;
        }

        #endregion

        #region Methods

        public IActionResult Index()
        {

            if (TempData["Warning"] != null)
            {
                ViewBag.Warning = TempData["Warning"];
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginAsync(Users user)
        {
            try
            {
                var usersList = usersServices.GetAllAsync().Result;
                var loggingInUser = usersList.Where(item => item.Email == user.Email).FirstOrDefault();

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
                    httpContext.Session.SetString("id", loggingInUser.Id.ToString());
                    TempData["Success"] = "Logged in successfully.";
                    return RedirectToAction("Index", "Home");
                }

                ViewBag.Danger = "Incorrect password!";
                return View("Index");
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                return RedirectToAction("Error");
            }
        }

        public async Task<IActionResult> LogoutAsync()
        {
            try
            {
                HttpContext.Session.Clear();
                TempData["Success"] = "Logged out successfully.";
                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                return RedirectToAction("Error");
            }
        }

        #endregion
    }
}
