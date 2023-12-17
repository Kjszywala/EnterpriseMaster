namespace EnterpriseMaster.DbServices.Models.Database
{
    public class Parts : Bases
    {
        public string PartName { get; set; }
        public string Description { get; set; }
        public decimal UnitCost { get; set; }
        public int QuantityInStock { get; set; }
        public int? ProductsId { get; set; }
        public Products? Products { get; set; }
        public int? SuppliersId { get; set; }
        public Suppliers? Suppliers { get; set; }
        public int? QuantityTypeId { get; set; }
        public QuantityTypes? QuantityTypes { get; set; }
        public List<PurchaseOrders>? PurchaseOrders { get; set; }
        public List<PaymentReports>? PaymentReports { get; set; }
    }
}
