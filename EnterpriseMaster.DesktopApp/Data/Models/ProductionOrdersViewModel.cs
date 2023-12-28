using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DesktopApp.Data.Models
{
    public class ProductionOrdersViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DueDate { get; set; }
        public string? ProductionOrderStatus { get; set; }
    }
}
