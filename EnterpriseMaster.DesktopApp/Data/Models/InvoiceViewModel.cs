namespace EnterpriseMaster.DesktopApp.Data.Models
{
    public class InvoiceViewModel
    {
        public string? ProductName { get; set; }
        public string? Email { get; set; }
        public string? ProductCode { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? Discount { get; set; }
        public DateTime? OrderDate { get; set; }
    }
}