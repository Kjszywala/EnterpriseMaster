using Microsoft.AspNetCore.Mvc;

namespace EnterpriseMaster.Controllers
{
    public class LoginController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
