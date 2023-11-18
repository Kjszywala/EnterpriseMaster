using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class ReturnServices :
        BaseServices<Returns>,
        IReturnServices
    {
        public ReturnServices()
            : base("/api/v1.0/Returns/")
        {
        }
    }
}
