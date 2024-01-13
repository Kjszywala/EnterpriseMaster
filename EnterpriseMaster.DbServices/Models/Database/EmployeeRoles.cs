namespace EnterpriseMaster.DbServices.Models.Database
{
    public class EmployeeRoles : Bases
    {
        public int? EmployeeId { get; set; }
        public Employees? Employees { get; set; }
        public int? RoleId { get; set; }
        public Roles? Roles { get; set; }
        public int? Company { get; set; }
    }
}
