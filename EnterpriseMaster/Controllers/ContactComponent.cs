using Microsoft.AspNetCore.Mvc;

namespace EnterpriseMaster.Controllers
{
    public class ContactComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("ContactComponent");
        }
    }
}