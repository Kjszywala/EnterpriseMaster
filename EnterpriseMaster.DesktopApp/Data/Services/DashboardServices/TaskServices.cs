using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DesktopApp.Data.Services.DashboardServices
{
    public class TaskServices
    {
        #region Variables

        IErrorLogsServices errorLogsServices;
        ITasksServices tasksServices;
        IEmployeesServices employeesServices;

        #endregion

        #region Ctor

        public TaskServices(
            IErrorLogsServices _iErrorLogsServices, 
            ITasksServices _iTasksServices, 
            IEmployeesServices _iEmployeesServices)
        {
            errorLogsServices = _iErrorLogsServices;
            tasksServices = _iTasksServices;
            employeesServices = _iEmployeesServices;
        }

        #endregion

        #region Methods

        public async Task<List<Tasks>> GetAllActiveTasks()
        {
            try
            {
                return (await tasksServices.GetAllAsync())
                    .Where(item => item.IsActive == true)
                    .Where(item3 => item3.EmployeeId == Config.UserId)
                    .ToList();
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<List<Tasks>> GetAllNotActiveTasks()
        {
            try
            {
                return (await tasksServices.GetAllAsync())
                    .Where(item => item.IsActive == false)
                    .Where(item3 => item3.EmployeeId == Config.UserId)
                    .ToList();
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<List<Tasks>> GetAllDoneTasksFromFiveDays()
        {
            try
            {
                return (await tasksServices.GetAllAsync())
                    .Where(item => item.IsActive == false)
                    .Where(item2 => item2.ModificationDate >= DateTime.Now.AddDays(-5))
                    .Where(item3 =>item3.EmployeeId == Config.UserId)
                    .ToList();
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        #endregion
    }
}
