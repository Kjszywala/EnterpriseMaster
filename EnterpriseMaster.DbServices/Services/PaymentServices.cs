using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class PaymentServices :
        BaseServices<Payments>,
        IPaymentServices
    {
        public PaymentServices()
            : base("/api/v1.0/Payments/")
        {
        }
    }
}
