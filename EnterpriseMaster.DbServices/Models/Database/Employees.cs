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
        public DateTime HireDate { get; set; }
    }
}
