using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class EmployeeRolesService :
        BaseServices<EmployeeRoles>,
        IEmployeeRolesService
    {
        public EmployeeRolesService()
            : base("/api/v1.0/EmployeeRoles/")
        {
        }
    }
}
