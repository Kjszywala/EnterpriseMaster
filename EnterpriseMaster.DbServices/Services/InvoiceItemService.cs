using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class InvoiceItemService :
        BaseServices<InvoiceItem>,
        IInvoiceItemService
    {
        public InvoiceItemService()
            : base("/api/v1.0/InvoiceItems/")
        {
        }
    }
}
