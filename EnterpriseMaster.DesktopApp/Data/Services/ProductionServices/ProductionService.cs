using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DesktopApp.Data.Services.ProductionServices
{
    public class ProductionService
    {
        #region Variables

        private readonly IErrorLogsServices errorLogsServices;
        private readonly ISalesOrdersServices salesOrdersServices;
        private readonly IProductionOrderStatusService productionOrderStatusService;
        private readonly IProductionOrderService productionOrderService;

        #endregion

        #region Constructor

        public ProductionService(
            IErrorLogsServices _errorLogsServices,
            ISalesOrdersServices _salesOrdersServices, 
            IProductionOrderStatusService _productionOrderStatusService, 
            IProductionOrderService _productionOrderService)
        {
            errorLogsServices = _errorLogsServices;
            salesOrdersServices = _salesOrdersServices;
            productionOrderStatusService = _productionOrderStatusService;
            productionOrderService = _productionOrderService;
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

        public async Task<List<ProductionOrders>> GetAllProductionOrdersAsync()
        {
            try
            {
                var productionOrder = (await productionOrderService.GetAllAsync()).Where(item => item.IsActive == true).ToList();

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
