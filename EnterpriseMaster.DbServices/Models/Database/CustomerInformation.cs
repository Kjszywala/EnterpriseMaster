namespace EnterpriseMaster.DbServices.Models.Database
{
	public class CustomerInformation : Bases
	{
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? BillingAddressId { get; set; }
        public BillingAddresses? BillingAddress { get; set; }
        public int? ShippingAddressId { get; set; }
        public ShippingAddresses? ShippingAddress { get; set; }
    }
}
