using EnterpriseMaster.BusinessLogic.Interfaces;
using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Authentication;
using System.Net.Http;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace EnterpriseMaster.BusinessLogic.AuthenticationLogic
{
    public class AuthenticationLogic : IAuthenticationLogic
    {
        #region Methods

        public Task<bool> AuthenticateAsync(Users user, List<Users> usersList)
        {
            var userExist = usersList.Where(x => x.Email == user.Email).FirstOrDefault();

            if (userExist != null && BCrypt.Net.BCrypt.Verify(user.Password, userExist.Password))
            {
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }

        public Task<bool> EmailAlreadyExist(string email, List<Users> usersList)
        {
            var emailExist = usersList.Where(x => x.Email == email).FirstOrDefault();

            if (emailExist != null)
            {
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }

        public bool IsEmailValidAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Use the built-in .NET email address validation
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public bool IsPasswordRegexValid(string password)
        {
            string passwordPattern = "^(?=.*[A-Z])(?=.*\\d).{8,}$";

            if (!Regex.IsMatch(password, passwordPattern))
            {
                return false;
            }

            return true;
        }

        public Task<bool> IsPasswordValidAsync(string password, string storedPassword)
        {
            return Task.FromResult(BCrypt.Net.BCrypt.Verify(password, storedPassword));
        }

        #endregion
    }
}
