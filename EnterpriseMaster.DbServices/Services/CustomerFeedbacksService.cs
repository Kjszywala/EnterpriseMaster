using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class CustomerFeedbacksService :
        BaseServices<CustomerFeedbacks>,
        ICustomerFeedbacksService
    {
        public CustomerFeedbacksService()
            : base("/api/v1.0/CustomerFeedbacks/")
        {
        }
    }
}
