﻿using EnterpriseMaster.BusinessLogic.Interfaces;
using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DesktopApp.Data.Services.LoginService
{
    public class LoginService
    {
        #region Variables

        private IAuthenticationLogic authenticationLogic;
        private IErrorLogsServices errorLogsServices;
        private IUsersServices usersServices;
        private IEmployeesServices employeesServices;
        private IEmployeeAccessesServices employeeAccessesServices;
        private ICompaniesServices companiesServices;
        private IRolesService rolesService;
        private IUserRolesService userRolesService;

        #endregion

        #region Ctor

        public LoginService(
            IAuthenticationLogic _authenticationLogic, 
            IErrorLogsServices _errorLogsServices, 
            IUsersServices _usersServices,
            IEmployeesServices _employeesServices,
            IEmployeeAccessesServices _employeeAccessesServices,
            ICompaniesServices _companiesServices,
            IRolesService _rolesService,
            IUserRolesService _userRolesService)
        {
            authenticationLogic = _authenticationLogic;
            errorLogsServices = _errorLogsServices;
            usersServices = _usersServices;
            employeesServices = _employeesServices;
            employeeAccessesServices = _employeeAccessesServices;
            companiesServices = _companiesServices;
            rolesService = _rolesService;
            userRolesService = _userRolesService;
        }

        #endregion

        #region Methods

        public async Task<bool> AuthenticateAsync(string email, string password)
        {
            try
            {
                var users = (await usersServices.GetAllAsync());
                var user = new Users
                {
                    Email = email,
                    Password = password
                };
                var isAuthenticated = await authenticationLogic.AuthenticateAsync(user, users);
                if(isAuthenticated)
                {
                    Config.Email = email;
                    Config.UserId =  users.Where(item => item.Email == user.Email).FirstOrDefault().Id;
                    Config.FirstName = users.Where(item => item.Email == user.Email).FirstOrDefault().FirstName;
                    Config.LastName = users.Where(item => item.Email == user.Email).FirstOrDefault().SecondName;
                    Config.Position = users.Where(item => item.Email == user.Email).FirstOrDefault().Position;
                    var currentEmployee = (await employeesServices.GetAllAsync()).Where(item => item.UserId == Config.UserId).FirstOrDefault();
                    Config.SubscriptionId = users.Where(item => item.Email == user.Email).FirstOrDefault().SubscriptionTypeId;
                    Config.Company = users.Where(item => item.Email == user.Email).FirstOrDefault().CompanyName;
                    Config.CompanyId = (await companiesServices.GetAllAsync()).Where(item => item.Name == Config.Company).FirstOrDefault().Id;
                    Config.EmployeeAccess = (await employeeAccessesServices.GetAllAsync()).Where(item => item.Id == currentEmployee.EmployeeAccessId).FirstOrDefault().Access;
                    Config.UserImage = users.Where(item => item.Email == user.Email).FirstOrDefault().Image;
                    var userRoles = (await userRolesService.GetAllAsync()).Where(item => item.UserId == Config.UserId && item.UserRole == true).ToList();
                    foreach(var userRole in userRoles)
                    {
                        userRole.Roles = await rolesService.GetAsync(userRole.RoleId.Value);
                    }
                    Config.UserRoles = userRoles.Select(item => item.Roles.Role).ToList();
                }
                return isAuthenticated;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public void Logout()
        {
            Config.IsLoggedIn = false;
        }

        #endregion
    }
}
