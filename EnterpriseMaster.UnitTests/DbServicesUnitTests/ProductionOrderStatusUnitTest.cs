using EnterpriseMaster.DbServices.Models.Database;
using EnterpriseMaster.DbServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseMaster.UnitTests.DbServicesUnitTests
{
    public class ProductionOrderStatusUnitTest
    {
        ProductionOrderStatusService orderStatusService = new ProductionOrderStatusService();

        [Test]
        public async Task CreateMultipleOrderStatuses_TestAsync()
        {
            var orderStatuses = new List<ProductionOrderStatus>
            {
                new ProductionOrderStatus
                {
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now,
                    IsActive = true,
                    Notes = "Status 1 notes",
                    Title = "Open",
                    Status = "Open"
                },
                new ProductionOrderStatus
                {
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now,
                    IsActive = true,
                    Notes = "Status 2 notes",
                    Title = "Status 2",
                    Status = "In Progress"
                },
                new ProductionOrderStatus
                {
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now,
                    IsActive = true,
                    Notes = "Status 3 notes",
                    Title = "Status 3",
                    Status = "Completed"
                },
                new ProductionOrderStatus
                {
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now,
                    IsActive = true,
                    Notes = "Status 4 notes",
                    Title = "Status 4",
                    Status = "Rejected"
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
