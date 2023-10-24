using Microsoft.AspNetCore.Mvc;

namespace EnterpriseMaster.Controllers
{
    public class HelpCenterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
