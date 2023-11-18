namespace EnterpriseMaster.DbServices.Models.Database
{
    public class Returns : Bases
    {
        public int? SalesOrdersId { get; set; }
        public SalesOrders? SalesOrders { get; set; }
        public DateTime ReturnDate { get; set; }
        public string Reason { get; set; }
        public int? ReturnsStatusesId { get; set; }
        public ReturnsStatuses? Status { get; set; }
        public List<Refunds> Refunds { get; set; }
    }
}
