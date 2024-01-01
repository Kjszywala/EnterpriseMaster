using EnterpriseMaster.DbServices.Models.Database;
using EnterpriseMaster.DbServices.Services;

namespace EnterpriseMaster.UnitTests.DbServicesUnitTests
{
    public class RolesUnitTests
    {
        RolesService services = new RolesService();
        UserRolesService userRolesService = new UserRolesService();

        [Test]
        public async Task CreateNewRoles_TestAsync()
        {
            List<Roles> quantityTypes = new List<Roles>
            {
                new Roles()
                {
                    CreationDate = DateTime.Now,
                    Description = "Manages the creation and processing of purchase orders.",
                    IsActive = true,
                    ModificationDate = DateTime.Now,
                    Name = "PurchaseOrders",
                    Role = 1
                },
                new Roles()
                {
                    CreationDate = DateTime.Now,
                    Description = "Handles financial transactions and budgeting activities.",
                    IsActive = true,
                    ModificationDate = DateTime.Now,
                    Name = "Finance",
                    Role = 2
                },
                new Roles()
                {
                    CreationDate = DateTime.Now,
                    Description = "Responsible for creating and managing various offers and promotions.",
                    IsActive = true,
                    ModificationDate = DateTime.Now,
                    Name = "CreateOffers",
                    Role = 3
                },
                new Roles()
                {
                    CreationDate = DateTime.Now,
                    Description = "Manages the tracking and control of inventory.",
                    IsActive = true,
                    ModificationDate = DateTime.Now,
                    Name = "Inventory",
                    Role = 4
                },
                new Roles()
                {
                    CreationDate = DateTime.Now,
                    Description = "Handles the processing and management of invoices.",
                    IsActive = true,
                    ModificationDate = DateTime.Now,
                    Name = "Invoices",
                    Role = 5
                },
                new Roles()
                {
                    CreationDate = DateTime.Now,
                    Description = "Manages the creation and processing of sales orders.",
                    IsActive = true,
                    ModificationDate = DateTime.Now,
                    Name = "SalesOrders",
                    Role = 6
                },
                new Roles()
                {
                    CreationDate = DateTime.Now,
                    Description = "Analyzes and interprets data to provide insights for decision-making.",
                    IsActive = true,
                    ModificationDate = DateTime.Now,
                    Name = "Analytics",
                    Role = 7
                },
                new Roles()
                {
                    CreationDate = DateTime.Now,
                    Description = "Handles human resources-related functions and employee management.",
                    IsActive = true,
                    ModificationDate = DateTime.Now,
                    Name = "HumanResources",
                    Role = 8
                },
                new Roles()
                {
                    CreationDate = DateTime.Now,
                    Description = "Oversees the production processes and manufacturing activities.",
                    IsActive = true,
                    ModificationDate = DateTime.Now,
                    Name = "Production",
                    Role = 9
                },
                new Roles()
                {
                    CreationDate = DateTime.Now,
                    Description = "Manages financial accounting and related activities.",
                    IsActive = true,
                    ModificationDate = DateTime.Now,
                    Name = "Accounting",
                    Role = 10
                },
                new Roles()
                {
                    CreationDate = DateTime.Now,
                    Description = "Manages and stores customer-related data and interactions.",
                    IsActive = true,
                    ModificationDate = DateTime.Now,
                    Name = "CustomerData",
                    Role = 11
                },
                new Roles()
                {
                    CreationDate = DateTime.Now,
                    Description = "Tracks and analyzes various sales-related activities and performance.",
                    IsActive = true,
                    ModificationDate = DateTime.Now,
                    Name = "SalesActivities",
                    Role = 12
                },
            };

            foreach (var item in quantityTypes)
            {
                var result = await services.AddAsync(item);
                Assert.True(result);
            }
        }

        [Test]
        public async Task CreateCurrentUserRoles_TestAsync()
        {
            var roles = await services.GetAllAsync();
            foreach (var item in roles)
            {
                var result = await userRolesService.AddAsync(new UserRoles()
                {
                    CreationDate = DateTime.Now,
                    IsActive = true,
                    ModificationDate = DateTime.Now,
                    RoleId = item.Id,
                    UserId = 4,
                    UserRole = false,
                });
                Assert.True(result);
            }
        }
    }
}
