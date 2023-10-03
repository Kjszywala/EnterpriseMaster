namespace EnterpriseMaster.DbServices.Models.Database
{
    public class SubscriptionTypes : Bases
    {
        public string SubscriptionName { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int? FeatureId { get; set; }
        public byte[]? Image { get; set; }
        public ApplicationFeatures? Feature { get; set; }
        public List<Users>? Users { get; set; }
    }
}
