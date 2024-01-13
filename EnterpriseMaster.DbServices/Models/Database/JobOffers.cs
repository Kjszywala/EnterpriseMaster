namespace EnterpriseMaster.DbServices.Models.Database
{
    public class JobOffers : Bases
    {
        public string? JobTitle { get; set; }
        public string? CompanyName { get; set; }
        public string? Location { get; set; }
        public string? JobDescription { get; set; }
        public string? Requirements { get; set; }
        public string? ApplicationLink { get; set; }
        public decimal? Salary { get; set; }
        public string? EmploymentType { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public int? Company { get; set; }
        public string? ContactEmail { get; set; }
        public string? ContactPhone { get; set; }
        public string? Status { get; set; }
        public DateTime? ApplicationDeadline { get; set; }
        public string? Responsibilities { get; set; }
        public string? Benefits { get; set; }
        public string? Department { get; set; }
        public string? ExperienceLevel { get; set; }
        public string? Skills { get; set; }
    }
}
