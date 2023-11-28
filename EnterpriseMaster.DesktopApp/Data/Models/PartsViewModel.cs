namespace EnterpriseMaster.DesktopApp.Data.Models
{
    public class PartsViewModel
    {
        public string? ProductName { get; set; }
        public string? ProductCode { get; set; }
        public string? PartName { get; set; }
        public string? Description { get; set; }
        public decimal? UnitCost { get; set; }
        public int? QuantityInStock { get; set; }
        public int? NeedToBuild { get; set; }
    }
}
