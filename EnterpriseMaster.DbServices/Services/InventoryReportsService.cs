using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class InventoryReportsService :
        BaseServices<InventoryReports>,
        IInventoryReportsService
    {
        public InventoryReportsService()
            : base("/api/v1.0/InventoryReports/")
        {
        }
    }
}
