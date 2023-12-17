using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnterpriseMaster.DbServices.Models.Database
{
	public class Invoices : Bases
	{
        public string InvoiceNumber { get; set; }
        public byte[]? Image { get; set; }
        public int? OrderId { get; set; }
        public Orders? Order { get; set; }
        public int? PurchaseOrderId { get; set; }
        public PurchaseOrders? PurchaseOrder { get; set; }
        public int? InvoiceItemId { get; set; }
        public InvoiceItem? InvoiceItem { get; set; }
        public int? SalesOrderId { get; set; }
        public SalesOrders? SalesOrder { get; set; }
        public int? PaymentMethodId { get; set; }
        public PaymentMethods? PaymentMethod { get; set; }
        public int? InvoiceStatusId { get; set; }
        public InvoiceStatuses? InvoiceStatus { get; set; }
        public int? CustomerInformationId { get; set; }
        public CustomerInformation? CustomerInformation { get; set; }
        public int? BillingAddressId { get; set; }
        public BillingAddresses? BillingAddress { get; set; }
        public int? ShippingAddressId { get; set; }
        public ShippingAddresses? ShippingAddress { get; set; }
        public DateTime DueDate { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalAmount { get; set; }
        public List<Payments>? Payments { get; set; }
        public List<PaymentReports>? PaymentReports { get; set; }
    }
}
