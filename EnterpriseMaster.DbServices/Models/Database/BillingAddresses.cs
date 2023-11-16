namespace EnterpriseMaster.DbServices.Models.Database
{
	public class BillingAddresses : Addresses
	{
        public List<PurchaseOrders>? PurchaseOrders { get; set; }
        public List<SalesOrders>? SalesOrders { get; set; }
    }
}
