using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class ReturnStatusService :
        BaseServices<ReturnsStatuses>,
        IReturnStatusService
    {
        public ReturnStatusService()
            : base("/api/v1.0/ReturnsStatuses/")
        {
        }
    }
}
