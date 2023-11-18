namespace EnterpriseMaster.DbServices.Models.Database
{
    public class ReturnsStatuses : Bases
    {
        public string Status { get; set; }
        public List<Returns>? Returns { get; set; }
    }
}
