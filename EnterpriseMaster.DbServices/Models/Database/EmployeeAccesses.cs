namespace EnterpriseMaster.DbServices.Models.Database
{
    public class EmployeeAccesses : Bases
    {
        public string Access { get; set; }
        List<Employees> Employees { get; set; }
    }
}
