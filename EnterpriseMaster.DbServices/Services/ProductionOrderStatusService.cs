using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class ProductionOrderStatusService :
        BaseServices<ProductionOrderStatus>,
        IProductionOrderStatusService
    {
        public ProductionOrderStatusService()
            : base("/api/v1.0/ProductionOrderStatus/")
        {
        }
    }
}
