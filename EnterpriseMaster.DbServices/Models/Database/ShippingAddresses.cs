namespace EnterpriseMaster.DbServices.Models.Database
{
	public class ShippingAddresses : Addresses
	{
        public List<PurchaseOrders>? PurchaseOrders { get; set; }
        public List<SalesOrders>? SalesOrders { get; set; }
    }
}
