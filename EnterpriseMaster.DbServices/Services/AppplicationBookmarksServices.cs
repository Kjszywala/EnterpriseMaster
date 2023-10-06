using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class AppplicationBookmarksServices :
        BaseServices<ApplicationBookmarks>,
        IApplicationBookmarksServices
    {
        public AppplicationBookmarksServices()
            : base("/api/v1.0/ApplicationBookmarks")
        {
        }
    }
}
