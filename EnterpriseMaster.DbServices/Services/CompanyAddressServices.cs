using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class CompanyAddressServices :
        BaseServices<CompanyAddress>,
        ICompanyAddressServices
    {
        public CompanyAddressServices() 
            : base("/api/v1.0/CompanyAddresses/")
        {
        }
    }
}
