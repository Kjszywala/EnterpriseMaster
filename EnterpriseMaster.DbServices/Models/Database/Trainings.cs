namespace EnterpriseMaster.DbServices.Models.Database
{
    public class Trainings : Bases
    {
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Location { get; set; }
        public string? Instructor { get; set; }
        public DateTime RegistrationDeadline { get; set; }
        public string? Materials { get; set; }
        public string? Status { get; set; }
        public string? Category { get; set; }
        public bool? Certification { get; set; }
        public string? Organizer { get; set; }
        public string? Prerequisites { get; set; }
        public string? Format { get; set; }
        public string? TargetAudience { get; set; }
        public int? Company { get; set; }
    }
}
