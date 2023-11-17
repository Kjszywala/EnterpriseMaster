using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class ShippersAddressesService :
        BaseServices<ShippersAddresses>,
        IShippersAddressesService
    {
        public ShippersAddressesService()
            : base("/api/v1.0/ShippersAddresses/")
        {
        }
    }
}
