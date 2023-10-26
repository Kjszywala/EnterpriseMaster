using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.BusinessLogic.Interfaces
{
    public interface IAuthenticationLogic
    {
        /// <summary>
        /// Authenticate an user.
        /// </summary>
        /// <returns></returns>
        Task<bool> AuthenticateAsync(Users user, List<Users> usersList);

        /// <summary>
        /// Checks if the password matching the pattern.
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<bool> IsPasswordValidAsync(string password, string storedPassword);

        /// <summary>
        /// Checks if email is already taken.
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<bool> EmailAlreadyExist(string email, List<Users> usersList);

        /// <summary>
        /// Checks if email is valid
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        bool IsEmailValidAsync(string email);

        /// <summary>
        /// Checks if the regex of the given password is valid.
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        bool IsPasswordRegexValid(string password);
    }
}
