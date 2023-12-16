using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class UserRolesService :
        BaseServices<UserRoles>,
        IUserRolesService
    {
        public UserRolesService()
            : base("/api/v1.0/UserRoles/")
        {
        }
    }
}
