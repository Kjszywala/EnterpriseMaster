﻿using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;
using EnterpriseMaster.DbServices.Services;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseMaster.Controllers
{
    public class AboutController : BaseController
    {
        private IErrorLogsServices errorLogsServices;
        private IAboutPageServices aboutPageServices;

        public AboutController(
            IErrorLogsServices _errorLogsServices,
            IAboutPageServices _aboutPageServices
            )
        {
            errorLogsServices = _errorLogsServices;
            aboutPageServices = _aboutPageServices;
        }
        public async Task<IActionResult> IndexAsync()
        {
            try
            {
                var aboutPageModel = (await aboutPageServices.GetAllAsync()).FirstOrDefault();
                return View(aboutPageModel);
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                return RedirectToAction("Error");
            }
        }
    }
}
