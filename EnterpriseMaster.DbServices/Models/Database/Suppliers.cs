namespace EnterpriseMaster.DbServices.Models.Database
{
	public class Suppliers : Bases
	{
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public int? SupplierAddressId { get; set; }
        public SuppliersAddresses? SupplierAddress { get; set; }
    }
}
