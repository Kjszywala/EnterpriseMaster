using EnterpriseMaster.DbServices.Models.Database;
using EnterpriseMaster.DbServices.Services;

namespace EnterpriseMaster.UnitTests.DbServicesUnitTests
{
    public class PaymentStatusUnitTests
    {
        Payment orderStatusService = new OrderStatusesServices();

        [Test]
        public async Task CreateMultipleOrderStatuses_TestAsync()
        {
            var orderStatuses = new List<OrderStatuses>
            {
                new OrderStatuses
                {
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now,
                    IsActive = true,
                    Notes = "Status 1 notes",
                    Title = "Status 1",
                    Discription = "Open",
                    Status = 1
                },
                new OrderStatuses
                {
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now,
                    IsActive = true,
                    Notes = "Status 2 notes",
                    Title = "Status 2",
                    Discription = "In Progress",
                    Status = 2
                },
                new OrderStatuses
                {
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now,
                    IsActive = true,
                    Notes = "Status 3 notes",
                    Title = "Status 3",
                    Discription = "Completed",
                    Status = 3
                },
                new OrderStatuses
                {
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now,
                    IsActive = true,
                    Notes = "Status 4 notes",
                    Title = "Status 4",
                    Discription = "Shipped",
                    Status = 4
                },
                new OrderStatuses
                {
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now,
                    IsActive = true,
                    Notes = "Status 5 notes",
                    Title = "Status 5",
                    Discription = "On Hold",
                    Status = 5
                }
            };

            // Add more task statuses as needed
            foreach (var order in orderStatuses)
            {
                await orderStatusService.AddAsync(order);
            }
        }
    }
}
