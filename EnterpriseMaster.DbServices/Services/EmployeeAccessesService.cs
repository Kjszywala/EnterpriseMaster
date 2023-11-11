using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class EmployeeAccessesService :
        BaseServices<EmployeeAccesses>,
        IEmployeeAccessesServices
    {
        public EmployeeAccessesService() 
            : base("/api/v1.0/EmployeeAccesses/")
        {
        }
    }
}
