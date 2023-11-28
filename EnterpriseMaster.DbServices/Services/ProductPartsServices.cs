using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    internal class ProductPartsServices :
        BaseServices<ProductParts>,
        IProductPartsServices
    {
        public ProductPartsServices()
            : base("/api/v1.0/ProductParts/")
        {
        }
    }
}
