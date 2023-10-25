using EnterpriseMaster.DbServices.Models.Database;
using EnterpriseMaster.DbServices.Services;

namespace EnterpriseMaster.UnitTests.DbServicesUnitTests
{
    [TestFixture]
    public class PagesUnitTests
    {

        MainPageServices mainPageServices = new MainPageServices();


        [Test]
        public void CreateNewRowsForMainPages_Test()
        {
            var mainImage = File.ReadAllBytes("C:\\Users\\kamil\\Desktop\\New folder\\mainimage.jpg");
            var analytics = File.ReadAllBytes("C:\\Users\\kamil\\Desktop\\New folder\\analytics.png");
            var sales = File.ReadAllBytes("C:\\Users\\kamil\\Desktop\\New folder\\salesmanagement.png");
            var warehouse = File.ReadAllBytes("C:\\Users\\kamil\\Desktop\\New folder\\inventorymanagement.png");
            var basicPlan = File.ReadAllBytes("C:\\Users\\kamil\\Desktop\\New folder\\Built-in-Artificial-Icon.png");
            var proPlan = File.ReadAllBytes("C:\\Users\\kamil\\Desktop\\New folder\\Connect-Enterprise-Icon.png");
            var enterprisePlan = File.ReadAllBytes("C:\\Users\\kamil\\Desktop\\New folder\\Human-First-Icon.png");
            var logo = File.ReadAllBytes("C:\\Users\\kamil\\Desktop\\New folder\\EnterpriseMaster.png");

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
            var result = mainPageServices.RemoveAsync(2).Result;

            Assert.True(result);
        }
    }
}
