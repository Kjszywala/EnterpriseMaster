using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DesktopApp.Data.Services.AnalyticsServices
{
    public class AnalyticsService
    {
        #region Variables

        private readonly IErrorLogsServices errorLogsServices;
        private readonly IPurchaseOrdersServices purchaseOrdersServices;
        private readonly ISalesOrdersServices salesOrdersServices;
        private readonly IEmployeesServices employeesServices;
        private readonly IProductionOrderService productionOrderServices;
        private readonly IInvoicesServices invoicesServices;
        private readonly IProductsServices productsServices;
        private readonly ITasksServices tasksServices;
        private readonly IOfferServices offerServices;

        #endregion

        #region Constructor

        public AnalyticsService(
            IErrorLogsServices _errorLogsServices,
            IPurchaseOrdersServices _purchaseOrdersServices,
            ISalesOrdersServices _salesOrdersServices,
            IEmployeesServices _employeesServices,
            IProductionOrderService _productionOrderServices,
            IInvoicesServices _invoicesServices,
            IProductsServices _productsServices,
            ITasksServices _tasksServices,
            IOfferServices _offerServices)
        {
            errorLogsServices = _errorLogsServices;
            purchaseOrdersServices = _purchaseOrdersServices;
            salesOrdersServices = _salesOrdersServices;
            employeesServices = _employeesServices;
            productionOrderServices = _productionOrderServices;
            invoicesServices = _invoicesServices;
            productsServices = _productsServices;
            tasksServices = _tasksServices;
            offerServices = _offerServices;
        }

        #endregion

        #region Methods

        #region purchaseOrdersServices

        public async Task<List<PurchaseOrders>> GetAllPurchaseOrdersAsync()
        {
            try
            {
                return (await purchaseOrdersServices.GetAllAsync()).Where(item => item.IsActive == true && item.Company == Config.CompanyId).ToList();
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<PurchaseOrders> GetPurchaseOrdersAsync(int id)
        {
            try
            {
                return (await purchaseOrdersServices.GetAsync(id));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        #endregion

        #region salesOrdersServices

        public async Task<List<SalesOrders>> GetAllSalesOrdersAsync()
        {
            try
            {
                return (await salesOrdersServices.GetAllAsync()).Where(item => item.IsActive == true && item.Company == Config.CompanyId).ToList();
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<SalesOrders> GetSalesOrdersAsync(int id)
        {
            try
            {
                return (await salesOrdersServices.GetAsync(id));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        #endregion

        #region employeesServices

        public async Task<List<Employees>> GetAllEmployeesAsync()
        {
            try
            {
                return (await employeesServices.GetAllAsync()).Where(item => item.IsActive == true && item.CompanyId == Config.CompanyId).ToList();
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<Employees> GetEmployeesAsync(int id)
        {
            try
            {
                return (await employeesServices.GetAsync(id));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        #endregion

        #region productionOrderServices

        public async Task<List<ProductionOrders>> GetAllProductionOrdersAsync()
        {
            try
            {
                return (await productionOrderServices.GetAllAsync()).Where(item => item.IsActive == true && item.Company == Config.CompanyId).ToList();
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<ProductionOrders> GetProductionOrdersAsync(int id)
        {
            try
            {
                return (await productionOrderServices.GetAsync(id));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        #endregion

        #region invoicesServices

        public async Task<List<Invoices>> GetAllInvoicesAsync()
        {
            try
            {
                return (await invoicesServices.GetAllAsync()).Where(item => item.IsActive == true && item.Company == Config.CompanyId).ToList();
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<Invoices> GetInvoiceAsync(int id)
        {
            try
            {
                return (await invoicesServices.GetAsync(id));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        #endregion

        #region productsServices

        public async Task<List<Products>> GetAllProductsAsync()
        {
            try
            {
                return (await productsServices.GetAllAsync()).Where(item => item.IsActive == true && item.Company == Config.CompanyId).ToList();
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<Products> GetProductsAsync(int id)
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

        #endregion

        #region tasksServices

        public async Task<List<Tasks>> GetAllTasksAsync()
        {
            try
            {
                return (await tasksServices.GetAllAsync()).Where(item => item.IsActive == true && item.Company == Config.CompanyId).ToList();
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<Tasks> GetTasksAsync(int id)
        {
            try
            {
                return (await tasksServices.GetAsync(id));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        #endregion

        #region offerServices

        public async Task<List<Offers>> GetAllOffersAsync()
        {
            try
            {
                return (await offerServices.GetAllAsync()).Where(item => item.IsActive == true && item.Company == Config.CompanyId).ToList();
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<Offers> GetOffersAsync(int id)
        {
            try
            {
                return (await offerServices.GetAsync(id));
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
