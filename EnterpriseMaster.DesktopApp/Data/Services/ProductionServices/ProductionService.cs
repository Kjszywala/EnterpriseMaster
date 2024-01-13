using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;
using EnterpriseMaster.DbServices.Services;
using EnterpriseMaster.DesktopApp.Data.Models;

namespace EnterpriseMaster.DesktopApp.Data.Services.ProductionServices
{
    public class ProductionService
    {
        #region Variables

        private readonly IErrorLogsServices errorLogsServices;
        private readonly ISalesOrdersServices salesOrdersServices;
        private readonly IProductionOrderStatusService productionOrderStatusService;
        private readonly IProductionOrderService productionOrderService;
        private readonly IProductsServices productsServices;

        #endregion

        #region Constructor

        public ProductionService(
            IErrorLogsServices _errorLogsServices,
            ISalesOrdersServices _salesOrdersServices, 
            IProductionOrderStatusService _productionOrderStatusService, 
            IProductionOrderService _productionOrderService,
            IProductsServices _productsServices)
        {
            errorLogsServices = _errorLogsServices;
            salesOrdersServices = _salesOrdersServices;
            productionOrderStatusService = _productionOrderStatusService;
            productionOrderService = _productionOrderService;
            productsServices = _productsServices;
        }

        #endregion

        #region Methods

        #region SalesOrders

        public async Task<List<SalesOrders>> GetAllSalesOrdersAsync()
        {
            try
            {
                var salesOrder = (await salesOrdersServices.GetAllAsync()).Where(item => item.IsActive == true).ToList();

                return salesOrder;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<SalesOrders> GetSalesOrderAsync(int id)
        {
            try
            {
                var salesOrder = (await salesOrdersServices.GetAsync(id));

                return salesOrder;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> UpdateSalesOrderAsync(SalesOrders order)
        {
            try
            {
                var salesOrder = (await salesOrdersServices.EditAsync(order.Id, order));

                return salesOrder;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        #endregion

        #region ProductionOrders

        public async Task<List<ProductionOrdersViewModel>> GetAllProductionOrdersForGridAsync()
        {
            try
            {
                var orders = (await productionOrderService.GetAllAsync())
                    .Where(item => item.Company == Config.CompanyId)
                    .OrderByDescending(item => item.ModificationDate)
                    .ToList();

                var orderViewModelList = new List<ProductionOrdersViewModel>();
                foreach (var item in orders)
                {
                    orderViewModelList.Add(new ProductionOrdersViewModel
                    {
                        Quantity = item.Quantity,
                        Id = item.Id,
                        DueDate = item.DueDate,
                        OrderDate = item.OrderDate,
                        ProductCode = (await productsServices.GetAsync(item.ProductId.Value)).ProductCode,
                        ProductionOrderStatus = (await productionOrderStatusService.GetAsync(item.ProductionOrderStatusId.Value)).Status,
                        ProductName = (await productsServices.GetAsync(item.ProductId.Value)).ProductName
                    });
                }

                return orderViewModelList;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<List<ProductionOrders>> GetAllProductionOrdersAsync()
        {
            try
            {
                var productionOrder = (await productionOrderService.GetAllAsync()).Where(item => item.IsActive == true && item.Company == Config.CompanyId).ToList();

                return productionOrder;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<ProductionOrders> GetProductionOrderAsync(int id)
        {
            try
            {
                var productionOrder = (await productionOrderService.GetAsync(id));

                return productionOrder;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> RemoveProductionOrderAsync(int id)
        {
            try
            {
                var productionOrder = (await productionOrderService.RemoveAsync(id));

                return productionOrder;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> AddProductionOrderAsync(ProductionOrders order)
        {
            try
            {
                order.Company = Config.CompanyId;
                var productionOrder = (await productionOrderService.AddAsync(order));

                return productionOrder;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> UpdateProductionOrderAsync(ProductionOrders order)
        {
            try
            {
                var productionOrder = (await productionOrderService.EditAsync(order.Id, order));

                return productionOrder;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        #endregion

        #region ProductionOrderStatus

        public async Task<List<ProductionOrderStatus>> GetAllProductionOrderStatusAsync()
        {
            try
            {
                var productionOrderStatus = (await productionOrderStatusService.GetAllAsync()).Where(item => item.IsActive == true).ToList();

                return productionOrderStatus;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<ProductionOrderStatus> GetProductionOrderStatuAsync(int id)
        {
            try
            {
                var productionOrderStatus = (await productionOrderStatusService.GetAsync(id));

                return productionOrderStatus;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        #endregion

        #endregion
    }
}
