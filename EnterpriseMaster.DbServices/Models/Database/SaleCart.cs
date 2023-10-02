namespace EnterpriseMaster.DbServices.Models.Database
{
    public class SaleCart
    {
        public int Id { get; set; }
        public string SessionId { get; set; }
        public int? SubscriptionTypesId { get; set; }
        public SubscriptionTypes? SubscriptionType { get; set; }
        public int Quantity { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
