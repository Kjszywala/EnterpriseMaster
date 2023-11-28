namespace EnterpriseMaster.DbServices.Models.Database
{
    public class ProductParts : Bases
    {
        public int? ProductId { get; set; }
        public Products? Product { get; set; }

        public int? PartId { get; set; }
        public Parts? Part { get; set; }

        public int Quantity { get; set; }
    }
}
