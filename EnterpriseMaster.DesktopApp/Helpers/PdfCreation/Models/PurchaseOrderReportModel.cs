using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DesktopApp.Helpers.PdfCreation.Models
{
    public class PurchaseOrderReportModel
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
        public string EmployeeEmail { get; set; }
        public List<PurchaseOrders> PurchaseOrders { get; set; }
    }
}
