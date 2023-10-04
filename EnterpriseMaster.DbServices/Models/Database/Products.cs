using System.ComponentModel.DataAnnotations.Schema;

namespace EnterpriseMaster.DbServices.Models.Database
{
	public class Products : Bases
	{
        public string ProductName { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        public int? QuantityTypeId { get; set; }
        public QuantityTypes? QuantityType { get; set; }
        public List<Orders>? Orders { get; set; }
	}
}
