using Microsoft.AspNetCore.Mvc;

namespace EnterpriseMaster.Controllers
{
    public class HelpCenterController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
