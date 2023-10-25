using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class OrderStatusesServices :
        BaseServices<OrderStatuses>,
        IOrderStatusesServices
    {
        public OrderStatusesServices()
            : base("/api/v1.0/OrderStatuses/")
        {
        }
    }
}
