using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class JobOffersServices :
        BaseServices<JobOffers>,
        IJobOffersServices
    {
        public JobOffersServices()
            : base("/api/v1.0/JobOffers/")
        {
        }
    }
}
