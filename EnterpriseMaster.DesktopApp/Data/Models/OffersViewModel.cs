namespace EnterpriseMaster.DesktopApp.Data.Models
{
    public class OffersViewModel
    {
        public string? ProductName { get; set; }
        public string? OfferName { get; set; }
        public string? OfferDescrition { get; set; }
        public DateTime? AvailableFrom { get; set; }
        public DateTime? AvailableTo { get; set; }
        public decimal? Discount { get; set; }
        public bool? Active { get; set; }
        public bool? Rejected { get; set; }
    }
}
