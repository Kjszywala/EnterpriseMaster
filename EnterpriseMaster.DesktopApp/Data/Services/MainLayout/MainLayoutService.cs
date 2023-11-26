using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;
using EnterpriseMaster.DesktopApp.Data.Models;

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

        public async Task<MainPageViewModel> GetMainPagesModel()
        {
            try
            {
                var mainModel = (await mainPageServices.GetAllAsync()).FirstOrDefault();

                var model = new MainPageViewModel
                {
                    Analytics = mainModel.Analytics,
                    BasicPlan = mainModel.BasicPlan,
                    EnterprisePlan = mainModel.EnterprisePlan,
                    Logo = mainModel.Logo,
                    MainImage = mainModel.MainImage,
                    ProPlan = mainModel.ProPlan,
                    Sales = mainModel.Sales,
                    Warehouse = mainModel.Warehouse
                };

                if(Config.UserImage != null)
                {
                    model.UserImage = Config.UserImage;
                }
                else
                {
                    model.UserImage = model.BasicPlan;
                }

                return model;
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
