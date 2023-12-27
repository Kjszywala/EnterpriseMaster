using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnterpriseMaster.DbServices.Models.Database
{
    public class SalesOrders : Bases
    {
        public string SalesOrderNumber { get; set; }
        public int? CustomerInformationId { get; set; }
        public CustomerInformation? CustomerInformation { get; set; }
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
        public int? ProductionOrderId { get; set; }
        public ProductionOrders? ProductionOrder { get; set; }
        public int? CompanyId { get; set; }
        public Companies? Companies { get; set; }
        public int? OrderStatuseId { get; set; }
        public OrderStatuses? OrderStatuse { get; set; }
        public string RejectedReason { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime PaymentTerm { get; set; }
        public int? BillingAddressId { get; set; }
        public BillingAddresses? BillingAddress { get; set; }
        public List<Invoices>? Invoices { get; set; }
        public List<Returns>? Returns { get; set; }
        public List<Payments>? Payments { get; set; }
    }
}
