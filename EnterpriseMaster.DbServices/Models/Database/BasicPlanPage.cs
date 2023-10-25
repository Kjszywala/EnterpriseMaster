namespace EnterpriseMaster.DbServices.Models.Database
{
    public class BasicPlanPage : Bases
    {
        public byte[] BasicSales { get; set; }
        public byte[] BasicInventory { get; set; }
        public byte[] BasicFinancialManagement { get; set; }
        public byte[] CreateOffers { get; set; }
        public byte[] ManageOrders { get; set; }
        public byte[] GenerateInvoices { get; set; }
    }
}
