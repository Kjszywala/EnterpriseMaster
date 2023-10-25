using Microsoft.AspNetCore.Mvc;

namespace EnterpriseMaster.Controllers
{
    public class FaqController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
