using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DesktopApp.Data.Services.DashboardServices
{
    public class WhatsNewInfoService
    {
        #region Variables

        private IErrorLogsServices errorLogsServices;
        private IWhatsNewsServices whatsNewsServices;

        #endregion

        #region Ctor

        public WhatsNewInfoService(
            IErrorLogsServices _errorLogsServices, 
            IWhatsNewsServices _whatsNewsServices)
        {
            errorLogsServices = _errorLogsServices;
            whatsNewsServices = _whatsNewsServices;
        }

        #endregion

        #region Methods

        public async Task<List<WhatsNew>> GetAllActiveNews()
        {
            try
            {
                return (await whatsNewsServices.GetAllAsync()).Where(item => item.IsActive == true).ToList();
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> AddNews(WhatsNew whatsNew)
        {
            try
            {
                var response = await whatsNewsServices.AddAsync(whatsNew);
                if (response)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<WhatsNew> GetNews(int id)
        {
            try
            {
                var response = await whatsNewsServices.GetAsync(id);

                return response;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        #endregion

    }
}
