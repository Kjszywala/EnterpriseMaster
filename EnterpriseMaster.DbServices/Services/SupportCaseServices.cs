using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class SupportCaseServices :
        BaseServices<SupportCases>,
        ISupportCaseServices
    {
        public SupportCaseServices() 
            : base("/api/v1.0/SupportCases/")
        {
        }
    }
}
