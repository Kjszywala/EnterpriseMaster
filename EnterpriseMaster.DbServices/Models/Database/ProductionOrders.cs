namespace EnterpriseMaster.DbServices.Models.Database
{
    public class ProductionOrders : Bases
    {
        public int? ProductId { get; set; }
        public Products? Product { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DueDate { get; set; }
        public int? ProductionOrderStatusId { get; set; }
        public ProductionOrderStatus? ProductionOrderStatus { get; set; }
        public List<SalesOrders>? SalesOrders { get; set; }
    }
}
