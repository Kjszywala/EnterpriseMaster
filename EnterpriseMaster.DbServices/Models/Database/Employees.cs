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
        public DateTime HireDate { get; set; }
        public List<Orders>? Orders { get; set; }
        public int? EmployeeAddressId { get; set; }
        public EmployeeAddresses? EmployeeAddress { get; set; }
        public int? CompanyId { get; set; }
        public Companies? Company { get; set; }
        public int? UserId { get; set; }
        public Users? User { get; set; }
        public List<Tasks>? Tasks { get; set; }
        public int? EmployeeId { get; set; }
        public Employees? Employee { get; set; }
    }
}
