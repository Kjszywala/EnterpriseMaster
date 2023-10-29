using EnterpriseMaster.DbServices.Models.Database;
using EnterpriseMaster.DbServices.Services;

namespace EnterpriseMaster.UnitTests.DbServicesUnitTests
{
    [TestFixture]
    public class SubscriptionTypesUnitTests
    {
        SubscriptionTypesServices subscriptionTypesServices = new SubscriptionTypesServices();
        MainPageServices mainPageServices = new MainPageServices();

        [Test]
        public void CreateNewRowForSubscriptionTypesBasic_Test()
        {
            var subscriptionImage = mainPageServices.GetAllAsync().Result.FirstOrDefault();

            var subscriptionTypesModel = new SubscriptionTypes()
            {
                SubscriptionName = "Basic Plan",
                Price = 99.00m,
                Description = "Ideal for startups and small companies. Create offers, manage orders, track inventory, and generate invoices.",
                Image = subscriptionImage.BasicPlan,
                CreationDate = DateTime.Now,
                IsActive = true,
                Title = "Basic Plan",
                ModificationDate = DateTime.Now
            };

            var result = subscriptionTypesServices.AddAsync(subscriptionTypesModel).Result;

            Assert.True(result);
        }

        [Test]
        public void CreateNewRowForSubscriptionTypesProfessional_Test()
        {
            var subscriptionImage = mainPageServices.GetAllAsync().Result.FirstOrDefault();

            var subscriptionTypesModel = new SubscriptionTypes()
            {
                SubscriptionName = "Pro Plan",
                Price = 199.00m,
                Description = "Upgrade your business with the Professional Plan. Take it to the next level with advanced features.",
                Image = subscriptionImage.ProPlan,
                CreationDate = DateTime.Now,
                IsActive = true,
                Title = "Pro Plan",
                ModificationDate = DateTime.Now
            };

            var result = subscriptionTypesServices.AddAsync(subscriptionTypesModel).Result;

            Assert.True(result);
        }

        [Test]
        public void CreateNewRowForSubscriptionTypesEnterprise_Test()
        {
            var subscriptionImage = mainPageServices.GetAllAsync().Result.FirstOrDefault();

            var subscriptionTypesModel = new SubscriptionTypes()
            {
                SubscriptionName = "Enterprise Plan",
                Price = 399.00m,
                Description = "Ideal for large enterprises. Elevate your enterprise with additional advanced features.",
                Image = subscriptionImage.EnterprisePlan,
                CreationDate = DateTime.Now,
                IsActive = true,
                Title = "Enterprise Plan",
                ModificationDate = DateTime.Now
            };

            var result = subscriptionTypesServices.AddAsync(subscriptionTypesModel).Result;

            Assert.True(result);
        }
    }
}
