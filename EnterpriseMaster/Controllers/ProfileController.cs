using Microsoft.AspNetCore.Mvc;

namespace EnterpriseMaster.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
