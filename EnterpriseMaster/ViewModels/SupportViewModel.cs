using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.ViewModels
{
    public class SupportViewModel
    {
        public List<SupportCases>? SupportCasesList { get; set; }
        public List<SupportCases>? HistoryCasesList { get; set; }
        public SupportCases? SupportCases { get; set; }
    }
}
