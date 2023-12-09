namespace EnterpriseMaster.DesktopApp.Data.Models
{
    public class PurchaseOrderManagementViewModel
    {
        public int? Id { get; set; }
        public string? ProductName { get; set; }
        public string? ProductCode { get; set; }
        public string? PartName { get; set; }
        public decimal? PricePaid { get; set; }
        public string? OrderNumber { get; set; }
        public string? Description { get; set; }
        public DateTime? PaymentTerm { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public decimal? Quantity { get; set; }
        public string? QuantityType { get; set; }
        public string? OrderStatus { get; set; }
    }
}
