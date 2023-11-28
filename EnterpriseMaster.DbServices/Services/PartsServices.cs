using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class PartsServices :
        BaseServices<Parts>,
        IPartsServices
    {
        public PartsServices()
            : base("/api/v1.0/Parts/")
        {
        }
    }
}
