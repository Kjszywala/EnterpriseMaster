namespace EnterpriseMaster.DbServices.Models.Database
{
    public class UsersAdresses : Addresses
    {
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public string? AdditionalInfo { get; set; }
        public List<Users>? Users { get; set; }
    }
}
