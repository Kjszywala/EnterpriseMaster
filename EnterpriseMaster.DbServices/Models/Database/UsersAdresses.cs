namespace EnterpriseMaster.DbServices.Models.Database
{
    public class UsersAdresses : Addresses
    {
        public string? State { get; set; }
        public string? AdditionalInfo { get; set; }
        public List<Users>? Users { get; set; }
    }
}
