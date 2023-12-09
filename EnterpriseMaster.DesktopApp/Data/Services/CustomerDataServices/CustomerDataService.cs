using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;
using EnterpriseMaster.DesktopApp.Data.Models;

namespace EnterpriseMaster.DesktopApp.Data.Services.CustomerDataServices
{
    public class CustomerDataService
    {
        #region Variables

        private readonly IErrorLogsServices errorLogsServices;
        private readonly ICustomerInformationsServices informationServices;
        private readonly ICustomerAddressesService addressesServices;
        private readonly ICompaniesServices companiesServices;
        private readonly IBillingAddressesServices billingAddressesServices;
        private readonly IShippingAddressesServices shippingAddressesServices;
        private readonly ISalesOrdersServices salesOrdersServices;
        private readonly IInvoicesServices invoicesServices;

        #endregion

        #region Constructor

        public CustomerDataService(
            IErrorLogsServices _errorLogsServices, 
            ICustomerInformationsServices _informationServices, 
            ICustomerAddressesService _addressesServices, 
            ICompaniesServices _companiesServices, 
            IBillingAddressesServices _billingAddressesServices, 
            IShippingAddressesServices _shippingAddressesServices, 
            ISalesOrdersServices _salesOrdersServices, 
            IInvoicesServices _invoicesServices)
        {
            errorLogsServices = _errorLogsServices;
            informationServices = _informationServices;
            addressesServices = _addressesServices;
            companiesServices = _companiesServices;
            billingAddressesServices = _billingAddressesServices;
            shippingAddressesServices = _shippingAddressesServices;
            salesOrdersServices = _salesOrdersServices;
            invoicesServices = _invoicesServices;
        }

        #endregion

        #region Methods

        #region informationServices

        public async Task<List<CustomerDataViewModel>> GetAllCustomerInformationForGridAsync()
        {
            try
            {
                var customers = (await informationServices.GetAllAsync())
                    .Where(item => item.IsActive == true)
                    .OrderByDescending(item => item.ModificationDate)
                    .ToList();

                var list = new List<CustomerDataViewModel>();
                foreach (var customer in customers)
                {
                    list.Add(new CustomerDataViewModel
                    {
                        ComapnyName = customer.CompanyName,
                        Email = customer.Email,
                        FirstName = customer.FirstName,
                        LastName = customer.LastName,
                        Phone = customer.Phone
                    });
                }
                return list;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }


        public async Task<List<CustomerInformation>> GetAllCustomerInformationAsync()
        {
            try
            {
                return (await informationServices.GetAllAsync()).Where(item => item.IsActive == true).ToList();
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
                return (await informationServices.GetAsync(id));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> AddCustomerInformationAsync(CustomerInformation customer)
        {
            try
            {
                return (await informationServices.AddAsync(customer));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> UpdateCustomerInformationAsync(CustomerInformation customer)
        {
            try
            {
                return (await informationServices.EditAsync(customer.Id, customer));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> RemoveCustomerInformationeAsync(int id)
        {
            try
            {
                return (await informationServices.RemoveAsync(id));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        #endregion

        #region addressesServices

        public async Task<List<CustomerAddresses>> GetAllCustomerAddressesAsync()
        {
            try
            {
                return (await addressesServices.GetAllAsync()).Where(item => item.IsActive == true).ToList();
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<CustomerAddresses> GetCustomerAddressesAsync(int id)
        {
            try
            {
                return (await addressesServices.GetAsync(id));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> AddCustomerAddressesAsync(CustomerAddresses address)
        {
            try
            {
                return (await addressesServices.AddAsync(address));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> UpdateCustomerAddressesAsync(CustomerAddresses address)
        {
            try
            {
                return (await addressesServices.EditAsync(address.Id, address));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> RemoveCustomerAddressesAsync(int id)
        {
            try
            {
                return (await addressesServices.RemoveAsync(id));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        #endregion

        #region companiesServices

        public async Task<List<Companies>> GetAllCompaniesAsync()
        {
            try
            {
                return (await companiesServices.GetAllAsync()).Where(item => item.IsActive == true).ToList();
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<Companies> GetCompaniesAsync(int id)
        {
            try
            {
                return (await companiesServices.GetAsync(id));
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

        #region invoicesServices

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

        #endregion

        #endregion
    }
}
