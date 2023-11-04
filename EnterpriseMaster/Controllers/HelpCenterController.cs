using Microsoft.AspNetCore.Mvc;

namespace EnterpriseMaster.Controllers
{
    public class HelpCenterController : BaseController
    {
        private ISupportCase
        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetString("id");
            if (string.IsNullOrEmpty(userId))
            {
                TempData["Warning"] = "You need to login to access this page!";
                return RedirectToAction("Index", "Login");
            };

            return View();
        }

        public IActionResult Create()
        {
            return View(Index);
        }
    }
}
