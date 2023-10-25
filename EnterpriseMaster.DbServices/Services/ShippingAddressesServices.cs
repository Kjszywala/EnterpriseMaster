using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class ShippingAddressesServices :
        BaseServices<ShippingAddresses>,
        IShippingAddressesServices
    {
        public ShippingAddressesServices()
            : base("/api/v1.0/ShippingAddresses/")
        {
        }
    }
}
