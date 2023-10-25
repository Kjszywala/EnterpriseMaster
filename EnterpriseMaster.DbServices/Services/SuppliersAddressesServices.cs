using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class SuppliersAddressesServices :
        BaseServices<SuppliersAddresses>,
        ISuppliersAddressesServices
    {
        public SuppliersAddressesServices()
            : base("/api/v1.0/SuppliersAddresses/")
        {
        }
    }
}
