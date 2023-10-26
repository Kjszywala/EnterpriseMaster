using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseMaster.Controllers
{
    public class HomeController : BaseController
    {
        private IErrorLogsServices errorLogsServices;
        private IMainPageServices mainPageService;

        public HomeController(
            IErrorLogsServices _errorLogsServices,
            IMainPageServices _mainPageService
            )
        {
            errorLogsServices = _errorLogsServices;
            mainPageService = _mainPageService;
        }

        public async Task<IActionResult> IndexAsync()
        {
            try
            {
                var mainPageModel = (await mainPageService.GetAllAsync()).FirstOrDefault();
                if (mainPageModel == null)
                {
                    return RedirectToAction("Error");
                }
                return View(mainPageModel);
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                return RedirectToAction("Error");
            }
        }
    }
}