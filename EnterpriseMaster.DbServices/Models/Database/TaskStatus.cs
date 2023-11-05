namespace EnterpriseMaster.DbServices.Models.Database
{
    public class TaskStatus : Bases
    {
        public string Status { get; set; }
        public List<Tasks>? Tasks { get; set; }
    }
}
