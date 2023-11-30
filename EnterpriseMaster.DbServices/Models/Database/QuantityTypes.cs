namespace EnterpriseMaster.DbServices.Models.Database
{
	public class QuantityTypes : Bases
	{
        public string Type { get; set; }
        public List<Orders>? Orders { get; set; }
        public List<Products>? Products { get; set; }
        public List<Parts>? Parts { get; set; }
    }
}
