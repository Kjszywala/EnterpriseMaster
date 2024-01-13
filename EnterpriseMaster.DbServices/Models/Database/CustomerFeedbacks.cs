namespace EnterpriseMaster.DbServices.Models.Database
{
    public class CustomerFeedbacks : Bases
    {
        public int? CustomerId { get; set; }
        public CustomerInformation? Customer { get; set; }
        public string? FeedbackText { get; set; }
        public int? Company { get; set; }
        public int Rating { get; set; }
    }
}
