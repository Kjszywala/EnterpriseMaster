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
        private readonly IPaymentStatusService paymentStatusService;
        private readonly IPartsServices partsServices;
        private readonly IPaymentReportsServices paymentReportsServices;

        #endregion

        #region Constructor

        public FinanceService(
            IPaymentMethodsServices _paymentMethodsServices, 
            IPurchaseOrdersServices _purchaseOrdersServices, 
            ISalesOrdersServices _salesOrdersServices, 
            IInvoicesServices _invoicesServices,
            IPaymentServices _paymentServices,
            IErrorLogsServices _errorLogsServices,
            IProductsServices _productsServices,
            IPaymentStatusService _paymentStatusService,
            IPartsServices _partsServices,
            IPaymentReportsServices _paymentReportsServices)
        {
            paymentMethodsServices = _paymentMethodsServices;
            purchaseOrdersServices = _purchaseOrdersServices;
            salesOrdersServices = _salesOrdersServices;
            invoicesServices = _invoicesServices;
            paymentServices = _paymentServices;
            errorLogsServices = _errorLogsServices;
            productsServices = _productsServices;
            paymentStatusService = _paymentStatusService;
            partsServices = _partsServices;
            paymentReportsServices = _paymentReportsServices;
        }

        #endregion

        #region Methods

        #region Payment Reports

        public async Task<bool> AddPaymentReportsAsync(PaymentReports report)
        {
            try
            {
                report.Company = Config.CompanyId;
                return (await paymentReportsServices.AddAsync(report));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        #endregion

        #region PaymentStatus

        public async Task<PaymentStatus> GetPaymentStatusAsyncBasedOnStatus(string status)
        {
            try
            {
                return (await paymentStatusService.GetAllAsync()).Where(item => item.Status == status).FirstOrDefault();
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<PaymentStatus> GetPaymentStatusAsync(int id)
        {
            try
            {
                return (await paymentStatusService.GetAsync(id));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        #endregion

        #region paymentServices

        public async Task<List<PaymentViewModel>> GetAllPaymentsForGridAsync()
        {
            try
            {
                var paymentList = (await paymentServices.GetAllAsync())
                    .Where(item => item.IsActive == true && item.Company == Config.CompanyId)
                    .OrderByDescending(item => item.ModificationDate)
                    .ToList();

                var paymentListViewModel = new List<PaymentViewModel>();

                foreach (var item in paymentList)
                {
                    var salesOrder = (await purchaseOrdersServices.GetAsync(item.PurchaseOrderId.Value));
                    paymentListViewModel.Add(new PaymentViewModel
                    {
                        PaymentId = item.Id,
                        InvoicesCode = item.InvoicesId != null ? (await invoicesServices.GetAsync(item.InvoicesId.Value)).InvoiceNumber : "None",
                        PaymentMethod = (await paymentMethodsServices.GetAsync(item.PaymentMethodId.Value)).PaymentType,
                        PurchaseOrderCode = (await purchaseOrdersServices.GetAsync(item.PurchaseOrderId.Value)).PurchaseOrderNumber,
                        SalesOrdersCode = salesOrder.PurchaseOrderNumber,
                        TotalAmount = salesOrder.PricePaid,
                        Product = (await partsServices.GetAsync( salesOrder.PartId.Value)).PartName,
                        Quantity = salesOrder.Quantity,
                        PaymentStatus = (await paymentStatusService.GetAsync(item.PaymentStatuId.Value)).Status
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

        public async Task<List<PaymentViewModel>> GetAllPaymentsForGridBasedOnDatesAsync(DateTime dateFrom, DateTime dateTo)
        {
            try
            {
                var paymentList = (await paymentServices.GetAllAsync())
                    .Where(item => item.ModificationDate > dateFrom && 
                        item.ModificationDate < dateTo && 
                        item.Company == Config.CompanyId)
                    .OrderByDescending(item => item.ModificationDate)
                    .ToList();

                var paymentListViewModel = new List<PaymentViewModel>();

                foreach (var item in paymentList)
                {
                    var salesOrder = (await purchaseOrdersServices.GetAsync(item.PurchaseOrderId.Value));
                    paymentListViewModel.Add(new PaymentViewModel
                    {
                        PaymentId = item.Id,
                        InvoicesCode = item.InvoicesId != null ? (await invoicesServices.GetAsync(item.InvoicesId.Value)).InvoiceNumber : "None",
                        PaymentMethod = (await paymentMethodsServices.GetAsync(item.PaymentMethodId.Value)).PaymentType,
                        PurchaseOrderCode = (await purchaseOrdersServices.GetAsync(item.PurchaseOrderId.Value)).PurchaseOrderNumber,
                        SalesOrdersCode = salesOrder.PurchaseOrderNumber,
                        TotalAmount = salesOrder.PricePaid,
                        Product = (await partsServices.GetAsync(salesOrder.PartId.Value)).PartName,
                        Quantity = salesOrder.Quantity,
                        PaymentStatus = (await paymentStatusService.GetAsync(item.PaymentStatuId.Value)).Status
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

        public async Task<List<PaymentsMonthly>> CalculateMonthlySumAsync()
        {
            var payments = (await GetAllPaymentsAsync()).Where(item => item.ModificationDate.Year == DateTime.Now.Year && item.Company == Config.CompanyId);

            var monthlySum = payments
                .GroupBy(payment => new { Year = payment.ModificationDate.Year, Month = payment.ModificationDate.Month })
                .Select(group => new PaymentsMonthly
                {
                    Year = group.Key.Year,
                    Month = group.Key.Month,
                    TotalAmount = group.Sum(payment => payment.TotalAmount)
                })
                .OrderBy(group => group.Year)
                .ThenBy(group => group.Month)
                .ToList();

            return monthlySum;
        }

        public async Task<List<double>> CalculateMonthlyTotalAmountsAsync()
        {
            var payments = (await GetAllPaymentsAsync()).Where(item => item.Company == Config.CompanyId);

            var monthlyTotalAmounts = payments
                .GroupBy(payment => new { Year = payment.ModificationDate.Year, Month = payment.ModificationDate.Month })
                .Select(group => (double)group.Sum(payment => payment.TotalAmount)) 
                .OrderBy(totalAmount => totalAmount)
                .ToList();

            return monthlyTotalAmounts;
        }

        public async Task<List<Payments>> GetAllPaymentsAsync()
        {
            try
            {
                return (await paymentServices.GetAllAsync()).Where(item => item.IsActive == true && item.Company == Config.CompanyId).ToList();
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
                payment.Company = Config.CompanyId;
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
                var purchaseOrders = (await purchaseOrdersServices.GetAllAsync()).Where(item => item.IsActive == true && item.Company == Config.CompanyId).ToList();

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

        #endregion
    }
}
