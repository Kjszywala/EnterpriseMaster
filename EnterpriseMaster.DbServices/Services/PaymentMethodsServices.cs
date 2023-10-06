using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class PaymentMethodsServices :
        BaseServices<PaymentMethods>,
        IPaymentMethodsServices
    {
        public PaymentMethodsServices()
            : base("/api/v1.0/PaymentMethods")
        {
        }
    }
}
