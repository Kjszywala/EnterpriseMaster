using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class AboutPageServices :
        BaseServices<AboutPage>,
        IAboutPageServices
    {
        public AboutPageServices()
            : base("/api/v1.0/AboutPages/")
        {
        }
    }
}
