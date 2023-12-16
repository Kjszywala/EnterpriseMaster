using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class PurchaseOrderReportsService :
        BaseServices<PurchaseOrderReports>,
        IPurchaseOrderReportsService
    {
        public PurchaseOrderReportsService()
            : base("/api/v1.0/PurchaseOrderReports/")
        {
        }
    }
}
