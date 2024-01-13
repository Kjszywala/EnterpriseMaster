namespace EnterpriseMaster.DbServices.Models.Database
{
    public class Shippers : Bases
    {
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public int? ShippingAddressId { get; set; }
        public ShippingAddresses? ShippersAddress { get; set; }
        public int? ShippersAddressId { get; set; }
        public ShippersAddresses? ShippersAddresses { get; set; }
        public int? Company { get; set; }
    }
}
