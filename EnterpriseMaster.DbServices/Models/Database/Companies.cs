namespace EnterpriseMaster.DbServices.Models.Database
{
    public class Companies : Bases
    {
        public string? Name { get; set; } 
        public string? Description { get; set; } 
        public int? CompanyAddressId { get; set; } 
        public CompanyAddress? CompanyAddress { get; set; } 
        public string? ContactEmail { get; set; } 
        public string? ContactPhone { get; set; } 
        public DateTime? FoundedDate { get; set; } 
        public List<Employees>? Employees { get; set; } 
        public List<Users>? Users { get; set; } 
        public List<SalesOrders>? SalesOrders { get; set; } 
        public List<PurchaseOrders>? PurchaseOrders { get; set; } 
    }
}
