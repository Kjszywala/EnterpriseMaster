using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseMaster.Controllers
{
    public class EnterpriseSubscriptionController : BaseController
    {
        private IErrorLogsServices errorLogsServices;
        private IEnterprisePlanServices enterprisePlanServices;

        public EnterpriseSubscriptionController(
            IErrorLogsServices _errorLogsService, 
            IEnterprisePlanServices _enterprisePlanServices
            )
        {
            errorLogsServices = _errorLogsService;
            enterprisePlanServices = _enterprisePlanServices;
        }
        public async Task<IActionResult> IndexAsync()
        {
            try
            {
                var enterprisePlanModel = (await enterprisePlanServices.GetAllAsync()).FirstOrDefault();
                return View(enterprisePlanModel);
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                return RedirectToAction("Error");
            }
        }
    }
}
