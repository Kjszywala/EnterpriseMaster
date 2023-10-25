using Microsoft.AspNetCore.Mvc;

namespace EnterpriseMaster.Controllers
{
	public class PrivacyController : BaseController
    {
		public IActionResult Index()
		{
			return View();
		}
	}
}
