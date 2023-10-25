using EnterpriseMaster.DbServices.Models.Database;
using EnterpriseMaster.DbServices.Services;

namespace EnterpriseMaster.UnitTests.DbServicesUnitTests
{
    [TestFixture]
    public class PagesUnitTests
    {

        MainPageServices mainPageServices = new MainPageServices();
        BasicPlanServices basicPlanPage = new BasicPlanServices();
        ProfessionalPlanServices professionalPlanServices = new ProfessionalPlanServices();
        EnterprisePlanServices enterprisePlanServices = new EnterprisePlanServices();
        AboutPageServices aboutPageServices = new AboutPageServices();

        [Test]
        public void CreateNewRowsForMainPages_Test()
        {
            var mainImage = File.ReadAllBytes("C:\\Users\\kamil\\Desktop\\content\\mainimage.jpg");
            var analytics = File.ReadAllBytes("C:\\Users\\kamil\\Desktop\\content\\analytics.png");
            var sales = File.ReadAllBytes("C:\\Users\\kamil\\Desktop\\content\\salesmanagement.png");
            var warehouse = File.ReadAllBytes("C:\\Users\\kamil\\Desktop\\content\\inventorymanagement.png");
            var basicPlan = File.ReadAllBytes("C:\\Users\\kamil\\Desktop\\content\\subs\\Built-in-Artificial-Icon.png");
            var proPlan = File.ReadAllBytes("C:\\Users\\kamil\\Desktop\\content\\subs\\Connect-Enterprise-Icon.png");
            var enterprisePlan = File.ReadAllBytes("C:\\Users\\kamil\\Desktop\\content\\subs\\Human-First-Icon.png");
            var logo = File.ReadAllBytes("C:\\Users\\kamil\\Desktop\\content\\EnterpriseMaster.png");

            var mainPageModel = new MainPages()
            {
                Analytics = analytics,
                Sales = sales,
                Warehouse = warehouse,
                BasicPlan = basicPlan,
                ProPlan = proPlan,
                EnterprisePlan = enterprisePlan,
                CreationDate = DateTime.Now,
                IsActive = true,
                Logo = logo,
                MainImage = mainImage,
                ModificationDate = DateTime.Now,
                Title = "Home",
            };

            var result = mainPageServices.AddAsync(mainPageModel).Result;

            Assert.True(result);
        }

        [Test]
        public void RemoveFromMainPages_Test()
        {
            var list = mainPageServices.GetAllAsync().Result.FirstOrDefault();
            var result = mainPageServices.RemoveAsync(list.Id).Result;

            Assert.True(result);
        }

        [Test]
        public void CreateNewRowsForBasicSubsPage_Test()
        {
            var basicSales = File.ReadAllBytes("C:\\Users\\kamil\\Desktop\\content\\basic\\salesBasic.png");
            var basicInventory = File.ReadAllBytes("C:\\Users\\kamil\\Desktop\\content\\basic\\inventoryBasic.png");
            var financialManagement = File.ReadAllBytes("C:\\Users\\kamil\\Desktop\\content\\basic\\financialmanagement.png");
            var createOffers = File.ReadAllBytes("C:\\Users\\kamil\\Desktop\\content\\basic\\offers.png");
            var manageOrders = File.ReadAllBytes("C:\\Users\\kamil\\Desktop\\content\\basic\\orders.png");
            var genereateInvoices = File.ReadAllBytes("C:\\Users\\kamil\\Desktop\\content\\basic\\invoices.png");

            var basicSubModel = new BasicPlanPage()
            {
                BasicSales = basicSales,
                BasicInventory = basicInventory,
                BasicFinancialManagement = financialManagement,
                CreateOffers = createOffers,
                ManageOrders = manageOrders,
                GenerateInvoices = genereateInvoices,
                CreationDate = DateTime.Now,
                IsActive = true,
                ModificationDate = DateTime.Now,
                Title = "Basic Plan"
            };

            var result = basicPlanPage.AddAsync(basicSubModel).Result;

            Assert.True(result);
        }

        [Test]
        public void RemoveFromBasicSubsPage_Test()
        {
            var list = basicPlanPage.GetAllAsync().Result.FirstOrDefault();
            var result = basicPlanPage.RemoveAsync(list.Id).Result;

            Assert.True(result);
        }

        [Test]
        public void CreateNewRowsForProSubsPage_Test()
        {
            var basicSales = File.ReadAllBytes("C:\\Users\\kamil\\Desktop\\content\\professional\\financialmanagement.png");
            var accounting = File.ReadAllBytes("C:\\Users\\kamil\\Desktop\\content\\professional\\accounting.png");
            var data = File.ReadAllBytes("C:\\Users\\kamil\\Desktop\\content\\professional\\customerdata.png");
            var sales = File.ReadAllBytes("C:\\Users\\kamil\\Desktop\\content\\professional\\salesactivities.png");

            var proSubModel = new ProfessionalPlanPage()
            {
                AdvancedAccounting = accounting,
                ManageCustomerData = data,
                PlanSalesActivities = sales,
                ProfessionalPlan = basicSales,
                CreationDate = DateTime.Now,
                IsActive = true,
                ModificationDate = DateTime.Now,
                Title = "Professional Plan"
            };

            var result = professionalPlanServices.AddAsync(proSubModel).Result;

            Assert.True(result);
        }

        [Test]
        public void RemoveFromProSubsPage_Test()
        {
            var list = professionalPlanServices.GetAllAsync().Result.FirstOrDefault();
            var result = professionalPlanServices.RemoveAsync(list.Id).Result;

            Assert.True(result);
        }

        [Test]
        public void CreateNewRowsForEnterpriseSubsPage_Test()
        {
            var basicSales = File.ReadAllBytes("C:\\Users\\kamil\\Desktop\\content\\enterprise\\financialmanagement.png");
            var analytics = File.ReadAllBytes("C:\\Users\\kamil\\Desktop\\content\\enterprise\\analyticsreporting.png");
            var hr = File.ReadAllBytes("C:\\Users\\kamil\\Desktop\\content\\enterprise\\hr.png");
            var production = File.ReadAllBytes("C:\\Users\\kamil\\Desktop\\content\\enterprise\\productionmanagement.png");

            var enterpriseSubModel = new EnterprisePlan()
            {
                AnalyticsReporting = analytics,
                EnterprisePlanImage = basicSales,
                HumanResources = hr,
                ProductionManagement = production,
                CreationDate = DateTime.Now,
                IsActive = true,
                ModificationDate = DateTime.Now,
                Title = "Professional Plan"
            };

            var result = enterprisePlanServices.AddAsync(enterpriseSubModel).Result;

            Assert.True(result);
        }

        [Test]
        public void RemoveFromEnterpriseSubsPage_Test()
        {
            var list = enterprisePlanServices.GetAllAsync().Result.FirstOrDefault();
            var result = enterprisePlanServices.RemoveAsync(list.Id).Result;

            Assert.True(result);
        }

        [Test]
        public void CreateNewRowsForAboutPage_Test()
        {
            var one = File.ReadAllBytes("C:\\Users\\kamil\\Desktop\\content\\about\\1.jpg");
            var two = File.ReadAllBytes("C:\\Users\\kamil\\Desktop\\content\\about\\2.jpg");
            var three = File.ReadAllBytes("C:\\Users\\kamil\\Desktop\\content\\about\\hands.jpg");

            var aboutModel = new AboutPage()
            {
                AboutUs = three,
                OurMission = one,
                OurVision = two,
                CreationDate = DateTime.Now,
                IsActive = true,
                ModificationDate = DateTime.Now,
                Title = "Professional Plan"
            };

            var result = aboutPageServices.AddAsync(aboutModel).Result;

            Assert.True(result);
        }

        [Test]
        public void RemoveFromAboutPage_Test()
        {
            var list = aboutPageServices.GetAllAsync().Result.FirstOrDefault();
            var result = aboutPageServices.RemoveAsync(list.Id).Result;

            Assert.True(result);
        }
    }
}
