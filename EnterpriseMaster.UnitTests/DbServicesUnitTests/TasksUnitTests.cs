using EnterpriseMaster.DbServices.Models.Database;
using EnterpriseMaster.DbServices.Services;
using NUnit.Framework.Internal;

namespace EnterpriseMaster.UnitTests.DbServicesUnitTests
{
    public class TasksUnitTests
    {
        TasksServices tasksServices = new TasksServices();
        UsersServices usersServices = new UsersServices();

        [Test]
        public async Task CreateMultipleTasks_TestAsync()
        {
            for (int i = 1; i <= 10; i++)
            {
                var task = new Tasks()
                {
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now,
                    IsActive = true,
                    Notes = $"Task {i} notes",
                    Title = $"Task {i} title",
                    Task = $"Task {i}",
                    Description = $"Task {i} description",
                    IsRemoved = false,
                    IsCompleted = false,
                    CompleteBy = DateTime.Now.AddDays(7), // Set the due date

                    // Populate with realistic data
                   // EmployeeId = GetEmployeeIdForTask(), // Replace with logic to retrieve an EmployeeId
                    //TaskStatusId = GetTaskStatusIdForTask(), // Replace with logic to retrieve a TaskStatusId
                };

                var result = await tasksServices.AddAsync(task);

                Assert.True(result);
            }
            
        }
    }
}
