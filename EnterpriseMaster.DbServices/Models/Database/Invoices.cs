namespace EnterpriseMaster.DbServices.Models.Database
{
	public class Invoices : Bases
	{
        public string InvoiceNumber { get; set; }
        public int? OrderId { get; set; }
        public Orders? Order { get; set; }
        public int? PaymentMethodId { get; set; }
        public PaymentMethods? PaymentMethod { get; set; }
    }
}
