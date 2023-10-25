using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class ErrorLogsServices :
        BaseServices<ErrorLogs>,
        IErrorLogsServices
    {
        public ErrorLogsServices()
            : base("/api/v1.0/ErrorLogs/")
        {
        }
    }
}
