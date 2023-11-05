using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class TasksServices :
        BaseServices<Tasks>,
        ITasksServices
    {
        public TasksServices() 
            : base("/api/v1.0/Tasks/")
        {
        }
    }
}
