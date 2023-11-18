using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;
using EnterpriseMaster.DbServices.Services;

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

        #endregion

        #region Constructor

        public SalesService(
            IErrorLogsServices _errorLogsServices, 
            IRefudsServices _refudsServices, 
            IReturnServices _returnServices, 
            IReturnStatusService _returnStatus, 
            ISalesOrdersServices _salesOrdersServices)
        {
            errorLogsServices = _errorLogsServices;
            refudsServices = _refudsServices;
            returnServices = _returnServices;
            returnStatus = _returnStatus;
            salesOrdersServices = _salesOrdersServices;
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

        #endregion
    }
}
