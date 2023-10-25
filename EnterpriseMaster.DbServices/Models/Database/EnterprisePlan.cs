namespace EnterpriseMaster.DbServices.Models.Database
{
    public class EnterprisePlan : Bases
    {
        public byte[] EnterprisePlanImage { get; set; }
        public byte[] ProductionManagement { get; set; }
        public byte[] HumanResources { get; set; }
        public byte[] AnalyticsReporting { get; set; }
    }
}
