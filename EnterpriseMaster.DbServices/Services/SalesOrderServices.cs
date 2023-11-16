using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class SalesOrderServices :
        BaseServices<SalesOrders>,
        ISalesOrdersServices
    {
        public SalesOrderServices()
            : base("/api/v1.0/SalesOrders/")
        {
        }
    }
}
