using EnterpriseMaster.DbServices.Interfaces;

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
            IMainPageServices mainPageServices,
            IErrorLogsServices errorLogsServices)
        {
            this.mainPageServices = mainPageServices;
            this.errorLogsServices = errorLogsServices;
        }

        #endregion

        #region Methods



        #endregion
    }
}
