using EnterpriseMaster.BusinessLogic.Interfaces;
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

        #endregion

        #region Ctor

        public LoginService(IAuthenticationLogic _authenticationLogic, IErrorLogsServices _errorLogsServices, IUsersServices _usersServices)
        {
            authenticationLogic = _authenticationLogic;
            errorLogsServices = _errorLogsServices;
            usersServices = _usersServices;
        }

        #endregion

        #region Methods

        public async Task<bool> AuthenticateAsync(string email, string password)
        {
            try
            {
                var users = await usersServices.GetAllAsync();
                var user = new Users
                {
                    Email = email,
                    Password = password
                };
                var isAuthenticated = await authenticationLogic.AuthenticateAsync(user, users);

                return isAuthenticated;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                return false;
            }
        }

        #endregion
    }
}
