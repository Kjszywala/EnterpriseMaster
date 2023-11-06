using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class InvoiceStatusService :
        BaseServices<InvoiceStatuses>,
        IInvoiceStatusService
    {
        public InvoiceStatusService() 
            : base("/api/v1.0/InvoiceStatuses/")
        {
        }
    }
}
