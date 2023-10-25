using Microsoft.AspNetCore.Mvc;

namespace EnterpriseMaster.Controllers
{
    public class ContactController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
