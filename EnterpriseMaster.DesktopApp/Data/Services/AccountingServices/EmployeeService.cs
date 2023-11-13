using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DesktopApp.Data.Services.AccountingServices
{
    public class EmployeeService
    {
        #region Variables

        private readonly IEmployeesServices employeeService;
        private readonly IErrorLogsServices errorLogsService;
        private readonly IEmployeeAccessesServices employeeAccessesService;
        private readonly IUsersAdressesServices usersAdressesService;
        private readonly IEmployeeAddressesServices employeeAddressesServices;
        private readonly IUsersServices usersServices;
        private readonly ICompaniesServices companiesServices;
        private readonly ICompanyAddressServices companyAddressServices;
        private readonly ITasksServices taskServices;
        private readonly IOrdersServices ordersServices;

        #endregion

        #region Constructor

        public EmployeeService(
           IEmployeesServices _employeeService,
           IErrorLogsServices _errorLogsService,
           IEmployeeAccessesServices _employeeAccessesService,
           IUsersAdressesServices _usersAdressesService,
           IEmployeeAddressesServices _employeeAddressesServices,
           IUsersServices _usersServices,
           ICompaniesServices _companiesServices,
           ICompanyAddressServices _companyAddressServices,
           ITasksServices _taskServices,
           IOrdersServices _ordersServices)
        {
            employeeService = _employeeService;
            errorLogsService = _errorLogsService;
            employeeAccessesService = _employeeAccessesService;
            usersAdressesService = _usersAdressesService;
            employeeAddressesServices = _employeeAddressesServices;
            usersServices = _usersServices;
            companiesServices = _companiesServices;
            companyAddressServices = _companyAddressServices;
            taskServices = _taskServices;
            ordersServices = _ordersServices;
        }

        #endregion

        #region Methods

        public async Task<List<Employees>> GetEmployeesAsync()
        {
            try
            {
                var employeeAddresses = await employeeAddressesServices.GetAllAsync();
                var users = await usersServices.GetAllAsync();
                var employeeAccesList = await employeeAccessesService.GetAllAsync();
                var tasks = await taskServices.GetAllAsync();
                var company = (await companiesServices.GetAllAsync()).Where(item => item.Name == Config.Company).FirstOrDefault();

                if (company != null)
                {
                    company.CompanyAddress = await companyAddressServices.GetAsync(company.CompanyAddressId.Value);
                }

                var employees = (await employeeService.GetAllAsync()).Where(item => item.CompanyId == company.Id).ToList();

                foreach (var employee in employees)
                {
                    foreach (var employeeAddress in employeeAddresses)
                    {
                        if (employee.EmployeeAddressId == employeeAddress.Id)
                        {
                            employee.EmployeeAddress = employeeAddress;
                        }
                    }
                    foreach (var user in users)
                    {
                        if (employee.UserId == user.Id)
                        {
                            employee.User = user;
                        }
                    }
                    foreach (var employeeAcces in employeeAccesList)
                    {
                        if (employee.EmployeeAccessId == employeeAcces.Id)
                        {
                            employee.EmployeeAccess = employeeAcces;
                        }
                    }
                    employee.Tasks = (await taskServices.GetAllAsync()).Where(item => item.EmployeeId == employee.Id).ToList();
                    employee.Orders = (await ordersServices.GetAllAsync()).Where(item => item.EmployeeId == employee.Id).ToList();
                }

                return employees;
            }
            catch (Exception e)
            {
                await errorLogsService.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<Employees> GetEmployeebyId(int id)
        {
            return await employeeService.GetAsync(id);
        }

        public async Task<EmployeeAccesses> GetEmployeeAccessById(int id)
        {
            return await employeeAccessesService.GetAsync(id);
        }

        public async Task<EmployeeAddresses> GetEmployeeAddressById(int id)
        {
            return await employeeAddressesServices.GetAsync(id);
        }

        public async Task<bool> AddEmployeesAsync(Employees employee)
        {

            return await employeeService.AddAsync(employee);
        }

        public async Task<bool> RemoveEmployeeAsync(int id)
        {
            return await employeeService.RemoveAsync(id);
        }

        public async Task<bool> UpdateEmployeeAsync(Employees employee)
        {
            return await employeeService.EditAsync(employee.Id, employee);
        }

        public async Task<bool> UpdateEmployeeAddressAsync(EmployeeAddresses employeeAddresses)
        {
            return await employeeAddressesServices.EditAsync(employeeAddresses.Id, employeeAddresses);
        }
        
        public async Task<bool> UpdateUserAddressAsync(UsersAdresses userAddresses)
        {
            return await usersAdressesService.EditAsync(userAddresses.Id, userAddresses);
        }

        public async Task<bool> UpdateUserAsync(Users user)
        {
            return await usersServices.EditAsync(user.Id, user);
        }

        public async Task<List<EmployeeAccesses>> GetEmployeeAccessesAsync()
        {
            return await employeeAccessesService.GetAllAsync();
        }

        public async Task<bool> AddUserAsync(Users user)
        {

            return await usersServices.AddAsync(user);
        }

        public async Task<EmployeeAddresses> GetEmployeeAddressAsync(EmployeeAddresses employeeAddresses)
        {
            return (await employeeAddressesServices.GetAllAsync()).Where(item =>
               item.Street == employeeAddresses.Street &&
               item.HouseNumber == employeeAddresses.HouseNumber &&
               item.City == employeeAddresses.City &&
               item.PostCode == employeeAddresses.PostCode)
               .FirstOrDefault();
        }

        public async Task<bool> AddEmployeeAddressAsync(EmployeeAddresses employeeAddresses)
        {
            return await employeeAddressesServices.AddAsync(employeeAddresses);
        }

        public async Task<bool> AddUserAddressAsync(UsersAdresses userAddress)
        {
            return await usersAdressesService.AddAsync(userAddress);
        }

        public async Task<UsersAdresses> GetUserAddressAsync(UsersAdresses userAddress)
        {
            return (await usersAdressesService.GetAllAsync()).Where(item => 
                item.Street == userAddress.Street && 
                item.HouseNumber == userAddress.HouseNumber &&
                item.City == userAddress.City &&
                item.PostCode == userAddress.PostCode)
                .FirstOrDefault();
        }

        public async Task<List<Employees>> GetAllEmployeesBasedOnCompanyName()
        {
            return (await employeeService.GetAllAsync()).Where(item => item.CompanyId == Config.CompanyId).ToList();
        }

        public async Task<Companies> GetCompanyBasedOnName(string name)
        {
            return (await companiesServices.GetAllAsync()).Where(item => item.Name == name).FirstOrDefault();
        }

        public async Task<Users> GetUserBasedOnEmail(string email)
        {
            return (await usersServices.GetAllAsync()).Where(item => item.Email == email).FirstOrDefault();
        }

        #endregion
    }
}
