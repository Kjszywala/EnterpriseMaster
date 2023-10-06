using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class QuantityTypesServices :
        BaseServices<QuantityTypes>,
        IQuantityTypesServices
    {
        public QuantityTypesServices()
            : base("/api/v1.0/QuantityTypes")
        {
        }
    }
}
