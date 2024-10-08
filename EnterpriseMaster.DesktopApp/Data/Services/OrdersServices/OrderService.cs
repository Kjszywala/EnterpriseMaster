﻿using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;
using EnterpriseMaster.DesktopApp.Data.Models;
using EnterpriseMaster.DesktopApp.Helpers.Enums;
using Microsoft.Build.Framework;

namespace EnterpriseMaster.DesktopApp.Data.Services.OrdersServices
{
    public class OrderService
    {
        #region Variables

        private readonly IErrorLogsServices errorLogsServices;
        private readonly IPurchaseOrdersServices purchaseOrdersServices;
        private readonly ISalesOrdersServices salesOrdersServices;
        private readonly IEmployeesServices employeeService;
        private readonly IBillingAddressesServices billingAddressesServices;
        private readonly IShippersServices shippersServices;
        private readonly IShippingAddressesServices shippingAddressServices;
        private readonly IProductionOrderService productionOrderService;
        private readonly IProductsServices productsServices;
        private readonly IPartsServices partsServices;
        private readonly IQuantityTypesServices quantityTypesServices;
        private readonly ISuppliersServices suppliersServices;
        private readonly ISuppliersAddressesServices suppliersAddressesServices;
        private readonly IOrderStatusesServices orderStatusesServices;
        private readonly IPurchaseOrderReportsService purchaseOrderReportsService;

        #endregion

        #region Constructor

        public OrderService(
            IErrorLogsServices _errorLogsServices, 
            IPurchaseOrdersServices _purchaseOrdersServices, 
            ISalesOrdersServices _salesOrdersServices, 
            IEmployeesServices _employeeService, 
            IBillingAddressesServices _billingAddressesServices, 
            IShippersServices _shippersServices, 
            IShippingAddressesServices _shippingAddressServices,
            IProductionOrderService _productionOrderService,
            IQuantityTypesServices _quantityTypesServices,
            IProductsServices _productsServices,
            IPartsServices _partsServices,
            ISuppliersAddressesServices _suppliersAddressesServices,
            ISuppliersServices _suppliersServices,
            IOrderStatusesServices _orderStatusesServices,
            IPurchaseOrderReportsService _purchaseOrderReportsService)
        {
            errorLogsServices = _errorLogsServices;
            purchaseOrdersServices = _purchaseOrdersServices;
            salesOrdersServices = _salesOrdersServices;
            employeeService = _employeeService;
            billingAddressesServices = _billingAddressesServices;
            shippersServices = _shippersServices;
            shippingAddressServices = _shippingAddressServices;
            productionOrderService = _productionOrderService;
            productsServices = _productsServices;
            quantityTypesServices = _quantityTypesServices;
            partsServices = _partsServices;
            suppliersAddressesServices = _suppliersAddressesServices;
            suppliersServices = _suppliersServices;
            orderStatusesServices = _orderStatusesServices;
            purchaseOrderReportsService = _purchaseOrderReportsService;
        }

        #endregion

        #region Methods

        #region OrderStatus

        public async Task<OrderStatuses> GetPurchaseOrderStatusAsync(int id)
        {
            try
            {
                var purchaseOrdersStatus = (await orderStatusesServices.GetAsync(id));

                return purchaseOrdersStatus;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        #endregion

        #region PartsServices

        public async Task<List<PartsViewModel>> GetAllPartsForGridAsync()
        {
            try
            {
                var parts = (await partsServices.GetAllAsync()).Where(item => item.IsActive == true && item.Company == Config.CompanyId).ToList();

                var partsViewModel = new List<PartsViewModel>();
                foreach (var item in parts)
                {
                    partsViewModel.Add(new PartsViewModel
                    {
                        Description = item.Description,
                        PartName = item.PartName,
                        ProductCode = (await productsServices.GetAsync(item.ProductsId.Value)).ProductCode,
                        ProductName = (await productsServices.GetAsync(item.ProductsId.Value)).ProductName,
                        QuantityInStock = item.QuantityInStock,
                        UnitCost = item.UnitCost,
                        NeedToBuild = (await partsServices.GetAllAsync())
                                        .Where(item2 => item2.ProductsId == item.ProductsId)
                                        .Sum(item2 => item2.ProductsId)
                    });
                }

                return partsViewModel;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<List<Parts>> GetAllPartsAsync()
        {
            try
            {
                var parts = (await partsServices.GetAllAsync()).Where(item => item.IsActive == true && item.Company == Config.CompanyId).ToList();

                return parts;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<Parts> GetPartsAsync(int id)
        {
            try
            {
                var parts = (await partsServices.GetAsync(id));

                return parts;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> RemovePartsAsync(int id)
        {
            try
            {
                var parts = (await partsServices.RemoveAsync(id));

                return parts;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> AddPartsAsync(Parts part)
        {
            try
            {
                part.Company = Config.CompanyId;
                var parts = (await partsServices.AddAsync(part));

                return parts;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> UpdatePartsAsync(Parts part)
        {
            try
            {
                var parts = (await partsServices.EditAsync(part.Id, part));

                return parts;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        #endregion

        #region Purchase Order Reports

        public async Task<bool> AddPurchaseOrderReportAsync(PurchaseOrderReports report)
        {
            try
            {
                report.Company = Config.CompanyId;
                var purchaseOrdersReports = (await purchaseOrderReportsService.AddAsync(report));

                return purchaseOrdersReports;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        #endregion

        #region Purchase Orders

        public async Task<List<OrderViewModel>> GetAllPurchaseOrdersForGridAsync()
        {
            try
            {
                var purchaseOrders = (await purchaseOrdersServices.GetAllAsync())
                    .Where(item => item.IsActive == true && item.CompanyId == Config.CompanyId)
                    .OrderByDescending(item => item.ModificationDate)
                    .ToList();

                foreach (var purchaseOrder in purchaseOrders)
                {
                    purchaseOrder.Part = await partsServices.GetAsync(purchaseOrder.PartId.Value);
                }

                var orderViewModelList = new List<OrderViewModel>();
                foreach (var item in purchaseOrders)
                {
                    orderViewModelList.Add(new OrderViewModel
                    {
                        OrderStatus = (await orderStatusesServices.GetAsync(item.OrderStatuseId.Value)).Discription,
                        OrderNumber = item.PurchaseOrderNumber,
                        PaymentTerm = item.PaymentTerm,
                        PricePaid = item.PricePaid,
                        ProductCode = (await productsServices.GetAsync(item.Part.ProductsId.Value)).ProductCode,
                        ProductName = (await partsServices.GetAsync(item.PartId.Value)).PartName,
                        Quantity = item.Quantity,
                        QuantityType = (await quantityTypesServices.GetAsync(item.QuantityTypeId.Value)).Type,
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

        public async Task<List<PurchaseOrderManagementViewModel>> GetAllPurchaseOrdersManagementForGridAsync()
        {
            try
            {
                var purchaseOrders = (await purchaseOrdersServices.GetAllAsync())
                    .Where(item => item.CompanyId == Config.CompanyId)
                    .OrderByDescending(item => item.ModificationDate)
                    .ToList();

                foreach (var purchaseOrder in purchaseOrders)
                {
                    purchaseOrder.Part = await partsServices.GetAsync(purchaseOrder.PartId.Value);
                }

                var orderViewModelList = new List<PurchaseOrderManagementViewModel>();
                foreach (var item in purchaseOrders)
                {
                    orderViewModelList.Add(new PurchaseOrderManagementViewModel
                    {
                        OrderStatus = (await orderStatusesServices.GetAsync(item.OrderStatuseId.Value)).Discription,
                        OrderNumber = item.PurchaseOrderNumber,
                        PaymentTerm = item.PaymentTerm,
                        PricePaid = item.PricePaid,
                        ProductCode = (await productsServices.GetAsync(item.Part.ProductsId.Value)).ProductCode,
                        ProductName = (await partsServices.GetAsync(item.PartId.Value)).PartName,
                        Quantity = item.Quantity,
                        QuantityType = (await quantityTypesServices.GetAsync(item.QuantityTypeId.Value)).Type,
                        Id = item.Id,
                        DateCreated = item.CreationDate,
                        DateUpdated = item.ModificationDate,
                        Description = (await partsServices.GetAsync(item.PartId.Value)).Description,
                        PartName = (await partsServices.GetAsync(item.PartId.Value)).PartName
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

        public async Task<List<PurchaseOrderManagementViewModel>> GetAllPurchaseOrdersReportForGridAsync(DateTime dateFrom, DateTime dateTo)
        {
            try
            {
                var purchaseOrders = (await purchaseOrdersServices.GetAllAsync())
                    .Where(item => item.ModificationDate > dateFrom && item.ModificationDate < dateTo && item.CompanyId == Config.CompanyId)
                    .OrderByDescending(item => item.ModificationDate)
                    .ToList();

                foreach (var purchaseOrder in purchaseOrders)
                {
                    purchaseOrder.Part = await partsServices.GetAsync(purchaseOrder.PartId.Value);
                }

                var orderViewModelList = new List<PurchaseOrderManagementViewModel>();
                foreach (var item in purchaseOrders)
                {
                    orderViewModelList.Add(new PurchaseOrderManagementViewModel
                    {
                        OrderStatus = (await orderStatusesServices.GetAsync(item.OrderStatuseId.Value)).Discription,
                        OrderNumber = item.PurchaseOrderNumber,
                        PaymentTerm = item.PaymentTerm,
                        PricePaid = item.PricePaid,
                        ProductCode = (await productsServices.GetAsync(item.Part.ProductsId.Value)).ProductCode,
                        ProductName = (await partsServices.GetAsync(item.PartId.Value)).PartName,
                        Quantity = item.Quantity,
                        QuantityType = (await quantityTypesServices.GetAsync(item.QuantityTypeId.Value)).Type,
                        Id = item.Id,
                        DateCreated = item.CreationDate,
                        DateUpdated = item.ModificationDate,
                        Description = (await partsServices.GetAsync(item.PartId.Value)).Description,
                        PartName = (await partsServices.GetAsync(item.PartId.Value)).PartName
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

        public async Task<List<PurchaseOrders>> GetAllOpenPurchaseOrdersAsync()
        {
            try
            {
                var purchaseOrders = (await purchaseOrdersServices.GetAllAsync())
                    .Where(item => item.IsActive == true && 
                        item.OrderStatuseId == (int)StatusForOrder.Open &&
                        item.CompanyId == Config.CompanyId)
                    .ToList();

                return purchaseOrders;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<List<PurchaseOrders>> GetAllPurchaseOrdersAsync()
        {
            try
            {
                var purchaseOrders = (await purchaseOrdersServices.GetAllAsync()).Where(item => item.CompanyId == Config.CompanyId).ToList();

                return purchaseOrders;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<List<PurchaseOrders>> GetAllPurchaseOrdersApprovedAsync()
        {
            try
            {
                var purchaseOrders = (await purchaseOrdersServices.GetAllAsync())
                    .Where(item => item.IsActive == true && 
                        item.OrderStatuseId == (int)StatusForOrder.InProgress && 
                        item.CompanyId == Config.CompanyId)
                    .ToList();

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
                order.CompanyId = Config.CompanyId;
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
                var salesOrder = (await salesOrdersServices.GetAllAsync()).Where(item => item.IsActive == true && item.Company == Config.CompanyId).ToList();

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
                order.Company = Config.CompanyId;
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
                var employees = (await employeeService.GetAllAsync()).Where(item => item.IsActive == true && item.CompanyId == Config.CompanyId).ToList();

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

        #region Shippers

        public async Task<List<Shippers>> GetAllShippersAsync()
        {
            try
            {
                var shippers = (await shippersServices.GetAllAsync()).Where(item => item.IsActive == true && item.Company == Config.CompanyId).ToList();

                return shippers;
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
                var shipper = (await shippersServices.GetAsync(id));

                return shipper;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        #endregion

        #region Supplier Address

        public async Task<List<SuppliersAddresses>> GetAllSupplierAddressesAsync()
        {
            try
            {
                var addresses = (await suppliersAddressesServices.GetAllAsync()).Where(item => item.IsActive == true).ToList();

                return addresses;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<SuppliersAddresses> GetSupplierAddressAsync(int id)
        {
            try
            {
                var address = (await suppliersAddressesServices.GetAsync(id));

                return address;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> RemoveSupplierAddressAsync(int id)
        {
            try
            {
                var salesOrder = (await suppliersAddressesServices.RemoveAsync(id));

                return salesOrder;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> AddSupplierAddressAsync(SuppliersAddresses suppliersAddresses)
        {
            try
            {
                var address = (await suppliersAddressesServices.AddAsync(suppliersAddresses));

                return address;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> UpdateSupplierAddressAsync(SuppliersAddresses suppliersAddresses)
        {
            try
            {
                var address = (await suppliersAddressesServices.EditAsync(suppliersAddresses.Id, suppliersAddresses));

                return address;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        #endregion

        #region Suppliers

        public async Task<List<SuppliersViewModel>> GetAllSupplierForGridAsync()
        {
            try
            {
                var suppliers = (await suppliersServices.GetAllAsync()).Where(item => item.IsActive == true && item.Company == Config.CompanyId).ToList();

                var supplierViewModelList = new List<SuppliersViewModel>();
                foreach (var item in suppliers)
                {
                    supplierViewModelList.Add(new SuppliersViewModel
                    {
                        CompanyName = item.CompanyName,
                        ContactName = item.ContactName,
                        Email = item.Email,
                        Phone = item.Phone,
                        City = (await suppliersAddressesServices.GetAsync(item.SupplierAddressId.Value)).City,
                        HouseNumber = (await suppliersAddressesServices.GetAsync(item.SupplierAddressId.Value)).HouseNumber,
                        PostCode = (await suppliersAddressesServices.GetAsync(item.SupplierAddressId.Value)).PostCode,
                        Street = (await suppliersAddressesServices.GetAsync(item.SupplierAddressId.Value)).Street
                    });
                }

                return supplierViewModelList;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<List<Suppliers>> GetAllSupplierAsync()
        {
            try
            {
                var sup = (await suppliersServices.GetAllAsync()).Where(item => item.IsActive == true).ToList();

                return sup;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<Suppliers> GetSupplierAsync(int id)
        {
            try
            {
                var sup = (await suppliersServices.GetAsync(id));

                return sup;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> RemoveSupplierAsync(int id)
        {
            try
            {
                var sup = (await suppliersServices.RemoveAsync(id));

                return sup;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> AddSupplierAsync(Suppliers supplier)
        {
            try
            {
                supplier.Company = Config.CompanyId;
                var sup = (await suppliersServices.AddAsync(supplier));

                return sup;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> UpdateSupplierAsync(Suppliers supplier)
        {
            try
            {
                var sup = (await suppliersServices.EditAsync(supplier.Id, supplier));

                return sup;
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

        #endregion

        #endregion

    }
}
