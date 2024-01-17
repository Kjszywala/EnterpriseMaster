namespace EnterpriseMaster.DbServices.Models.Database
{
    public class ProfessionalPlanPage : Bases
    {
        public byte[] ProfessionalPlan { get; set; }
        public byte[] ManageCustomerData { get; set; }
        public byte[] PlanSalesActivities { get; set; }
        public byte[] AdvancedAccounting { get; set; }
        public string Title { get; set; }
        public string ProfessionalPlanTextTitle { get; set; }
        public string ProfessionalPlanText { get; set; }
        public string ManageCustomerDataTextTitle { get; set; }
        public string ManageCustomerDataText { get; set; }
        public string PlanSalesActivitiesTextTitle { get; set; }
        public string PlanSalesActivitiesText { get; set; }
        public string AdvancedAccountingTextTitle { get; set; }
        public string AdvancedAccountingText { get; set; }
        public string GetStarted { get; set; }
    }
}
