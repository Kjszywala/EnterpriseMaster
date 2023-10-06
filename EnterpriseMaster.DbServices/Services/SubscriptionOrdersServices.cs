using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class SubscriptionOrdersServices :
        BaseServices<SubscriptionOrders>,
        ISubscriptionOrdersServices
    {
        public SubscriptionOrdersServices()
          : base("/api/v1.0/SubscriptionOrders")
        {
        }
    }
}
