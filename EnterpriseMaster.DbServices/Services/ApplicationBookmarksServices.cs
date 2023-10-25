using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class ApplicationBookmarksServices :
        BaseServices<ApplicationBookmarks>,
        IApplicationBookmarksServices
    {
        public ApplicationBookmarksServices()
            : base("/api/v1.0/ApplicationBookmarks/")
        {
        }
    }
}
