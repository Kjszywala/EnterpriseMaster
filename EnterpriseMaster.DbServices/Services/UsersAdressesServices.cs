using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class UsersAdressesServices :
        BaseServices<UsersAdresses>,
        IUsersAdressesServices
    {
        public UsersAdressesServices()
            : base("/api/v1.0/UsersAdresses/")
        {
        }
    }
}
