using Microsoft.AspNetCore.Mvc;

namespace EnterpriseMaster.Controllers
{
    public class DownloadsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
