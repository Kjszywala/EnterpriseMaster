using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseMaster.Controllers
{
    public class CheckoutUserInformationComponent : ViewComponent
    {
        #region Variables

        IUsersAdressesServices usersAdressesServices;
        IUsersServices usersServices;
        IErrorLogsServices errorLogsServices;

        #endregion

        #region Constructor

        public CheckoutUserInformationComponent(
            IUsersAdressesServices _usersAdressesServices,
            IUsersServices _usersServices,
            IErrorLogsServices _errorLogsServices)
        {
            usersAdressesServices = _usersAdressesServices;
            errorLogsServices = _errorLogsServices;
            usersServices = _usersServices;
        }

        #endregion

        #region Methods

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var currentUserId = Int32.Parse(HttpContext.Session.GetString("id"));
                var currentUser = await usersServices.GetAsync(currentUserId);
                var address = await usersAdressesServices.GetAsync((int)currentUser.UserAddressId);
                var profileViewModel = new ProfileViewModel()
                {
                    FirstName = currentUser.FirstName,
                    SecondName = currentUser.SecondName,
                    Email = currentUser.Email,
                    DateOfBirth = currentUser.DateOfBirth,
                    Country = address.Country
                };
                return View("CheckoutUserInformationComponent", profileViewModel);
            }
            catch (Exception ex)
            {
                await errorLogsServices.AddAsync(new DbServices.Models.Database.ErrorLogs() { Message = ex.Message, Exception = ex.StackTrace, Date = DateTime.Now});
                return View("Error");
            }
        }

        #endregion
    }
}