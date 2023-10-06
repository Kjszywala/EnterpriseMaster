namespace EnterpriseMaster.DbServices.Models.Database
{
    public class InvoiceStatuses : Bases
    {
        public string Status { get; set; }
        public List<Invoices>? Invoices { get; set; }
    }
}
