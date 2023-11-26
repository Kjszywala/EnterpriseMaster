using EnterpriseMaster.DbServices.Models.Database;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnterpriseMaster.DesktopApp.Data.Models
{
    public class PaymentViewModel
    {
        public int? PaymentId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? TotalAmount { get; set; }
        public string? PaymentMethod { get; set; }
        public string? Product { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Quantity { get; set; }
        public string? PurchaseOrderCode { get; set; }
        public string? InvoicesCode { get; set; }
        public string? SalesOrdersCode { get; set; }
    }
}
