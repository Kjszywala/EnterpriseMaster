using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;
using EnterpriseMaster.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseMaster.Controllers
{
    public class ProfileController : Controller
    {
        private IUsersServices usersService;
        private IUsersAdressesServices usersAdressesService;
        private IErrorLogsServices errorLogsService;
        private ISubscriptionTypesServices subscriptionTypesService;

        public ProfileController(
            IUsersServices _usersService, 
            IUsersAdressesServices _usersAdressesService, 
            IErrorLogsServices _errorLogsService,
            ISubscriptionTypesServices _subscriptionTypesService)
        {
            usersService = _usersService;
            usersAdressesService = _usersAdressesService;
            subscriptionTypesService = _subscriptionTypesService;
            errorLogsService = _errorLogsService;
        }

        public IActionResult Index()
        {
            if (TempData["Warning"] != null)
            {
                ViewBag.Warning = TempData["Warning"];
            }
            var session = Int32.Parse(HttpContext.Session.GetString("id"));
            var user = usersService.GetAsync(session).Result;
            var profileViewModel = new ProfileViewModel()
            {
                BusinessArea = user.BusinesArea,
                CompanyName = user.CompanyName,
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
                FirstName = user.FirstName,
                NewsLetter = user.Newsletter,
                Password = user.Password,
                Position = user.Position,
                ProfileImage = user.Image,
                SecondName = user.SecondName
            };

            if (user.UserAddressId != null)
            {
                var userAddress = usersAdressesService.GetAsync(user.UserAddressId.Value).Result;
                profileViewModel.State = userAddress.State;
                profileViewModel.StreetAddress = userAddress.StreetAddress;
                profileViewModel.PostalCode = userAddress.PostalCode;
                profileViewModel.Country = userAddress.Country;
                profileViewModel.City = userAddress.City;
            }
            if(user.SubscriptionTypeId != null)
            {
                int subId = user.SubscriptionTypeId.Value;
                user.SubscriptionType = subscriptionTypesService.GetAsync(subId).Result;
                profileViewModel.SubscriptionType = user.SubscriptionType.SubscriptionName;
            }

            return View(profileViewModel);
        }
    }
}
