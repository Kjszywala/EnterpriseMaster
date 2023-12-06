namespace EnterpriseMaster.DesktopApp.Data.Models
{
    public class OrderViewModel
    {
        public string? ProductName { get; set; }
        public string? ProductCode { get; set; }
        public decimal? PricePaid { get; set; }
        public string? OrderNumber { get; set; }
        public DateTime? PaymentTerm { get; set; }
        public decimal? Quantity { get; set; }
        public string? QuantityType { get; set; }
        public string? OrderStatus { get; set; }
    }
}
