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
        public int? PurchaseOrderId { get; set; }
        public PurchaseOrders? PurchaseOrder { get; set; }
        public int? InvoicesId { get; set; }
        public Invoices? Invoice { get; set; }
        public int? SalesOrdersId { get; set; }
        public SalesOrders? SalesOrder { get; set; }
    }
}
