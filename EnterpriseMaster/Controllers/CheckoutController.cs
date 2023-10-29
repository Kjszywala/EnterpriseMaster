using Microsoft.AspNetCore.Mvc;

namespace EnterpriseMaster.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
