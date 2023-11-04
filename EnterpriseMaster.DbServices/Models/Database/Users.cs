namespace EnterpriseMaster.DbServices.Models.Database
{
    public class Users : Bases
    {
        public string? Title { get; set; }
        public string? FirstName { get; set; }
        public string? SecondName { get; set; }
        public string Password { get; set; }
        public string? CompanyName { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Position { get; set; }
        public string? BusinesArea { get; set; }
        public int? SubscriptionTypeId { get; set; }
        public SubscriptionTypes? SubscriptionType { get; set; }
        public byte[]? Image { get; set; }
        public bool IsEmployee { get; set; }
        public bool Newsletter { get; set; }
        public int? UserAddressId { get; set; }
        public UsersAdresses? UserAddress { get; set; }
        public List<SupportCases>? SupportCases { get; set; }
    }
}
