using Microsoft.AspNetCore.Mvc;

namespace EnterpriseMaster.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
