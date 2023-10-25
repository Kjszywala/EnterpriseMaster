using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class EnterprisePlanServices :
        BaseServices<EnterprisePlan>,
        IEnterprisePlanServices
    {
        public EnterprisePlanServices()
            : base("/api/v1.0/EnterprisePlans/")
        {
        }
    }
}
