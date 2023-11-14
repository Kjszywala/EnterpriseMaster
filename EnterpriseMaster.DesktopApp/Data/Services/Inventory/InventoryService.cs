using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;
using EnterpriseMaster.DbServices.Services;

namespace EnterpriseMaster.DesktopApp.Data.Services.Inventory
{
    public class InventoryService
    {
        #region Variables

        private readonly IErrorLogsServices errorLogsServices;
        private readonly IProductsServices productsServices;
        private readonly ICategoriesServices categoriesServices;
        private readonly IQuantityTypesServices quantityTypesServices;

        #endregion

        #region Constructor

        public InventoryService(
            IErrorLogsServices _errorLogsServices, 
            IProductsServices _productsServices, 
            ICategoriesServices _categoriesServices, 
            IQuantityTypesServices _quantityTypesServices)
        {
            errorLogsServices = _errorLogsServices;
            productsServices = _productsServices;
            categoriesServices = _categoriesServices;
            quantityTypesServices = _quantityTypesServices;
        }

        #endregion

        #region Methods Products

        public async Task<List<Products>> GetAllProductsAsync()
        {
            try
            {
                var products = (await productsServices.GetAllAsync()).Where(item => item.IsActive == true).ToList();
                var quantityTypes = (await quantityTypesServices.GetAllAsync()).Where(item => item.IsActive == true).ToList();
                var categories = (await categoriesServices.GetAllAsync()).Where(item => item.IsActive == true).ToList();

                foreach (var product in products)
                {
                    foreach(var category in categories)
                    {
                        if(product.CategoryId == category.Id)
                        {
                            product.Category = category;
                        }
                    }

                    foreach (var quantityType in quantityTypes)
                    {
                        if (product.QuantityTypeId == quantityType.Id)
                        {
                            product.QuantityType = quantityType;
                        }
                    }
                }

                return (await productsServices.GetAllAsync()).Where(item => item.IsActive == true).ToList();
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<Products> GetProductAsync(int id)
        {
            try
            {
                return (await productsServices.GetAsync(id));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> AddProductAsync(Products product)
        {
            try
            {
                return (await productsServices.AddAsync(product));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> UpdateProductAsync(Products product)
        {
            try
            {
                return (await productsServices.EditAsync(product.Id, product));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> RemoveProductAsync(int id)
        {
            try
            {
                return (await productsServices.RemoveAsync(id));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        #endregion

        #region Methods QuantityTypes

        public async Task<List<QuantityTypes>> GetAllQuantityTypesAsync()
        {
            try
            {
                return (await quantityTypesServices.GetAllAsync()).Where(item => item.IsActive == true).ToList();
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        #endregion

        #region Methods Categories

        public async Task<List<Categories>> GetAllCategoriesAsync()
        {
            try
            {
                return (await categoriesServices.GetAllAsync()).Where(item => item.IsActive == true).ToList();
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        #endregion

    }
}
