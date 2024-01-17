namespace EnterpriseMaster.DbServices.Models.Database
{
    public class EnterprisePlan : Bases
    {
        public byte[] EnterprisePlanImage { get; set; }
        public byte[] ProductionManagement { get; set; }
        public byte[] HumanResources { get; set; }
        public byte[] AnalyticsReporting { get; set; }
        public string? Title { get; set; }
        public string? EnterprisePlanTitle { get; set; }
        public string? EnterprisePlanText { get; set; }
        public string? ProductionManagementTitle { get; set; }
        public string? ProductionManagementText { get; set; }
        public string? HumanResourcesTitle { get; set; }
        public string? HumanResourcesText { get; set; }
        public string? AnalyticsReportingTitle { get; set; }
        public string? AnalyticsReportingText { get; set; }
        public string? GetStarted { get; set; }
    }
}
