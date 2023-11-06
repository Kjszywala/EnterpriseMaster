using EnterpriseMaster.DbServices.Interfaces;

namespace EnterpriseMaster.DbServices.Services
{
    public class TaskStatusService :
        BaseServices<Models.Database.TaskStatus>,
        Interfaces.TaskStatusService
    {
        public TaskStatusService() 
            : base("/api/v1.0/TaskStatus/")
        {
        }
    }
}
