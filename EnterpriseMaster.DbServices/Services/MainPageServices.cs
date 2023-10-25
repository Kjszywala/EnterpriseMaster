using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class MainPageServices :
        BaseServices<MainPages>,
        IMainPageServices
    {
        public MainPageServices()
            : base("/api/v1.0/MainPages")
        {
        }
    }
}
