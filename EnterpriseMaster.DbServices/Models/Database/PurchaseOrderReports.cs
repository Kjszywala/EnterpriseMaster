namespace EnterpriseMaster.DbServices.Models.Database
{
    public class PurchaseOrderReports : Bases
    {
        public string ReportNumber { get; set; }
        public string LargestPurchase { get; set; }
        public string TotalCost { get; set; }
        public string MaximumQuantity { get; set; }
        public string TotalQuantity { get; set; }
        public string MostOrderedPart { get; set; }
        public string MostFrequesntQuantityType { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int? EmployeeId { get; set; }
        public Employees? Employee { get; set; }
        public int? PurchaseOrderId { get; set; }
        public PurchaseOrders? PurchaseOrder { get; set; }
    }
}
