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
            string path = "C:\\Users\\kamil\\Downloads\\maui\\EnterpriseMaster.DesktopApp_1.0.0.0_Debug_Test\\EnterpriseMaster.DesktopApp_1.0.0.0_x64_Debug.msix";
            // Check if the file exists
            if (System.IO.File.Exists(path))
            {
                // Get the file content
                var fileContent = await System.IO.File.ReadAllBytesAsync(path);

                // Determine the file's content type
                var contentType = "application/octet-stream"; // Use the appropriate content type

                // Provide a suggested file name (optional)
                var fileName = "EnterpriseMaster.DesktopApp_1.0.0.0_x64_Debug.msix";

                // Return the file for download
                return File(fileContent, contentType, fileName);
            }
            else
            {
                return View("Index");
            }
            
        }
    }
}
