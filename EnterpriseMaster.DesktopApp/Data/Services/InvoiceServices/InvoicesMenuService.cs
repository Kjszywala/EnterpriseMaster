using BlazorBootstrap;
using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;
using EnterpriseMaster.DesktopApp.Data.Models;

namespace EnterpriseMaster.DesktopApp.Data.Services.InvoiceServices
{
    public class InvoicesMenuService
    {
        #region Variables

        private readonly IErrorLogsServices errorLogsServices;
        private readonly IInvoicesServices invoicesServices;
        private readonly IInvoiceItemService invoiceItemService;
        private readonly IInvoiceStatusService invoiceStatusService;
        private readonly ICustomerInformationsServices customerInformationsServices;
        private readonly IPaymentMethodsServices paymentMethodsServices;
        private readonly IPurchaseOrdersServices purchaseOrdersServices;
        private readonly ISalesOrdersServices salesOrdersServices;
        private readonly IBillingAddressesServices billingAddressesServices;
        private readonly IShippingAddressesServices shippingAddressesServices;
        private readonly IProductsServices productsServices;

        #endregion

        #region Constructor

        public InvoicesMenuService(
            IErrorLogsServices _errorLogsServices,
            IInvoicesServices _invoicesServices,
            IInvoiceItemService _invoiceItemService,
            IInvoiceStatusService _invoiceStatusService,
            ICustomerInformationsServices _customerInformationsServices,
            IPaymentMethodsServices _paymentMethodsServices,
            IPurchaseOrdersServices _purchaseOrdersServices,
            ISalesOrdersServices _salesOrdersServices,
            IBillingAddressesServices _billingAddressesServices,
            IShippingAddressesServices _shippingAddressesServices,
            IProductsServices _productsServices)
        {
            errorLogsServices = _errorLogsServices;
            invoicesServices = _invoicesServices;
            invoiceItemService = _invoiceItemService;
            invoiceStatusService = _invoiceStatusService;
            customerInformationsServices = _customerInformationsServices;
            paymentMethodsServices = _paymentMethodsServices;
            purchaseOrdersServices = _purchaseOrdersServices;
            salesOrdersServices = _salesOrdersServices;
            billingAddressesServices = _billingAddressesServices;
            shippingAddressesServices = _shippingAddressesServices;
            productsServices = _productsServices;
        }

        #endregion

        #region Methods
      
        #region invoicesServices

        public async Task<List<InvoiceViewModel>> GetAllInvoicesForGridAsync()
        {
            try
            {
                var invoices = (await invoicesServices.GetAllAsync())
                    .Where(item => item.IsActive == true)
                    .OrderByDescending(item => item.ModificationDate)
                    .ToList();

                var invoiceViewModel = new List<InvoiceViewModel>();

                foreach (var invoice in invoices)
                {
                    var item = (await invoiceItemService.GetAsync(invoice.InvoiceItemId.Value));
                    invoiceViewModel.Add(new InvoiceViewModel
                    {
                        Email = (await customerInformationsServices.GetAsync(invoice.CustomerInformationId.Value)).Email,
                        ProductName = (await productsServices.GetAsync(item.ProductId.Value)).ProductName,
                        ProductCode = (await productsServices.GetAsync(item.ProductId.Value)).ProductCode,
                        Discount = (await salesOrdersServices.GetAsync(invoice.SalesOrderId.Value)).Discount,
                        Quantity = (await salesOrdersServices.GetAsync(invoice.SalesOrderId.Value)).Quantity,
                        OrderDate = (await salesOrdersServices.GetAsync(invoice.SalesOrderId.Value)).OrderDate,
                        TotalAmount = (await salesOrdersServices.GetAsync(invoice.SalesOrderId.Value)).PricePaid
                    });

                }

                return invoiceViewModel;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<List<Invoices>> GetAllInvoicesAsync()
        {
            try
            {
                return (await invoicesServices.GetAllAsync()).Where(item => item.IsActive == true).ToList();
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

        public async Task<bool> AddInvoiceAsync(Invoices invoice)
        {
            try
            {
                return (await invoicesServices.AddAsync(invoice));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> UpdateInvoiceAsync(Invoices invoice)
        {
            try
            {
                return (await invoicesServices.EditAsync(invoice.Id, invoice));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> RemoveInvoiceAsync(int id)
        {
            try
            {
                return (await invoicesServices.RemoveAsync(id));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        #endregion

        #region invoiceItemService

        public async Task<List<InvoiceItem>> GetAllInvoiceItemAsync()
        {
            try
            {
                return (await invoiceItemService.GetAllAsync()).Where(item => item.IsActive == true).ToList();
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<InvoiceItem> GetInvoiceItemAsync(int id)
        {
            try
            {
                return (await invoiceItemService.GetAsync(id));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> AddInvoiceItemAsync(InvoiceItem invoiceItem)
        {
            try
            {
                return (await invoiceItemService.AddAsync(invoiceItem));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> UpdateInvoiceItemAsync(InvoiceItem invoiceItem)
        {
            try
            {
                return (await invoiceItemService.EditAsync(invoiceItem.Id, invoiceItem));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> RemoveInvoiceItemAsync(int id)
        {
            try
            {
                return (await invoiceItemService.RemoveAsync(id));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        #endregion

        #region invoiceStatusService

        public async Task<List<InvoiceStatuses>> GetAllInvoiceStatusesAsync()
        {
            try
            {
                return (await invoiceStatusService.GetAllAsync()).Where(item => item.IsActive == true).ToList();
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<InvoiceStatuses> GetInvoiceStatuseAsync(int id)
        {
            try
            {
                return (await invoiceStatusService.GetAsync(id));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        #endregion

        #region customerInformationsServices

        public async Task<List<CustomerInformation>> GetAllCustomerInformationAsync()
        {
            try
            {
                return (await customerInformationsServices.GetAllAsync()).Where(item => item.IsActive == true).ToList();
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<CustomerInformation> GetCustomerInformationAsync(int id)
        {
            try
            {
                return (await customerInformationsServices.GetAsync(id));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        #endregion

        #region paymentMethodsServices

        public async Task<List<PaymentMethods>> GetAllPaymentMethodsAsync()
        {
            try
            {
                return (await paymentMethodsServices.GetAllAsync()).Where(item => item.IsActive == true).ToList();
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<PaymentMethods> GetPaymentMethodAsync(int id)
        {
            try
            {
                return (await paymentMethodsServices.GetAsync(id));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        #endregion

        #region purchaseOrdersServices

        public async Task<List<PurchaseOrders>> GetAllPurchaseOrdersAsync()
        {
            try
            {
                return (await purchaseOrdersServices.GetAllAsync()).Where(item => item.IsActive == true).ToList();
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
                return (await salesOrdersServices.GetAllAsync()).Where(item => item.IsActive == true).ToList();
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
                return (await salesOrdersServices.GetAsync(id));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        #endregion

        #region billingAddressesServices

        public async Task<List<BillingAddresses>> GetAllBillingAddressesAsync()
        {
            try
            {
                return (await billingAddressesServices.GetAllAsync()).Where(item => item.IsActive == true).ToList();
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<BillingAddresses> GetBillingAddressesAsync(int id)
        {
            try
            {
                return (await billingAddressesServices.GetAsync(id));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> AddBillingAddressesAsync(BillingAddresses billing)
        {
            try
            {
                return (await billingAddressesServices.AddAsync(billing));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> UpdateBillingAddressesAsync(BillingAddresses billing)
        {
            try
            {
                return (await billingAddressesServices.EditAsync(billing.Id, billing));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        #endregion

        #region shippingAddressesServices

        public async Task<List<ShippingAddresses>> GetAllShippingAddressesAsync()
        {
            try
            {
                return (await shippingAddressesServices.GetAllAsync()).Where(item => item.IsActive == true).ToList();
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<ShippingAddresses> GetShippingAddressesAsync(int id)
        {
            try
            {
                return (await shippingAddressesServices.GetAsync(id));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> AddShippingAddressesAsync(ShippingAddresses billing)
        {
            try
            {
                return (await shippingAddressesServices.AddAsync(billing));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> UpdateShippingAddressesAsync(ShippingAddresses billing)
        {
            try
            {
                return (await shippingAddressesServices.EditAsync(billing.Id, billing));
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
