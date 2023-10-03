namespace EnterpriseMaster.DbServices.Models.Database
{
	public class ShippingAddresses : Addresses
	{
		public List<CustomerInformation>? CustomerInformations { get; set; }
	}
}
