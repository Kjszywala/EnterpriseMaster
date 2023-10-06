using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    internal class AppplicationBookmarksServices :
        BaseServices<ApplicationBookmarks>,
        IApplicationBookmarksServices
    {
        public AppplicationBookmarksServices()
            : base("/api/v1.0/ApplicationBookmarks")
        {
        }
    }
}
