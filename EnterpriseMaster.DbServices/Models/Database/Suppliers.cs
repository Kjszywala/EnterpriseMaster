namespace EnterpriseMaster.DbServices.Models.Database
{
	public class Suppliers : Bases
	{
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string? Description { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public int? SupplierAddressId { get; set; }
        public SuppliersAddresses? SupplierAddress { get; set; }
        public List<PurchaseOrders>? PurchaseOrders { get; set; }
        public List<Parts>? Parts { get; set; }
        public int? Company { get; set; }
    }
}
