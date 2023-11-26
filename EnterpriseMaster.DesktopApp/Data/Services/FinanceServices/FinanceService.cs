﻿using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;
using EnterpriseMaster.DesktopApp.Data.Models;
using Microsoft.CodeAnalysis;

namespace EnterpriseMaster.DesktopApp.Data.Services.FinanceServices
{
    public class FinanceService
    {
        #region Variables

        private readonly IPaymentMethodsServices paymentMethodsServices;
        private readonly IPurchaseOrdersServices purchaseOrdersServices;
        private readonly ISalesOrdersServices salesOrdersServices;
        private readonly IInvoicesServices invoicesServices;
        private readonly IPaymentServices paymentServices;
        private readonly IErrorLogsServices errorLogsServices;
        private readonly IProductsServices productsServices;

        #endregion

        #region Variables

        public FinanceService(
            IPaymentMethodsServices _paymentMethodsServices, 
            IPurchaseOrdersServices _purchaseOrdersServices, 
            ISalesOrdersServices _salesOrdersServices, 
            IInvoicesServices _invoicesServices,
            IPaymentServices _paymentServices,
            IErrorLogsServices _errorLogsServices,
            IProductsServices _productsServices)
        {
            paymentMethodsServices = _paymentMethodsServices;
            purchaseOrdersServices = _purchaseOrdersServices;
            salesOrdersServices = _salesOrdersServices;
            invoicesServices = _invoicesServices;
            paymentServices = _paymentServices;
            errorLogsServices = _errorLogsServices;
            productsServices = _productsServices;
        }

        #endregion

        #region Variables

        #region paymentServices

        public async Task<List<PaymentViewModel>> GetAllPaymentsForGridAsync()
        {
            try
            {
                var paymentList = (await paymentServices.GetAllAsync()).Where(item => item.IsActive == true).ToList();
                var paymentListViewModel = new List<PaymentViewModel>();

                foreach (var item in paymentList)
                {
                    var salesOrder = (await salesOrdersServices.GetAsync(item.SalesOrdersId.Value));
                    paymentListViewModel.Add(new PaymentViewModel
                    {
                        PaymentId = item.Id,
                        InvoicesCode = (await invoicesServices.GetAsync(item.InvoicesId.Value)).InvoiceNumber,
                        PaymentMethod = (await paymentMethodsServices.GetAsync(item.PaymentMethodId.Value)).PaymentType,
                        PurchaseOrderCode = (await purchaseOrdersServices.GetAsync(item.PurchaseOrderId.Value)).PurchaseOrderNumber,
                        SalesOrdersCode = salesOrder.SalesOrderNumber,
                        TotalAmount = salesOrder.PricePaid,
                        Product = (await productsServices.GetAsync( salesOrder.ProductId.Value)).ProductName,
                        Quantity = salesOrder.Quantity
                    });
                }

                return paymentListViewModel;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<List<Payments>> GetAllPaymentsAsync()
        {
            try
            {
                return (await paymentServices.GetAllAsync()).Where(item => item.IsActive == true).ToList();
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<Payments> GetPaymentsAsync(int id)
        {
            try
            {
                return (await paymentServices.GetAsync(id));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> AddPaymentsAsync(Payments payment)
        {
            try
            {
                return (await paymentServices.AddAsync(payment));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> UpdatePaymentsAsync(Payments payment)
        {
            try
            {
                return (await paymentServices.EditAsync(payment.Id, payment));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> RemovePaymentsAsync(int id)
        {
            try
            {
                return (await paymentServices.RemoveAsync(id));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        #endregion

        #region paymentMethodsServices

        public async Task<List<PaymentMethods>> GetAllPaymentMetdhodsAsync()
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

        public async Task<PaymentMethods> GetPaymentMetdhodAsync(int id)
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

        #endregion

        #region salesOrdersServices

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
