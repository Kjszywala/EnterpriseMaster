using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class PurchaseOrderServices :
        BaseServices<PurchaseOrders>,
        IPurchaseOrdersServices
    {
        public PurchaseOrderServices()
            : base("/api/v1.0/PurchaseOrders/")
        {
        }
    }
}
