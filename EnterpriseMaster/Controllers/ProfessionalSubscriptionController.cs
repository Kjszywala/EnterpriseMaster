﻿using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseMaster.Controllers
{
    public class ProfessionalSubscriptionController : BaseController
    {
        private IErrorLogsServices errorLogsServices;
        private IProfessionalPlanServices professionalPlanServices;

        public ProfessionalSubscriptionController(
            IErrorLogsServices _errorLogsServices,
            IProfessionalPlanServices _professionalPlanServices
            )
        {
            errorLogsServices = _errorLogsServices;
            professionalPlanServices = _professionalPlanServices;
        }

        public IActionResult Index()
        {
            try
            {
                var professionalPlanModel = professionalPlanServices.GetAllAsync().Result.FirstOrDefault();
                return View(professionalPlanModel);
            }
            catch (Exception e)
            {
                errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                return RedirectToAction("Error");
            }
        }
    }
}
