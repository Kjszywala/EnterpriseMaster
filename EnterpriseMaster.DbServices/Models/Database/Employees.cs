namespace EnterpriseMaster.DbServices.Models.Database
{
	public class Employees : Bases
	{
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public string? Salary { get; set; }
        public byte[]? Image { get; set; }
        public DateTime? HireDate { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public List<SalesOrders>? SalesOrders { get; set; }
        public int? EmployeeAddressId { get; set; }
        public EmployeeAddresses? EmployeeAddress { get; set; }
        public int? CompanyId { get; set; }
        public Companies? Company { get; set; }
        public int? UserId { get; set; }
        public Users? User { get; set; }
        public int? EmployeeAccessId { get; set; }
        public EmployeeAccesses? EmployeeAccess { get; set; }
        public List<Tasks>? Tasks { get; set; }
        public List<PurchaseOrders>? PurchaseOrders { get; set; }
        public List<PurchaseOrderReports>? PurchaseOrderReports { get; set; }
        public List<EmployeeRoles>? EmployeeRoles { get; set; }
        public List<Offers>? Offers { get; set; }
        public List<InventoryReports>? InventoryReports { get; set; }
    }
}
