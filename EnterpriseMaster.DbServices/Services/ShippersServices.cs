using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class ShippersServices :
        BaseServices<Shippers>,
        IShippersServices
    {
        public ShippersServices()
           : base("/api/v1.0/Shippers")
        {
        }
    }
}
