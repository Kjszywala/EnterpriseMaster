using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class OfferServices :
        BaseServices<Offers>,
        IOfferServices
    {
        public OfferServices()
            : base("/api/v1.0/Offers/")
        {
        }
    }
}
