using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class PartsCompaniesServices :
        BaseServices<PartsCompanies>,
        IPartsCompaniesServices
    {
        public PartsCompaniesServices()
            : base("/api/v1.0/PartsCompanies/")
        {
        }
    }
}
