using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class SuppliersServices :
        BaseServices<Suppliers>,
        ISuppliersServices
    {
        public SuppliersServices()
            : base("/api/v1.0/Suppliers/")
        {
        }
    }
}
