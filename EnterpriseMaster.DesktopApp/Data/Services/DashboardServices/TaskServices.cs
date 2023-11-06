using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DesktopApp.Data.Services.DashboardServices
{
    public class TaskServices
    {
        #region Variables

        IErrorLogsServices errorLogsServices;
        ITasksServices tasksServices;

        #endregion

        #region Ctor

        public TaskServices(
            IErrorLogsServices _iErrorLogsServices, 
            ITasksServices _iTasksServices)
        {
            errorLogsServices = _iErrorLogsServices;
            tasksServices = _iTasksServices;
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

        public async Task<List<Tasks>> GetAllCompletedTasks()
        {
            try
            {
                return (await tasksServices.GetAllAsync())
                    .Where(item => item.IsActive == false)
                    .Where(item => item.IsCompleted == true)
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

        public async Task<bool> AddNewTask(Tasks task)
        {
            try
            {
                var response = await tasksServices.AddAsync(task);
                if (response)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> RemoveTask(int id)
        {
            try
            {
                var response = await tasksServices.RemoveAsync(id);
                if(response)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> CompleteTask(int id)
        {
            try
            {
                var task = await tasksServices.GetAsync(id);
                task.IsCompleted = true;
                task.IsActive = false;
                var response = await tasksServices.EditAsync(id, task);
                if (response)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> ReverseTask(int id)
        {
            try
            {
                var task = await tasksServices.GetAsync(id);
                task.IsCompleted = false;
                task.IsActive = true;
                var response = await tasksServices.EditAsync(id, task);
                if (response)
                {
                    return true;
                }
                return false;
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
