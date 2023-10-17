using Microsoft.AspNetCore.Mvc;

namespace EnterpriseMaster.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
