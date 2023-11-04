using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class CaseStatusServices :
        BaseServices<CaseStatus>,
        ICaseStatusServices
    {
        public CaseStatusServices() 
            : base("/api/v1.0/CaseStatus/")
        {
        }
    }
}
