using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DesktopApp.Data.Services.MainLayout
{
    public class MainLayoutService
    {
        #region Variables

        private IMainPageServices mainPageServices;
        private IErrorLogsServices errorLogsServices;

        #endregion

        #region Ctor

        public MainLayoutService(
            IMainPageServices _mainPageServices,
            IErrorLogsServices _errorLogsServices)
        {
            mainPageServices = _mainPageServices;
            errorLogsServices = _errorLogsServices;
        }

        #endregion

        #region Methods

        public async Task<MainPages> GetMainPagesModel()
        {
            try
            {
                return (await mainPageServices.GetAllAsync()).FirstOrDefault();
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                return null;
            }
        }

        #endregion
    }
}
