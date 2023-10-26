using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseMaster.Controllers
{
    public class HomeController : BaseController
    {
        #region Variables

        private IErrorLogsServices errorLogsServices;
        private IMainPageServices mainPageService;

        #endregion

        #region Constructor

        public HomeController(
            IErrorLogsServices _errorLogsServices,
            IMainPageServices _mainPageService
            )
        {
            errorLogsServices = _errorLogsServices;
            mainPageService = _mainPageService;
        }

        #endregion

        #region Methods

        public async Task<IActionResult> IndexAsync()
        {
            try
            {
                var mainPageModel = (await mainPageService.GetAllAsync()).FirstOrDefault();

                if (mainPageModel == null)
                {
                    return RedirectToAction("Error");
                }

                if (TempData["Warning"] != null)
                {
                    ViewBag.Warning = TempData["Warning"];
                }

                if (TempData["Danger"] != null)
                {
                    ViewBag.Danger = TempData["Danger"];
                }

                if (TempData["Success"] != null)
                {
                    ViewBag.Success = TempData["Success"];
                }
                return View(mainPageModel);
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                return RedirectToAction("Error");
            }
        }

        #endregion
    }
}