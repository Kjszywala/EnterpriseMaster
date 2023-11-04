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
        private IUsersServices usersServices;
        private IUsersAdressesServices usersAdressesServices;
        #endregion

        #region Constructor

        public CheckoutController(
            ISubscriptionTypesServices _subscriptionTypesServices, 
            IErrorLogsServices _errorLogsServices,
            IApplicationFeaturesServices _applicationFeaturesServices,
            IPaymentMethodsServices _paymentMethodsServices,
            ICheckoutLogic _checkoutLogic,
            IUsersServices _usersServices,
            IUsersAdressesServices _usersAdressesServices)
        {
            subscriptionTypesServices = _subscriptionTypesServices;
            errorLogsServices = _errorLogsServices;
            featuresServices = _applicationFeaturesServices;
            paymentMethodsServices = _paymentMethodsServices;
            checkoutLogic = _checkoutLogic;
            usersServices = _usersServices;
            usersAdressesServices = _usersAdressesServices;

        }

        #endregion

        #region Methods

        public async Task<IActionResult> IndexAsync(string type)
        {
            try
            {
                var userId = HttpContext.Session.GetString("id");
                var session = HttpContext.Session.GetString("email");
                if (string.IsNullOrEmpty(userId))
                {
                    TempData["Warning"] = "You need to login to access this page!";
                    return RedirectToAction("Index", "Login");
                };
                var user = usersServices.GetAsync(Int32.Parse(userId)).Result;

                if(user.UserAddressId != null)
                {
                    var userAddress = usersAdressesServices.GetAsync(user.UserAddressId.Value).Result;

                    var areDetailsComplete =
                        userAddress.City != null &&
                        userAddress.Country != null &&
                        userAddress.IsActive != false &&
                        userAddress.PostCode != null;

                    if (!areDetailsComplete)
                    {
                        TempData["Warning"] = "Access to this page requires more user details. Please complete your profile to proceed.";
                        return RedirectToAction("Index", "Profile");

                    }

                    var subscriptions = subscriptionTypesServices.GetAllAsync().Result;
                    var features = featuresServices.GetAllAsync().Result;
                    var paymentMethods = paymentMethodsServices.GetAllAsync().Result;

                    var checkoutModel = checkoutLogic.GetCheckoutModelBasedOnString(
                            subscriptions,
                            features,
                            paymentMethods,
                            type,
                            session
                        );

                    return View(checkoutModel);
                }
                else
                {
                    TempData["Warning"] = "Access to this page requires more user details. Please complete your profile to proceed.";
                    return RedirectToAction("Index", "Profile");
                }
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                return RedirectToAction("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> BuyAsync(string type)
        {
            try 
            {

                return RedirectToAction("Index", "Downloads");
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
