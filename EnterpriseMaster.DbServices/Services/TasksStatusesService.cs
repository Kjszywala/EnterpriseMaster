using EnterpriseMaster.DbServices.Interfaces;

namespace EnterpriseMaster.DbServices.Services
{
    public class TasksStatusesService :
        BaseServices<Models.Database.TaskStatus>,
        ITasksStatusesService

    {
        public TasksStatusesService() 
            : base("/api/v1.0/TaskStatus/")
        {
        }
    }
}
