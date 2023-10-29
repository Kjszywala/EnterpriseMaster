using EnterpriseMaster.BusinessLogic.Interfaces;
using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseMaster.Controllers
{
    public class CheckoutController : Controller
    {
        #region Variables

        private IApplicationFeaturesServices featuresServices;
        private ISubscriptionTypesServices subscriptionTypesServices;
        private IErrorLogsServices errorLogsServices;
        private IPaymentMethodsServices paymentMethodsServices;
        private ICheckoutLogic checkoutLogic;
        #endregion

        #region Constructor

        public CheckoutController(
            ISubscriptionTypesServices _subscriptionTypesServices, 
            IErrorLogsServices _errorLogsServices,
            IApplicationFeaturesServices _applicationFeaturesServices,
            IPaymentMethodsServices _paymentMethodsServices,
            ICheckoutLogic _checkoutLogic
            )
        {
            subscriptionTypesServices = _subscriptionTypesServices;
            errorLogsServices = _errorLogsServices;
            featuresServices = _applicationFeaturesServices;
            paymentMethodsServices = _paymentMethodsServices;
            checkoutLogic = _checkoutLogic;
        }

        #endregion

        #region Methods

        public async Task<IActionResult> IndexAsync(string type)
        {
            try
            {
                var subscriptions = subscriptionTypesServices.GetAllAsync().Result;
                var features = featuresServices.GetAllAsync().Result;
                var paymentMethods = paymentMethodsServices.GetAllAsync().Result;

                var checkoutModel = checkoutLogic.GetCheckoutModelBasedOnString(
                    subscriptions,
                    features,
                    paymentMethods,
                    type
                    );

                return View(checkoutModel);
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
