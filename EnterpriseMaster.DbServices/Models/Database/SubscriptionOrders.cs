namespace EnterpriseMaster.DbServices.Models.Database
{
	public class SubscriptionOrders : Bases
	{
        public int? StatusId { get; set; }
        public OrderStatuses? Status { get; set; }
    }
}
