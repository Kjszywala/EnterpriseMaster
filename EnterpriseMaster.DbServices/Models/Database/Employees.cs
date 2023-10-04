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
        public int? EmployeeAddressID { get; set; }
        public EmployeeAddresses? EmployeeAddress { get; set; }
    }
}
