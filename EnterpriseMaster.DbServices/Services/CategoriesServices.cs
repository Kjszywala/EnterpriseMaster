using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class CategoriesServices :
        BaseServices<Categories>,
        ICategoriesServices
    {
        public CategoriesServices()
            : base("/api/v1.0/Categories/")
        {
        }
    }
}
