using EnterpriseMaster.DbServices.Models.Database;
using EnterpriseMaster.DbServices.Services;

namespace EnterpriseMaster.UnitTests.DbServicesUnitTests
{
    [TestFixture]
    public class ApplicationFeaturesUnitTests
    {
        ApplicationFeaturesServices applicationFeaturesServices = new ApplicationFeaturesServices();
        SubscriptionTypesServices subscriptionTypesServices = new SubscriptionTypesServices();
        BasicPlanServices basicPlanServices = new BasicPlanServices();
        ProfessionalPlanServices professionalPlanServices = new ProfessionalPlanServices();
        EnterprisePlanServices enterprisePlanServices = new EnterprisePlanServices();

        //Basic plan

        [Test]
        public void CreateNewRowForApplicationFeaturesSales_Test()
        {
            var applicationFeaturesModel = new ApplicationFeatures()
            {
                SubscriptionTypeId = 1,
                FeatureName = "Basic Sales",
                Description = "Seamlessly track orders and generate professional invoices.",
                Image = basicPlanServices.GetAllAsync().Result.FirstOrDefault().BasicSales,
                CreationDate = DateTime.Now,
                IsActive = true,
                Title = "Basic Sales",
                ModificationDate = DateTime.Now
            };

            var result = applicationFeaturesServices.AddAsync(applicationFeaturesModel).Result;

            Assert.True(result);
        }

        [Test]
        public void CreateNewRowForApplicationFeaturesInventory_Test()
        {
            var applicationFeaturesModel = new ApplicationFeatures()
            {
                SubscriptionTypeId = 1,
                FeatureName = "Basic Inventory",
                Description = "Manage your inventory and stock levels with our Inventory module.",
                Image = basicPlanServices.GetAllAsync().Result.FirstOrDefault().BasicInventory,
                CreationDate = DateTime.Now,
                IsActive = true,
                Title = "Basic Inventory",
                ModificationDate = DateTime.Now
            };

            var result = applicationFeaturesServices.AddAsync(applicationFeaturesModel).Result;

            Assert.True(result);
        }

        [Test]
        public void CreateNewRowForApplicationFeaturesFinancialManagement_Test()
        {
            var applicationFeaturesModel = new ApplicationFeatures()
            {
                SubscriptionTypeId = 1,
                FeatureName = "Basic Financial Management",
                Description = "Basic Financial Management module.",
                Image = basicPlanServices.GetAllAsync().Result.FirstOrDefault().BasicFinancialManagement,
                CreationDate = DateTime.Now,
                IsActive = true,
                Title = "Basic Financial Management",
                ModificationDate = DateTime.Now
            };

            var result = applicationFeaturesServices.AddAsync(applicationFeaturesModel).Result;

            Assert.True(result);
        }

        [Test]
        public void CreateNewRowForApplicationFeaturesCreateOffers_Test()
        {
            var applicationFeaturesModel = new ApplicationFeatures()
            {
                SubscriptionTypeId = 1,
                FeatureName = "Create Offers",
                Description = "Create compelling offers and promotions to attract customers and boost sales.",
                Image = basicPlanServices.GetAllAsync().Result.FirstOrDefault().CreateOffers,
                CreationDate = DateTime.Now,
                IsActive = true,
                Title = "Create Offers",
                ModificationDate = DateTime.Now
            };

            var result = applicationFeaturesServices.AddAsync(applicationFeaturesModel).Result;

            Assert.True(result);
        }

        [Test]
        public void CreateNewRowForApplicationFeaturesManageOrders_Test()
        {
            var applicationFeaturesModel = new ApplicationFeatures()
            {
                SubscriptionTypeId = 1,
                FeatureName = "Manage Orders",
                Description = "Efficiently manage incoming orders, process them.",
                Image = basicPlanServices.GetAllAsync().Result.FirstOrDefault().ManageOrders,
                CreationDate = DateTime.Now,
                IsActive = true,
                Title = "Manage Orders",
                ModificationDate = DateTime.Now
            };

            var result = applicationFeaturesServices.AddAsync(applicationFeaturesModel).Result;

            Assert.True(result);
        } 
        
        [Test]
        public void CreateNewRowForApplicationFeaturesManageOrdersGenerateInvoices_Test()
        {
            var applicationFeaturesModel = new ApplicationFeatures()
            {
                SubscriptionTypeId = 1,
                FeatureName = "Generate Invoices",
                Description = "Create professional invoices, send them to your customers.",
                Image = basicPlanServices.GetAllAsync().Result.FirstOrDefault().GenerateInvoices,
                CreationDate = DateTime.Now,
                IsActive = true,
                Title = "Generate Invoices",
                ModificationDate = DateTime.Now
            };

            var result = applicationFeaturesServices.AddAsync(applicationFeaturesModel).Result;

            Assert.True(result);
        }

        // Professional plan
        [Test]
        public void CreateNewRowForApplicationFeaturesProPlan_Test()
        {
            var applicationFeaturesModel = new ApplicationFeatures()
            {
                SubscriptionTypeId = 3,
                FeatureName = "Professional Plan",
                Description = "Get access to all the features from the Basic Plan.",
                Image = professionalPlanServices.GetAllAsync().Result.FirstOrDefault().ProfessionalPlan,
                CreationDate = DateTime.Now,
                IsActive = true,
                Title = "Professional Plan",
                ModificationDate = DateTime.Now
            };

            var result = applicationFeaturesServices.AddAsync(applicationFeaturesModel).Result;

            Assert.True(result);
        }

        [Test]
        public void CreateNewRowForApplicationFeaturesManageCustomerData_Test()
        {
            var applicationFeaturesModel = new ApplicationFeatures()
            {
                SubscriptionTypeId = 3,
                FeatureName = "Manage Customer Data",
                Description = "Effortlessly manage customer data, inquiries, and complaints.",
                Image = professionalPlanServices.GetAllAsync().Result.FirstOrDefault().ManageCustomerData,
                CreationDate = DateTime.Now,
                IsActive = true,
                Title = "Manage Customer Data",
                ModificationDate = DateTime.Now
            };

            var result = applicationFeaturesServices.AddAsync(applicationFeaturesModel).Result;

            Assert.True(result);
        }

        [Test]
        public void CreateNewRowForApplicationFeaturesSalesActivities_Test()
        {
            var applicationFeaturesModel = new ApplicationFeatures()
            {
                SubscriptionTypeId = 3,
                FeatureName = "Plan Sales Activities",
                Description = "Boost sales and improve customer satisfaction through effective planning.",
                Image = professionalPlanServices.GetAllAsync().Result.FirstOrDefault().PlanSalesActivities,
                CreationDate = DateTime.Now,
                IsActive = true,
                Title = "Plan Sales Activities",
                ModificationDate = DateTime.Now
            };

            var result = applicationFeaturesServices.AddAsync(applicationFeaturesModel).Result;

            Assert.True(result);
        }

        [Test]
        public void CreateNewRowForApplicationFeaturesAdvancedAccounting_Test()
        {
            var applicationFeaturesModel = new ApplicationFeatures()
            {
                SubscriptionTypeId = 3,
                FeatureName = "Advanced Accounting",
                Description = "Take control of your finances with advanced accounting features.",
                Image = professionalPlanServices.GetAllAsync().Result.FirstOrDefault().AdvancedAccounting,
                CreationDate = DateTime.Now,
                IsActive = true,
                Title = "Advanced Accounting",
                ModificationDate = DateTime.Now
            };

            var result = applicationFeaturesServices.AddAsync(applicationFeaturesModel).Result;

            Assert.True(result);
        }

        // Enterprise plan
        [Test]
        public void CreateNewRowForApplicationFeaturesEnterprisePlan_Test()
        {
            var applicationFeaturesModel = new ApplicationFeatures()
            {
                SubscriptionTypeId = 2,
                FeatureName = "Enterprise Plan",
                Description = "Upgrade to the Enterprise Plan to unlock a world of possibilities.",
                Image = enterprisePlanServices.GetAllAsync().Result.FirstOrDefault().EnterprisePlanImage,
                CreationDate = DateTime.Now,
                IsActive = true,
                Title = "Enterprise Plan",
                ModificationDate = DateTime.Now
            };

            var result = applicationFeaturesServices.AddAsync(applicationFeaturesModel).Result;

            Assert.True(result);
        }

        [Test]
        public void CreateNewRowForApplicationFeaturesProductionManagement_Test()
        {
            var applicationFeaturesModel = new ApplicationFeatures()
            {
                SubscriptionTypeId = 2,
                FeatureName = "Production Management",
                Description = "Optimize production processes, plan, and monitor progress efficiently.",
                Image = enterprisePlanServices.GetAllAsync().Result.FirstOrDefault().ProductionManagement,
                CreationDate = DateTime.Now,
                IsActive = true,
                Title = "Production Management",
                ModificationDate = DateTime.Now
            };

            var result = applicationFeaturesServices.AddAsync(applicationFeaturesModel).Result;

            Assert.True(result);
        }

        [Test]
        public void CreateNewRowForApplicationFeaturesHumanResources_Test()
        {
            var applicationFeaturesModel = new ApplicationFeatures()
            {
                SubscriptionTypeId = 2,
                FeatureName = "Human Resources",
                Description = "Simplify HR processes and ensure the well-being of your workforce.",
                Image = enterprisePlanServices.GetAllAsync().Result.FirstOrDefault().HumanResources,
                CreationDate = DateTime.Now,
                IsActive = true,
                Title = "Human Resources",
                ModificationDate = DateTime.Now
            };

            var result = applicationFeaturesServices.AddAsync(applicationFeaturesModel).Result;

            Assert.True(result);
        }

        [Test]
        public void CreateNewRowForApplicationFeaturesAnalytics_Test()
        {
            var applicationFeaturesModel = new ApplicationFeatures()
            {
                SubscriptionTypeId = 2,
                FeatureName = "Analytics & Reporting",
                Description = "Our Analytics & Reporting tools provide insights into your business's performance and trends.",
                Image = enterprisePlanServices.GetAllAsync().Result.FirstOrDefault().AnalyticsReporting,
                CreationDate = DateTime.Now,
                IsActive = true,
                Title = "Analytics & Reporting",
                ModificationDate = DateTime.Now
            };

            var result = applicationFeaturesServices.AddAsync(applicationFeaturesModel).Result;

            Assert.True(result);
        }
    }
}
