namespace EnterpriseMaster.DbServices.Models.Database
{
	public class Products : Bases
	{
        public string ProductName { get; set; }
        public List<Orders>? Orders { get; set; }
	}
}
