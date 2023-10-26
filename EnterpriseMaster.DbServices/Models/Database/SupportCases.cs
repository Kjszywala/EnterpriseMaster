namespace EnterpriseMaster.DbServices.Models.Database
{
    public class SupportCases : Bases
    {
        public string Description { get; set; }
        public int? CaseStatusId { get; set; }
        public CaseStatus? CaseStatus { get; set; }
        public int? UserId { get; set; }
        public Users? User { get; set; }
    }
}
