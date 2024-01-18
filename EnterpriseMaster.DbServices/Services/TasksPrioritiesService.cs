using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class TasksPrioritiesService :
        BaseServices<TasksPriorities>,
        ITasksPrioritiesService
    {
        public TasksPrioritiesService()
            : base("/api/v1.0/TasksPriorities/")
        {
        }
    }
}
