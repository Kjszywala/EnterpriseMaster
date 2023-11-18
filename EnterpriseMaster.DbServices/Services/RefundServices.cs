using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class RefundServices :
        BaseServices<Refunds>,
        IRefudsServices
    {
        public RefundServices()
            : base("/api/v1.0/Refunds/")
        {
        }
    }
}
