using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class InvoicesServices :
        BaseServices<Invoices>,
        IInvoicesServices
    {
        public InvoicesServices()
            : base("/api/v1.0/Invoices/")
        {
        }
    }
}
