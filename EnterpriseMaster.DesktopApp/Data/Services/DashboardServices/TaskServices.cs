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
        ITasksStatusesService tasksStatusesServices;
        IUsersServices usersServices;

        #endregion

        #region Ctor

        public TaskServices(
            IErrorLogsServices _iErrorLogsServices,
            ITasksServices _iTasksServices,
            IEmployeesServices _employeesServices,
            ITasksStatusesService _tasksStatusesServices,
            IUsersServices _usersServices)
        {
            errorLogsServices = _iErrorLogsServices;
            tasksServices = _iTasksServices;
            employeesServices = _employeesServices;
            tasksStatusesServices = _tasksStatusesServices;
            usersServices = _usersServices;
        }

        #endregion

        #region Methods

        public async Task<List<Tasks>> GetAllActiveTasks()
        {
            try
            {
                var currentEmployee = (await employeesServices.GetAllAsync())
                    .Where(item => item.UserId == Config.UserId)
                    .OrderBy(item => item.ModificationDate)
                    .FirstOrDefault();

                return (await tasksServices.GetAllAsync())
                    .Where(item => item.TaskStatusId == 1)
                    .Where(item3 => item3.EmployeeId == currentEmployee.Id)
                    .ToList();
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<List<Tasks>> GetAllTasks()
        {
            try
            {
                return (await tasksServices.GetAllAsync())
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
                var currentEmployee = (await employeesServices.GetAllAsync()).Where(item => item.UserId == Config.UserId).FirstOrDefault();
                return (await tasksServices.GetAllAsync())
                    .Where(item => item.TaskStatusId == 3)
                    .Where(item3 => item3.EmployeeId == currentEmployee.Id)
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
                var currentEmployee = (await employeesServices.GetAllAsync()).Where(item => item.UserId == Config.UserId).FirstOrDefault();
                return (await tasksServices.GetAllAsync())
                    .Where(item => item.TaskStatusId == 3)
                    .Where(item2 => item2.ModificationDate >= DateTime.Now.AddDays(-5))
                    .Where(item3 => item3.EmployeeId == currentEmployee.Id)
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

        public async Task<List<Tasks>> GetAllInProgressTasks()
        {
            try
            {
                var currentEmployee = (await employeesServices.GetAllAsync()).Where(item => item.UserId == Config.UserId).FirstOrDefault();
                return (await tasksServices.GetAllAsync())
                    .Where(item => item.TaskStatusId == 2)
                    .Where(item3 => item3.EmployeeId == currentEmployee.Id)
                    .ToList();
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<bool> UpdateTask(Tasks task)
        {
            try
            {
                var response = await tasksServices.EditAsync(task.Id, task);
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

        public async Task<bool> CompleteTask(int id)
        {
            try
            {
                var task = await tasksServices.GetAsync(id);
                task.IsCompleted = true;
                task.IsActive = false;
                task.TaskStatusId = 3;
                task.ModificationDate = DateTime.Now;
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
                task.TaskStatusId = 1;
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

        public async Task<Tasks> GetTaskAsync(int id)
        {
            try
            {
                return await tasksServices.GetAsync(id);
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<List<Employees>> GetAllEmployeesForCurrentCompany()
        {
            try
            {
                var users = (await usersServices.GetAllAsync());
                var employees = (await employeesServices.GetAllAsync()).Where(item => item.CompanyId == Config.CompanyId).ToList();
                foreach (var employee in employees)
                {
                    foreach (var user in users)
                    {
                        if (employee.UserId == user.Id)
                        {
                            employee.User = user;
                        }
                    }
                }
                return employees;
            }
            catch (Exception e)
            {
                await errorLogsServices.AddAsync(new ErrorLogs() { Date = DateTime.Now, Message = e.Message, Exception = e.StackTrace });
                throw new Exception(e.Message, e);
            }
        }

        public async Task<List<DbServices.Models.Database.TaskStatus>> GetAllTaskStatuses()
        {
            try
            {
                var statuses = (await tasksStatusesServices.GetAllAsync()).ToList();
                return statuses;
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
