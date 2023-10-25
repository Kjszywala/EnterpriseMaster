using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class EmployeeAddressesServices :
        BaseServices<EmployeeAddresses>,
        IEmployeeAddressesServices
    {
        public EmployeeAddressesServices()
            : base("/api/v1.0/EmployeeAddresses/")
        {
        }
    }
}
