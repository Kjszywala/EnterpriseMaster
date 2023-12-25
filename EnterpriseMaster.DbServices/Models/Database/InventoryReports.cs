namespace EnterpriseMaster.DbServices.Models.Database
{
    public class InventoryReports : Bases
    {
        public string ReportNumber { get; set; }
        public string HaviestItem { get; set; }
        public string LargestUnitInStock { get; set; }
        public string TotalInStock { get; set; }
        public string MostExpensiveItem { get; set; }
        public string EmployeeEmail { get; set; }
        public int? ProductId { get; set; }
        public Products? Product { get; set; }
        public int? EmployeeId { get; set; }
        public Employees? Employee { get; set; }
    }
}
