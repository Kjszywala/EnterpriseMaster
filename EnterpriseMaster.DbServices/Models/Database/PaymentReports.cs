﻿namespace EnterpriseMaster.DbServices.Models.Database
{
    public class PaymentReports : Bases
    {
        public string ReportNumber { get; set; }
        public int? PaymentMethodId { get; set; }
        public PaymentMethods? PaymentMethod { get; set; }
        public int? PartId { get; set; }
        public Parts? Part { get; set; }
        public int? PurchaseOrderId { get; set; }
        public PurchaseOrders? PurchaseOrder { get; set; }
        public int? InvoicesId { get; set; }
        public Invoices? Invoice { get; set; }
        public int? PaymentStatusId { get; set; }
        public PaymentStatus? PaymentStatus { get; set; }
        public int? EmployeeId { get; set; }
        public Employees? Employee { get; set; }
        public int Quantity { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public decimal PricePaid { get; set; }
        public string LargestSinglePayment { get; set; }
        public string PaymentsTotal { get; set; }
        public string MostFrequentlySellPart { get; set; }
        public string MostFrequentlyPaymentMethod { get; set; }
        public string LargestQuantity { get; set; }
        public string QuantityTotal { get; set; }
        public int? Company { get; set; }
    }
}
