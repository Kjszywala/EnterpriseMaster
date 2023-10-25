using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class WhatsNewsServices :
        BaseServices<WhatsNew>,
        IWhatsNewsServices
    {
        public WhatsNewsServices()
            : base("/api/v1.0/WhatsNew/")
        {
        }
    }
}
