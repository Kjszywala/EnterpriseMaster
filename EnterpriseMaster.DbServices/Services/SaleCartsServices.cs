using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class SaleCartsServices :
        BaseServices<SaleCart>,
        ISaleCartsServices
    {
        public SaleCartsServices()
            : base("/api/v1.0/SaleCart")
        {
        }
    }
}
