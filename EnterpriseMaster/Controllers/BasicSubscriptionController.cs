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

        public IActionResult Index()
        {
            try
            {
                var basicPlanModel = basicPlanService.GetAllAsync().Result.FirstOrDefault();
                return View(basicPlanModel);
            }
            catch (Exception e)
            {
                errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                return RedirectToAction("Error");
            }
        }
    }
}
