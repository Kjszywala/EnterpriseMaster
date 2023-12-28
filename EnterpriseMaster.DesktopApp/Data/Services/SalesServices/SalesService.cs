using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;
using EnterpriseMaster.DbServices.Services;
using EnterpriseMaster.DesktopApp.Data.Models;

namespace EnterpriseMaster.DesktopApp.Data.Services.SalesServices
{
    public class SalesService
    {
        #region Variables

        private readonly IErrorLogsServices errorLogsServices;
        private readonly IRefudsServices refudsServices;
        private readonly IReturnServices returnServices;
        private readonly IReturnStatusService returnStatus;
        private readonly ISalesOrdersServices salesOrdersServices;
        private readonly IProductsServices productsServices;
        private readonly IQuantityTypesServices quantityTypesServices;
        private readonly IOrderStatusesServices orderStatusesServices;
        private readonly IShippersServices shippersServices;
        private readonly IShippersAddressesService shippersAddressesService;
        private readonly IShippingAddressesServices shippingAddressesServices;

        #endregion

        #region Constructor

        public SalesService(
            IErrorLogsServices _errorLogsServices, 
            IRefudsServices _refudsServices, 
            IReturnServices _returnServices, 
            IReturnStatusService _returnStatus, 
            ISalesOrdersServices _salesOrdersServices,
            IProductsServices _productsServices,
            IQuantityTypesServices _quantityTypesService,
            IOrderStatusesServices _orderStatusesServices,
            IShippersServices _shippersServices,
            IShippersAddressesService _shippersAddressesService,
            IShippingAddressesServices _shippingAddressesServices)
        {
            errorLogsServices = _errorLogsServices;
            refudsServices = _refudsServices;
            returnServices = _returnServices;
            returnStatus = _returnStatus;
            salesOrdersServices = _salesOrdersServices;
            productsServices = _productsServices;
            quantityTypesServices = _quantityTypesService;
            orderStatusesServices = _orderStatusesServices;
            shippersServices = _shippersServices;
            quantityTypesServices = _quantityTypesService;
            orderStatusesServices = _orderStatusesServices;
            shippersServices = _shippersServices;
            shippersAddressesService = _shippersAddressesService;
            shippingAddressesServices = _shippingAddressesServices;
        }

        #endregion

        #region Methods

        #region refudsServices

        public async Task<List<Refunds>> GetAllRefundsAsync()
        {
            try
            {
                return (await refudsServices.GetAllAsync()).Where(item => item.IsActive == true).ToList();
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<Refunds> GetRefundsAsync(int id)
        {
            try
            {
                return (await refudsServices.GetAsync(id));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> AddRefundsAsync(Refunds refunds)
        {
            try
            {
                return (await refudsServices.AddAsync(refunds));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> UpdateRefundsAsync(Refunds refunds)
        {
            try
            {
                return (await refudsServices.EditAsync(refunds.Id, refunds));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> RemoveRefundsAsync(int id)
        {
            try
            {
                return (await refudsServices.RemoveAsync(id));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        #endregion

        #region returnServices

        public async Task<List<Returns>> GetAllReturnsAsync()
        {
            try
            {
                return (await returnServices.GetAllAsync()).Where(item => item.IsActive == true).ToList();
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<Returns> GetReturnsAsync(int id)
        {
            try
            {
                return (await returnServices.GetAsync(id));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> AddReturnsAsync(Returns returns)
        {
            try
            {
                return (await returnServices.AddAsync(returns));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> UpdateReturnsAsync(Returns returns)
        {
            try
            {
                return (await returnServices.EditAsync(returns.Id, returns));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> RemoveReturnsAsync(int id)
        {
            try
            {
                return (await returnServices.RemoveAsync(id));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        #endregion

        #region returnStatus

        public async Task<List<ReturnsStatuses>> GetAllReturnsStatusesAsync()
        {
            try
            {
                return (await returnStatus.GetAllAsync()).Where(item => item.IsActive == true).ToList();
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<ReturnsStatuses> GetReturnsStatusesAsync(int id)
        {
            try
            {
                return (await returnStatus.GetAsync(id));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        #endregion

        #region Order Status

        public async Task<OrderStatuses> GetOrderStatusAsync(int id)
        {
            try
            {
                return (await orderStatusesServices.GetAsync(id));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        #endregion

        #region salesOrdersServices

        public async Task<List<OrderViewModel>> GetAllSalesOrdersForGridAsync()
        {
            try
            {
                var saleOrders = (await salesOrdersServices.GetAllAsync())
                    .Where(item => item.IsActive == true)
                    .OrderByDescending(item => item.ModificationDate)
                    .ToList();

                var saleViewModelList = new List<OrderViewModel>();

                foreach (var order in saleOrders)
                {
                    saleViewModelList.Add(new OrderViewModel
                    {
                        Id = order.Id,
                        OrderStatus = (await orderStatusesServices.GetAsync(order.OrderStatuseId.Value)).Discription,
                        OrderNumber = order.SalesOrderNumber,
                        PaymentTerm = order.PaymentTerm,
                        PricePaid = order.PricePaid,
                        ProductCode = (await productsServices.GetAsync(order.ProductId.Value)).ProductCode,
                        ProductName = (await productsServices.GetAsync(order.ProductId.Value)).ProductName,
                        Quantity = order.Quantity,
                        QuantityType = (await quantityTypesServices.GetAsync(order.QuantityTypeId.Value)).Type
                    });

                }

                return saleViewModelList;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

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

        public async Task<bool> UpdateSalesOrdersAsync(SalesOrders shippers)
        {
            try
            {
                return (await salesOrdersServices.EditAsync(shippers.Id, shippers));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> RemoveSalesOrdersAsync(int id)
        {
            try
            {
                return (await salesOrdersServices.RemoveAsync(id));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        #endregion

        #region Shippers

        public async Task<List<ShippersViewModel>> GetAllShippersForGridAsync()
        {
            try
            {
                var shippers = (await shippersServices.GetAllAsync()).Where(item => item.IsActive == true).ToList();

                var shippersViewModelList = new List<ShippersViewModel>();
                foreach (var item in shippers)
                {
                    shippersViewModelList.Add(new ShippersViewModel
                    {
                        CompanyName = item.CompanyName,
                        ContactName = item.ContactName,
                        Email = item.Email,
                        Phone = item.Phone,
                        City = (await shippersAddressesService.GetAsync(item.ShippersAddressId.Value)).City,
                        HouseNumber = (await shippersAddressesService.GetAsync(item.ShippersAddressId.Value)).HouseNumber,
                        PostCode = (await shippersAddressesService.GetAsync(item.ShippersAddressId.Value)).PostCode,
                        Street = (await shippersAddressesService.GetAsync(item.ShippersAddressId.Value)).Street
                    });
                }

                return shippersViewModelList;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<List<Shippers>> GetAllShippersAsync()
        {
            try
            {
                return (await shippersServices.GetAllAsync()).Where(item => item.IsActive == true).ToList();
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<Shippers> GetShipperAsync(int id)
        {
            try
            {
                return (await shippersServices.GetAsync(id));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> AddShipperAsync(Shippers shippers)
        {
            try
            {
                return (await shippersServices.AddAsync(shippers));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> UpdateShipperAsync(Shippers shippers)
        {
            try
            {
                return (await shippersServices.EditAsync(shippers.Id, shippers));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> RemoveShipperAsync(int id)
        {
            try
            {
                return (await shippersServices.RemoveAsync(id));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<List<ShippersAddresses>> GetAllShipperAddressAsync()
        {
            try
            {
                return (await shippersAddressesService.GetAllAsync()).Where(item => item.IsActive == true).ToList();
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<ShippersAddresses> GetShipperAddressAsync(int id)
        {
            try
            {
                return (await shippersAddressesService.GetAsync(id));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> AddShipperAddressAsync(ShippersAddresses shippers)
        {
            try
            {
                return (await shippersAddressesService.AddAsync(shippers));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> UpdateShipperAddressAsync(ShippersAddresses shippers)
        {
            try
            {
                return (await shippersAddressesService.EditAsync(shippers.Id, shippers));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> RemoveShipperAddressAsync(int id)
        {
            try
            {
                return (await shippersAddressesService.RemoveAsync(id));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        #endregion

        #region ShippingAddresses

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

        public async Task<bool> AddShippingAddressesAsync(ShippingAddresses shippers)
        {
            try
            {
                return (await shippingAddressesServices.AddAsync(shippers));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> UpdateShippingAddressesAsync(ShippingAddresses shippers)
        {
            try
            {
                return (await shippingAddressesServices.EditAsync(shippers.Id, shippers));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> RemoveShippingAddressesAsync(int id)
        {
            try
            {
                return (await shippingAddressesServices.RemoveAsync(id));
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
