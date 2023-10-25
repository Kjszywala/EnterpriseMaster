using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class CustomerInformationsServices :
        BaseServices<CustomerInformation>,
        ICustomerInformationsServices
    {
        public CustomerInformationsServices()
            : base("/api/v1.0/CustomerInformations/")
        {
        }
    }
}
