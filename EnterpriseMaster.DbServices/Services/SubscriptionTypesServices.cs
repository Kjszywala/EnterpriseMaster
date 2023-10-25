using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class SubscriptionTypesServices : 
        BaseServices<SubscriptionTypes>,
        ISubscriptionTypesServices
    {
        public SubscriptionTypesServices()
            : base("/api/v1.0/SubscriptionTypes/")
        {
        }
    }
}
