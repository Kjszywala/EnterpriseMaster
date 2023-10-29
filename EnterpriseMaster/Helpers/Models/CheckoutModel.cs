namespace EnterpriseMaster.Helpers.Models
{
    public class CheckoutModel
    {
        public byte[] SubscriptionImage { get; set; }
        public string SubscriptionName { get; set; }
        public string SubscriptionInformation { get; set; }
        public decimal SubscriptionPrice { get; set; }
        public decimal SubscriptionVat { get; set; }
        public decimal SubscriptionPlusVat { get; set; }
        public decimal SubscriptionDelivery { get; set; }
        public decimal SubscriptionTotal { get; set; }
        public byte[] PaymentMethodImage { get; set; }
    }
}
