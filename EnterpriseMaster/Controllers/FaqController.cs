using Microsoft.AspNetCore.Mvc;

namespace EnterpriseMaster.Controllers
{
    public class FaqController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
