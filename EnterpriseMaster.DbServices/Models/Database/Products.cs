using System.ComponentModel.DataAnnotations.Schema;

namespace EnterpriseMaster.DbServices.Models.Database
{
	public class Products : Bases
	{
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string Manufacturer { get; set; }
        public string ProductCode { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal UnitsInStock { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Weight { get; set; }
        public bool Discontinued { get; set; }
        public byte[]? Image { get; set; }
        public int? QuantityTypeId { get; set; }
        public QuantityTypes? QuantityType { get; set; }
        public int? CategoryId { get; set; }
        public Categories? Category { get; set; }
        public List<Orders>? Orders { get; set; }
        public List<Offers>? Offers { get; set; }
        public List<SalesOrders>? SalesOrders { get; set; }
        public List<PurchaseOrders>? PurchaseOrders { get; set; }
        public List<ProductionOrders>? ProductionOrders { get; set; }
        public List<Parts>? Parts { get; set; }
        public List<InventoryReports>? InventoryReports { get; set; }
	}
}
