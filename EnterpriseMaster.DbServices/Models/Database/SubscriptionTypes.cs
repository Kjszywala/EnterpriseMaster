namespace EnterpriseMaster.DbServices.Models.Database
{
    public class SubscriptionTypes : Bases
    {
        public string SubscriptionName { get; set; }
        public string? Description { get; set; }
        public int? FeatureId { get; set; }
        public ApplicationFeatures? Feature { get; set; }
    }
}
