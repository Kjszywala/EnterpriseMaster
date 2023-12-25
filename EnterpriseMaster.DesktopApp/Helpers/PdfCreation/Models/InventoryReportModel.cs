using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DesktopApp.Helpers.PdfCreation.Models
{
    public class InventoryReportModel
    {
        public string ReportNumber { get; set; }
        public string HaviestItem { get; set; }
        public string LargestUnitInStock { get; set; }
        public string TotalInStock { get; set; }
        public string MostExpensiveItem { get; set; }
        public DateTime CreationDate { get; set; }
        public string EmployeeEmail { get; set; }
        public List<Products> Products { get; set; }
    }
}
