using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnterpriseMaster.DbServices.Models.Database
{
    public class Payments : Bases
    {
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalAmount { get; set; }
        public int? PaymentMethodId { get; set; }
        public PaymentMethods? PaymentMethod { get; set; }
        public List<PurchaseOrders>? PurchaseOrders { get; set;}
        public List<Invoices>? Invoices { get; set;}
        public List<SalesOrders>? SalesOrders { get; set;}
    }
}
