using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class RolesService :
        BaseServices<Roles>,
        IRolesService
    {
        public RolesService()
            : base("/api/v1.0/Roles/")
        {
        }
    }
}
