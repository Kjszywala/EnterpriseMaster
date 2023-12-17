using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class PaymentReportsServices :
        BaseServices<PaymentReports>,
        IPaymentReportsServices
    {
        public PaymentReportsServices()
            : base("/api/v1.0/PaymentReports/")
        {
        }
    }
}
