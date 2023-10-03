namespace EnterpriseMaster.DbServices.Models.Database
{
	public class PaymentMethods : Bases
	{
        public string PaymentType { get; set; }
		public byte[]? ItemImage { get; set; }
	}
}
