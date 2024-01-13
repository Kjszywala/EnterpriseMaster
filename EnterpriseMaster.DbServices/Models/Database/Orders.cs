using System.ComponentModel.DataAnnotations.Schema;

namespace EnterpriseMaster.DbServices.Models.Database
{
	public class Orders : Bases
	{
        public int Quantity { get; set; }
        public int? QuantityTypeId { get; set; }
        public QuantityTypes? QuantityType { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PricePaid { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Discount { get; set; }
        public int? EmployeeId { get; set; }
		public Employees? Employee { get; set; }
		public int? ProductId { get; set; }
		public Products? Product { get; set; }
        public int? CompanyId { get; set; }
        public Companies? Companies { get; set; }
        public List<Invoices>? Invoices { get; set; }
        public int? Company { get; set; }
    }
}
