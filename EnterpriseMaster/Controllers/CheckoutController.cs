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
        private IRolesService rolesService;
        private IUserRolesService userRolesService;
        #endregion

        #region Constructor

        public CheckoutController(
            ISubscriptionTypesServices _subscriptionTypesServices, 
            IErrorLogsServices _errorLogsServices,
            IApplicationFeaturesServices _applicationFeaturesServices,
            IPaymentMethodsServices _paymentMethodsServices,
            ICheckoutLogic _checkoutLogic,
            IUsersServices _usersServices,
            IUsersAdressesServices _usersAdressesServices,
            IRolesService _rolesService,
            IUserRolesService _userRolesService)
        {
            subscriptionTypesServices = _subscriptionTypesServices;
            errorLogsServices = _errorLogsServices;
            featuresServices = _applicationFeaturesServices;
            paymentMethodsServices = _paymentMethodsServices;
            checkoutLogic = _checkoutLogic;
            usersServices = _usersServices;
            usersAdressesServices = _usersAdressesServices;
            rolesService = _rolesService;
            userRolesService = _userRolesService;
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
        public async Task<IActionResult> BuyAsync([FromBody] string type)
        {
            try 
            {
                var userId = HttpContext.Session.GetString("id");
                var currentUser = usersServices.GetAsync(Int32.Parse(userId)).Result;
                var subscriptionType = subscriptionTypesServices.GetAllAsync().Result.Where(item => item.SubscriptionName == type).FirstOrDefault();
                currentUser.SubscriptionTypeId = subscriptionType.Id;

                if (await usersServices.EditAsync(currentUser.Id, currentUser))
                {
                    TempData["Success"] = "Congratulations! You can now download software in the Downloads section.";
                    var roles = await rolesService.GetAllAsync();
                    var userRoles = (await userRolesService.GetAllAsync()).Where(item => item.UserId == currentUser.Id);
                    if(userRoles.Count() == 0)
                    {
                        foreach (var item in roles)
                        {
                            await userRolesService.AddAsync(new UserRoles()
                            {
                                CreationDate = DateTime.Now,
                                IsActive = true,
                                ModificationDate = DateTime.Now,
                                RoleId = item.Id,
                                UserId = currentUser.Id,
                                UserRole = true,
                            });
                        }
                    }
                }
                else
                {
                    TempData["Danger"] = "Something went wrong. Please try again.";
                }

                return View("Index", "Home");
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
