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
        public string? Title { get; set; }
        public string? BasicSalesTextTitle { get; set; }
        public string? BasicSalesText { get; set; }
        public string? BasicInventoryTextTitle { get; set; }
        public string? BasicInventoryText { get; set; }
        public string? BasicFinancialManagementTextTitle { get; set; }
        public string? BasicFinancialManagementText { get; set; }
        public string? BasicCreateOffersTextTitle { get; set; }
        public string? BasicCreateOffersText { get; set; }
        public string? BasicManageOrdersTextTitle { get; set; }
        public string? BasicManageOrdersText { get; set; }
        public string? BasicGenerateInvoicesTextTitle { get; set; }
        public string? BasicGenerateInvoicesText { get; set; }
        public string? GetStarted { get; set; }
    }
}
