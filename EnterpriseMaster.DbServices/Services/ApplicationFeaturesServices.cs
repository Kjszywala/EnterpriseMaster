using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class ApplicationFeaturesServices :
        BaseServices<ApplicationFeatures>,
        IApplicationFeaturesServices
    {
        public ApplicationFeaturesServices() 
            : base("/api/v1.0/ApplicationFeatures/")
        {
        }
    }
}
