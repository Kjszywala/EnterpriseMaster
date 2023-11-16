namespace EnterpriseMaster.DbServices.Models.Database
{
    public class CustomerAddresses : Addresses
    {
        public List<CustomerInformation>? CustomerInformation { get; set; }
    }
}
