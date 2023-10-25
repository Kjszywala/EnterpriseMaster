using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseMaster.Controllers
{
    public class BasicSubscriptionController : BaseController
    {
        private IErrorLogsServices errorLogsServices;
        private IBasicPlanServices basicPlanService;

        public BasicSubscriptionController(
            IBasicPlanServices _basicPlanService
            , IErrorLogsServices _errorLogsServices
            )
        {
            basicPlanService = _basicPlanService;
            errorLogsServices = _errorLogsServices;

        }

        public async Task<IActionResult> IndexAsync()
        {
            try
            {
                var basicPlanModel = (await basicPlanService.GetAllAsync()).FirstOrDefault();
                return View(basicPlanModel);
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                return RedirectToAction("Error");
            }
        }
    }
}
