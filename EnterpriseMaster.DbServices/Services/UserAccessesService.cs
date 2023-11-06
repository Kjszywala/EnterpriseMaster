using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class UserAccessesService :
        BaseServices<EmployeeAccesses>,
        IUserAccessesService
    {
        public UserAccessesService() 
            : base("/api/v1.0/UserAccesses/")
        {
        }
    }
}
