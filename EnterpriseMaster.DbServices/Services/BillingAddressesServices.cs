using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class BillingAddressesServices :
        BaseServices<BillingAddresses>,
        IBillingAddressesServices
    {
        public BillingAddressesServices()
            : base("/api/v1.0/BillingAddresses")
        {
        }
    }
}
