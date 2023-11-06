using EnterpriseMaster.DbServices.Interfaces;

namespace EnterpriseMaster.DbServices.Services
{
    internal class TaskStatusService :
        BaseServices<Models.Database.TaskStatus>,
        ITaskStatusService
    {
        public TaskStatusService() 
            : base("/api/v1.0/TaskStatus/")
        {
        }
    }
}
