
using EnterpriseMaster.DbServices.Services;

namespace EnterpriseMaster.UnitTests.DbServicesUnitTests
{
    public class TaskStatusUnitTests
    {
        TasksStatusesService taskStatusService = new TasksStatusesService();



        [Test]
        public async Task CreateMultipleTasksStatuses_TestAsync()
        {
            var taskStatuses = new List<DbServices.Models.Database.TaskStatus>
            {
                new DbServices.Models.Database.TaskStatus
                {
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now,
                    IsActive = true,
                    Notes = "Status 1 notes",
                    Title = "Status 1",
                    Status = "Open"
                },
                new DbServices.Models.Database.TaskStatus
                {
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now,
                    IsActive = true,
                    Notes = "Status 2 notes",
                    Title = "Status 2",
                    Status = "In Progress"
                },
                new DbServices.Models.Database.TaskStatus
                {
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now,
                    IsActive = true,
                    Notes = "Status 3 notes",
                    Title = "Status 3",
                    Status = "Completed"
                }
            };

            // Add more task statuses as needed
            foreach (var taskStatus in taskStatuses)
            {
                await taskStatusService.AddAsync(taskStatus);
            }
        }
    }
}
