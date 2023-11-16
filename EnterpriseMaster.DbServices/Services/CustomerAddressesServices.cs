using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class CustomerAddressesServices :
        BaseServices<CustomerAddresses>,
        ICustomerAddressesService
    {
        public CustomerAddressesServices()
            : base("/api/v1.0/CompanyAddress/")
        {
        }
    }
}
