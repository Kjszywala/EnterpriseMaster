using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnterpriseMaster.DbServices.Models.Database
{
    public class InvoiceItem : Bases
    {
        public int? ProductId { get; set; }
        public Products? Product { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalPrice => Quantity * UnitPrice;
    }
}
