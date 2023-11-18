namespace EnterpriseMaster.DbServices.Models.Database
{
    public class ProductionOrderStatus : Bases
    {
        public string Status { get; set; }
        public List<ProductionOrders>? ProductionOrders { get; set; }
    }
}
