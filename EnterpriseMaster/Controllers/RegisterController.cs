using EnterpriseMaster.BusinessLogic.Interfaces;
using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseMaster.Controllers
{
    public class RegisterController : BaseController
    {
        #region Variables

        private IAuthenticationLogic authenticationLogic;
        private IUsersServices usersServices;

        #endregion

        #region Constructor

        public RegisterController(
            IAuthenticationLogic _authenticationLogic,
            IUsersServices _usersServices
            )
        {
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
        public async Task<IActionResult> Register(Users user)
        {
            var usersList = usersServices.GetAllAsync().Result;

            if(!authenticationLogic.IsPasswordRegexValid(user.Password))
            {
                ViewBag.Warning = "Password must meet the following criteria:\n"
                               + "1. At least 8 characters in length.\n"
                               + "2. Contains at least one capital letter (A-Z).\n"
                               + "3. Contains at least one digit (0-9).";
                return View("Index");
            }
            if (!authenticationLogic.IsEmailValidAsync(user.Email))
            {
                ViewBag.Warning = "Invalid Email!";
                return View("Index");
            }
            if (authenticationLogic.EmailAlreadyExist(user.Email, usersList).Result)
            {
                ViewBag.Warning = "Email already exists!";
                return View("Index");
            }

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.Password = hashedPassword;
            user.CreationDate = DateTime.Now;
            user.ModificationDate = DateTime.Now;

            var IsRegistered = await usersServices.AddAsync(user);
            if(IsRegistered)
            {
                TempData["Success"] = "Your registration is complete. You can now log in with your new account.";
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Danger = "Something went wrong! Please contact customer support.";
            return View("Index");
        }

        #endregion
    }
}
