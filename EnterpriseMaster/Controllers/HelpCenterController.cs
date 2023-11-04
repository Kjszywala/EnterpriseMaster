using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;
using EnterpriseMaster.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseMaster.Controllers
{
    public class HelpCenterController : BaseController
    {
        private ISupportCaseServices supportCaseServices;
        private ICaseStatusServices caseStatusServices;
        private IErrorLogsServices errorLogsServices;

        public HelpCenterController(
            ISupportCaseServices _supportCaseServices, 
            ICaseStatusServices _caseStatusServices, 
            IErrorLogsServices _errorLogsServices)
        {
            supportCaseServices = _supportCaseServices;
            caseStatusServices = _caseStatusServices;
            errorLogsServices = _errorLogsServices;
        }

        public async Task<IActionResult> IndexAsync()
        {
            try
            {
                var userId = HttpContext.Session.GetString("id");
                if (string.IsNullOrEmpty(userId))
                {
                    TempData["Warning"] = "You need to login to access this page!";
                    return RedirectToAction("Index", "Login");
                };

                var supportViewModel = new SupportViewModel()
                {
                    SupportCasesList = (await supportCaseServices.GetAllAsync())
                    .Where(item2 => item2.UserId == Int32.Parse(userId))
                    .Where(item => item.IsActive == true)
                    .ToList(),
                    HistoryCasesList = (await supportCaseServices.GetAllAsync())
                    .Where(item2 => item2.UserId == Int32.Parse(userId))
                    .Where(item => item.IsActive == false)
                    .ToList()
                };

                foreach( var item in supportViewModel.HistoryCasesList)
                {
                    if (item.CaseStatusId != null)
                    {
                        item.CaseStatus = caseStatusServices.GetAsync(item.CaseStatusId.Value).Result;
                    }
                }

                foreach (var item in supportViewModel.SupportCasesList)
                {
                    if (item.CaseStatusId != null)
                    {
                        item.CaseStatus = caseStatusServices.GetAsync(item.CaseStatusId.Value).Result;
                    }
                }

                return View(supportViewModel);
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                return RedirectToAction("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCaseAsync(SupportViewModel support)
        {
            try
            {
                var userId = HttpContext.Session.GetString("id");
                var newCase = new SupportCases()
                {
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now,
                    Description = support.SupportCases.Description,
                    CaseStatusId = (await caseStatusServices.GetAllAsync()).Where(item => item.Id == 1).FirstOrDefault().Id,
                    IsActive = true,
                    Title = support.SupportCases.Title,
                    UserId = Int32.Parse(userId)
                };

                await supportCaseServices.AddAsync(newCase);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                return RedirectToAction("Error");
            }
        }

        public async Task<IActionResult> RemoveCaseAsync(string id)
        {
            try
            {
                var supportCase = supportCaseServices.GetAsync(Int32.Parse(id)).Result;
                supportCase.CaseStatusId = caseStatusServices.GetAsync(3).Result.Id;
                await supportCaseServices.EditAsync(supportCase.Id, supportCase);
                await supportCaseServices.RemoveAsync(Int32.Parse(id));
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                return RedirectToAction("Error");
            }
        }
    }
}
