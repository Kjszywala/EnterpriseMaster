using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;
using EnterpriseMaster.DbServices.Services;
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

        public async Task<IActionResult> IndexAsync()
        {
            try
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
                    profileViewModel.StreetAddress = userAddress.Street;
                    profileViewModel.PostalCode = userAddress.PostCode;
                    profileViewModel.Country = userAddress.Country;
                    profileViewModel.City = userAddress.City;
                    profileViewModel.HouseNumber = userAddress.HouseNumber;
                }
                if (user.SubscriptionTypeId != null)
                {
                    int subId = user.SubscriptionTypeId.Value;
                    user.SubscriptionType = subscriptionTypesService.GetAsync(subId).Result;
                    profileViewModel.SubscriptionType = user.SubscriptionType.SubscriptionName;
                }

                return View(profileViewModel);
            }
            catch (Exception e)
            {
                await errorLogsService.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                return RedirectToAction("Error");
            }
        }

        public async Task<IActionResult> EditAsync()
        {
            try
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
                    profileViewModel.StreetAddress = userAddress.Street;
                    profileViewModel.PostalCode = userAddress.PostCode;
                    profileViewModel.Country = userAddress.Country;
                    profileViewModel.City = userAddress.City;
                    profileViewModel.HouseNumber = userAddress.HouseNumber;
                }
                if (user.SubscriptionTypeId != null)
                {
                    int subId = user.SubscriptionTypeId.Value;
                    user.SubscriptionType = subscriptionTypesService.GetAsync(subId).Result;
                    profileViewModel.SubscriptionType = user.SubscriptionType.SubscriptionName;
                }

                return View(profileViewModel);
            }
            catch (Exception e)
            {
                await errorLogsService.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                return RedirectToAction("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> SaveChanges(ProfileViewModel model)
        {
            try
            {
                var currentUserId = Int32.Parse(HttpContext.Session.GetString("id"));
                var currentUser = await usersService.GetAsync(currentUserId);

                if (model.ProfileImage != null)
                {
                    var file = Request.Form.Files.FirstOrDefault();
                    if (file != null && file.Length > 0)
                    {
                        using (var stream = file.OpenReadStream())
                        {
                            using (var binaryReader = new BinaryReader(stream))
                            {
                                var imageData = binaryReader.ReadBytes((int)file.Length);
                                model.ProfileImage = imageData;
                            }
                        }
                    }
                }
                else
                {
                    model.ProfileImage = currentUser.Image;
                }

                var userAddressToAdd = new UsersAdresses()
                {
                    City = model.City,
                    ModificationDate = DateTime.Now,
                    CreationDate = DateTime.Now,
                    Country = model.Country,
                    HouseNumber = model.HouseNumber,
                    Street = model.StreetAddress,
                    PostCode = model.PostalCode,
                    State = model.State,
                    IsActive = true,
                };
                await usersAdressesService.AddAsync(userAddressToAdd);

                var addressId = (await usersAdressesService.GetAllAsync())
                    .Where(item => item.Street == model.StreetAddress)
                    .Where(item => item.HouseNumber == model.HouseNumber)
                    .FirstOrDefault().Id;


                var userToAdd = new Users()
                {
                    Id = currentUserId,
                    BusinesArea = model.BusinessArea,
                    CompanyName = model.CompanyName,
                    DateOfBirth = model.DateOfBirth,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    Image = model.ProfileImage,
                    ModificationDate = DateTime.Now,
                    Newsletter = model.NewsLetter,
                    Position = model.Position,
                    SecondName = model.SecondName,
                    UserAddressId = addressId,
                    IsActive = true
                };

                if (model.Password == null)
                {
                    userToAdd.Password = currentUser.Password;
                }
                else
                {
                    var hashedPassword = BCrypt.Net.BCrypt.HashPassword(model.Password);
                    userToAdd.Password = hashedPassword;
                }

                if (currentUser.CreationDate.Year < 2020)
                {
                    userToAdd.CreationDate = DateTime.Now;
                }

                if (await usersService.EditAsync(currentUserId, userToAdd))
                {
                    return RedirectToAction("Index");
                };

                ViewBag.Warning = "Something went wrong while updating user details.";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                await errorLogsService.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                return RedirectToAction("Error");
            }
        }
    }
}
