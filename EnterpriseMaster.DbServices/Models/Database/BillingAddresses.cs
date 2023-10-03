namespace EnterpriseMaster.DbServices.Models.Database
{
	public class BillingAddresses : Addresses
	{
		public List<CustomerInformation>? CustomerInformations { get; set; }
    }
}
