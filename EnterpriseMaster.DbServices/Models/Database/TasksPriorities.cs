namespace EnterpriseMaster.DbServices.Models.Database
{
    public class TasksPriorities : Bases
    {
        public string Priority { get; set; }
        List<Tasks>? Tasks { get; set;}
    }
}
