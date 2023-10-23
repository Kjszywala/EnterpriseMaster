using Microsoft.AspNetCore.Mvc;

namespace EnterpriseMaster.Controllers
{
    public class BasicSubscriptionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
