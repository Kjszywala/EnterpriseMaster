using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class UsersServices :
        BaseServices<Users>,
        IUsersServices
    {
        public UsersServices()
            : base("/api/v1.0/Users")
        {
        }
    }
}
