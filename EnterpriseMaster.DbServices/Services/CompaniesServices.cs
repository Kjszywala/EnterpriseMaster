using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class CompaniesServices :
        BaseServices<Companies>,
        ICompaniesServices
    {
        public CompaniesServices() 
            : base("/api/v1.0/Companies/")
        {
        }
    }
}
