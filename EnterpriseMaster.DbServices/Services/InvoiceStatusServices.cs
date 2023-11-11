using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class InvoiceStatusServices :
        BaseServices<InvoiceStatuses>,
        IInvoiceStatusService
    {
        public InvoiceStatusServices() 
            : base("/api/v1.0/InvoiceStatuses/")
        {
        }
    }
}
