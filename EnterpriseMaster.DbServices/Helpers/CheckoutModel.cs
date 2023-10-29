using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Helpers
{
    public class CheckoutModel
    {
        public byte[] SubscriptionImage { get; set; }
        public string SubscriptionName { get; set; }
        public string SubscriptionInformation { get; set; }
        public decimal SubscriptionPrice { get; set; }
        public decimal SubscriptionVat { get; set; }
        public decimal SubscriptionPlusVat { get; set; }
        public decimal SubscriptionTotal { get; set; }
        public byte[] PaymentMethodImage { get; set; }
        public List<ApplicationFeatures>? ApplicationFeatures { get; set; }
        public string? FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Email { get; set; }
        public string? Contry { get; set; }
    }
}
