namespace EnterpriseMaster.DbServices.Models.Database
{
    public class Tasks : Bases
    {
        public string Task { get; set; }
        public string Description { get; set; }
        public bool IsRemoved { get; set; }
        public bool IsCompleted { get; set; }
        public int? EmployeeId { get; set; }
        public Employees? Employee { get; set; }
    }
}
