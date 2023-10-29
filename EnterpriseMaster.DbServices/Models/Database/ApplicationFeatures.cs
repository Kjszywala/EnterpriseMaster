namespace EnterpriseMaster.DbServices.Models.Database
{
    public class ApplicationFeatures : Bases
    {
        public string FeatureName { get; set; }
        public string? Description { get; set; }
        public byte[]? Image { get; set; }
        public int? SubscriptionTypeId { get; set; }
        public SubscriptionTypes? SubscriptionType { get; set; }
    }
}
