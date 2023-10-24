using Microsoft.AspNetCore.Mvc;

namespace EnterpriseMaster.Controllers
{
    public class TermsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
