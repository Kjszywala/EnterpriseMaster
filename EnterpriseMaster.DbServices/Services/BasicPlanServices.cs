using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class BasicPlanServices :
        BaseServices<BasicPlanPage>,
        IBasicPlanServices
    {
        public BasicPlanServices()
            : base("/api/v1.0/BasicPlanPages")
        {
        }
    }
}
