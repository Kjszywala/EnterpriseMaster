using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;
using EnterpriseMaster.DbServices.Services;

namespace EnterpriseMaster.DesktopApp.Data.Services.RolesServices
{
    public class RolesService
    {
        #region Variables

        private readonly IErrorLogsServices errorLogsServices;
        private readonly IUserRolesService userRolesService;
        private readonly IRolesService rolesService;

        #endregion

        #region Constructor

        public RolesService(IErrorLogsServices _errorLogsServices, IUserRolesService _userRolesService, IRolesService _rolesService)
        {
            errorLogsServices = _errorLogsServices;
            userRolesService = _userRolesService;
            rolesService = _rolesService;
        }

        #endregion

        #region Methods

        #region Roles

        public async Task<List<Roles>> GetAllRolesAsync()
        {
            try
            {
                return (await rolesService.GetAllAsync()).ToList();
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<Roles> GetRolesAsync(int id)
        {
            try
            {
                return (await rolesService.GetAsync(id));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> AddRolesAsync(Roles roles)
        {
            try
            {
                return (await rolesService.AddAsync(roles));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> UpdateRolesAsync(Roles roles)
        {
            try
            {
                return (await rolesService.EditAsync(roles.Id, roles));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> RemoveRolesAsync(int id)
        {
            try
            {
                return (await rolesService.RemoveAsync(id));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        #endregion

        #region UserRoles

        public async Task<List<UserRoles>> GetAllUserRolesAsync()
        {
            try
            {
                return (await userRolesService.GetAllAsync()).Where(item => item.Company == Config.CompanyId).ToList();
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<UserRoles> GetUserRolesAsync(int id)
        {
            try
            {
                return (await userRolesService.GetAsync(id));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> AddUserRolesAsync(UserRoles roles)
        {
            try
            {
                roles.Company = Config.CompanyId;
                return (await userRolesService.AddAsync(roles));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> UpdateUserRolesAsync(UserRoles roles)
        {
            try
            {
                return (await userRolesService.EditAsync(roles.Id, roles));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> RemoveUserRolesAsync(int id)
        {
            try
            {
                return (await rolesService.RemoveAsync(id));
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        #endregion

        #endregion
    }
}
