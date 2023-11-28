namespace EnterpriseMaster.DbServices.Models.Database
{
    public class Parts : Bases
    {
        public string PartName { get; set; }
        public string Description { get; set; }
        public decimal UnitCost { get; set; }
        public int QuantityInStock { get; set; }
        public List<ProductParts>? Products { get; set; }
    }
}
