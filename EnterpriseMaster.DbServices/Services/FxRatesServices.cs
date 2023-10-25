using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class FxRatesServices : 
        BaseServices<FxRates>,
        IFxRatesServices
    {
        public FxRatesServices()
            : base("/api/v1.0/FxRates/")
        {
        }
    }
}
