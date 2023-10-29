using System.ComponentModel.DataAnnotations.Schema;

namespace EnterpriseMaster.DbServices.Models.Database
{
    public class SubscriptionTypes : Bases
    {
        public string SubscriptionName { get; set; }
        public string? Description { get; set; }
		[Column(TypeName = "decimal(18, 2)")]
		public decimal Price { get; set; }
        public byte[]? Image { get; set; }
        public List<ApplicationFeatures>? ApplicationFeatures { get; set; }
        public List<Users>? Users { get; set; }
    }
}
