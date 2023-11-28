namespace EnterpriseMaster.DbServices.Models.Database
{
    public class PartsCompanies : Bases
    {
        public string CompanyName { get; set; }
        public string? Description { get; set; }
        public string? ContactEmail { get; set; }
        public string? ContactPhone { get; set; }
        public List<Parts>? Parts { get; set; }
    }
}
