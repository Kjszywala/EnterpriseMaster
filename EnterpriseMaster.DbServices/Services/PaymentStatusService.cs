using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class PaymentStatusService :
        BaseServices<PaymentStatus>,
        IPaymentStatusService
    {
        public PaymentStatusService()
            : base("/api/v1.0/PaymentStatus/")
        {
        }
    }
}
