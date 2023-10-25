using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class EmployeesServices :
        BaseServices<Employees>,
        IEmployeesServices
    {
        public EmployeesServices()
            : base("/api/v1.0/Employees/")
        {
        }
    }
}
