using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;
using EnterpriseMaster.DbServices.Services;

namespace EnterpriseMaster.DesktopApp.Data.Services.OrdersService
{
    public class OrdersService
    {
        #region Variables

        private readonly IErrorLogsServices errorLogsServices;
        private readonly IPurchaseOrdersServices purchaseOrdersServices;
        private readonly ISalesOrdersServices salesOrdersServices;
        private readonly IEmployeesServices employeeService;
        private readonly IBillingAddressesServices billingAddressesServices;
        private readonly IShippersServices shippersServices;
        private readonly IShippingAddressesServices shippingAddressServices;

        #endregion

        #region Constructor

        public OrdersService(
            IErrorLogsServices _errorLogsServices, 
            IPurchaseOrdersServices _purchaseOrdersServices, 
            ISalesOrdersServices _salesOrdersServices, 
            IEmployeesServices _employeeService, 
            IBillingAddressesServices _billingAddressesServices, 
            IShippersServices _shippersServices, 
            IShippingAddressesServices _shippingAddressServices)
        {
            errorLogsServices = _errorLogsServices;
            purchaseOrdersServices = _purchaseOrdersServices;
            salesOrdersServices = _salesOrdersServices;
            employeeService = _employeeService;
            billingAddressesServices = _billingAddressesServices;
            shippersServices = _shippersServices;
            shippingAddressServices = _shippingAddressServices;
        }

        #endregion

        #region Methods

        #region Purchase Orders

        public async Task<List<PurchaseOrders>> GetAllPurchaseOrdersAsync()
        {
            try
            {
                var purchaseOrders = (await purchaseOrdersServices.GetAllAsync()).Where(item => item.IsActive == true).ToList();

                return purchaseOrders;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<PurchaseOrders> GetPurchaseOrderAsync(int id)
        {
            try
            {
                var purchaseOrders = (await purchaseOrdersServices.GetAsync(id));

                return purchaseOrders;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> RemovePurchaseOrderAsync(int id)
        {
            try
            {
                var purchaseOrders = (await purchaseOrdersServices.RemoveAsync(id));

                return purchaseOrders;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> AddPurchaseOrderAsync(PurchaseOrders order)
        {
            try
            {
                var purchaseOrders = (await purchaseOrdersServices.AddAsync(order));

                return purchaseOrders;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> UpdatePurchaseOrderAsync(PurchaseOrders order)
        {
            try
            {
                var purchaseOrders = (await purchaseOrdersServices.EditAsync(order.Id, order));

                return purchaseOrders;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        #endregion

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

        public async Task<bool> RemoveSalesOrderAsync(int id)
        {
            try
            {
                var salesOrder = (await salesOrdersServices.RemoveAsync(id));

                return salesOrder;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> AddSalesOrderAsync(SalesOrders order)
        {
            try
            {
                var salesOrder = (await salesOrdersServices.AddAsync(order));

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

        #region Employee

        public async Task<List<Employees>> GetAllEmployeesAsync()
        {
            try
            {
                var employees = (await employeeService.GetAllAsync()).Where(item => item.IsActive == true).ToList();

                return employees;
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
                var employee = (await employeeService.GetAsync(id));

                return employee;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        #endregion

        #region Billing Address

        public async Task<List<BillingAddresses>> GetAllBillingAddressesAsync()
        {
            try
            {
                var addresses = (await billingAddressesServices.GetAllAsync()).Where(item => item.IsActive == true).ToList();

                return addresses;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<BillingAddresses> GetBillingAddressAsync(int id)
        {
            try
            {
                var address = (await billingAddressesServices.GetAsync(id));

                return address;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> RemoveBillingAddressAsync(int id)
        {
            try
            {
                var salesOrder = (await billingAddressesServices.RemoveAsync(id));

                return salesOrder;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> AddBillingAddressAsync(BillingAddresses billingAddress)
        {
            try
            {
                var address = (await billingAddressesServices.AddAsync(billingAddress));

                return address;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> UpdateBillingAddressAsync(BillingAddresses billingAddress)
        {
            try
            {
                var address = (await billingAddressesServices.EditAsync(billingAddress.Id, billingAddress));

                return address;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        #endregion

        #region Shipping Address

        public async Task<List<ShippingAddresses>> GetAllShippingAddressesAsync()
        {
            try
            {
                var addresses = (await shippingAddressServices.GetAllAsync()).Where(item => item.IsActive == true).ToList();

                return addresses;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<ShippingAddresses> GetShippingAddressAsync(int id)
        {
            try
            {
                var address = (await shippingAddressServices.GetAsync(id));

                return address;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> RemoveShippingAddressAsync(int id)
        {
            try
            {
                var salesOrder = (await shippingAddressServices.RemoveAsync(id));

                return salesOrder;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> AddShippingAddressAsync(ShippingAddresses billingAddress)
        {
            try
            {
                var address = (await shippingAddressServices.AddAsync(billingAddress));

                return address;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> UpdateShippingAddressAsync(ShippingAddresses billingAddress)
        {
            try
            {
                var address = (await shippingAddressServices.EditAsync(billingAddress.Id, billingAddress));

                return address;
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
