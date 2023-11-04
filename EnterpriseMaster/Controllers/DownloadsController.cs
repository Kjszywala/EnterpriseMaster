using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseMaster.Controllers
{
    public class DownloadsController : Controller
    {
        private IUsersServices usersServices;
        private IErrorLogsServices errorLogsServices;

        public DownloadsController(
            IUsersServices _usersServices,
            IErrorLogsServices _errorLogsServices)
        {
            usersServices = _usersServices;
            errorLogsServices = _errorLogsServices;
        }

        public async Task<IActionResult> IndexAsync()
        {
            try
            {
                var userId = HttpContext.Session.GetString("id");
                var user = usersServices.GetAsync(Int32.Parse(userId)).Result;
                if (user.SubscriptionTypeId == null)
                {
                    TempData["Danger"] = "Something went wrong. Please try again.";
                    return View("Index", "BasicPlanSubscription");
                }
                return View();
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                return RedirectToAction("Error");
            }
        }

        public async Task<IActionResult> DownloadAsync()
        {
            // Download the file from here.
            return View("Index");
        }
    }
}
