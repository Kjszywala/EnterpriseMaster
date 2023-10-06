using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class OrdersServices : 
        BaseServices<Orders>,
        IOrdersServices
    {
        public OrdersServices()
        : base("/api/v1.0/Orders")
        {
        }
    }
}
