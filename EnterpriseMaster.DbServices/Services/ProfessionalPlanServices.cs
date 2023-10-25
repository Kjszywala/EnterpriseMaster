using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class ProfessionalPlanServices :
        BaseServices<ProfessionalPlanPage>,
        IProfessionalPlanServices
    {
        public ProfessionalPlanServices()
            : base("/api/v1.0/ProfessionalPlanPages")
        {
        }
    }
}
