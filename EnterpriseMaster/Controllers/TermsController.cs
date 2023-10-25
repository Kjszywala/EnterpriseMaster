using Microsoft.AspNetCore.Mvc;

namespace EnterpriseMaster.Controllers
{
    public class TermsController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
