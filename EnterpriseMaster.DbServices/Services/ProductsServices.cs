using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class ProductsServices :
        BaseServices<Products>,
        IProductsServices
    {
        public ProductsServices()
            : base("/api/v1.0/Products")
        {
        }
    }
}
