namespace EnterpriseMaster.DbServices.Models.Database
{
	public class Orders : Bases
	{
        public int Quantity { get; set; }
        public decimal PricePaid { get; set; }
        public decimal Discount { get; set; }
        public int? CustomerInformationId { get; set; }
		public CustomerInformation? CustomerInformation { get; set; }
		public int? EmployeeId { get; set; }
		public Employees? Employee { get; set; }
		public int? ProductId { get; set; }
		public Products? Product { get; set; }
	}
}
