using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;
using EnterpriseMaster.DbServices.Services;

namespace EnterpriseMaster.UnitTests.DbServicesUnitTests
{
    public class FeedbackUnitTests
    {
        CustomerFeedbacksService customerFeedbacksService = new CustomerFeedbacksService();
        CustomerInformationsServices customerInformationsServices = new CustomerInformationsServices();

        [Test]
        public async Task CreateRows_TestAsync()
        {
            var customer = (await customerInformationsServices.GetAllAsync()).FirstOrDefault();

            var list = new List<CustomerFeedbacks>()
            {
                new CustomerFeedbacks()
                {
                    CreationDate = DateTime.Now,
                    CustomerId = customer.Id,
                    FeedbackText = "Excellent service! I'm very satisfied.",
                    IsActive = true,
                    ModificationDate = DateTime.Now,
                    Rating = 9,
                },
                new CustomerFeedbacks()
                {
                    CreationDate = DateTime.Now,
                    FeedbackText = "Average experience. Room for improvement.",
                    IsActive = true,
                    ModificationDate = DateTime.Now,
                    Rating = 5,
                },
                new CustomerFeedbacks()
                {
                    CreationDate = DateTime.Now,
                    FeedbackText = "Outstanding! Couldn't be happier with the service.",
                    IsActive = true,
                    ModificationDate = DateTime.Now,
                    Rating = 10,
                },
                new CustomerFeedbacks()
                {
                    CreationDate = DateTime.Now,
                    CustomerId = customer.Id,
                    FeedbackText = "Great customer service and prompt delivery. Highly recommended!",
                    IsActive = true,
                    ModificationDate = DateTime.Now,
                    Rating = 8,
                },
                new CustomerFeedbacks()
                {
                    CreationDate = DateTime.Now,
                    FeedbackText = "Satisfied with the product quality. Will shop again.",
                    IsActive = true,
                    ModificationDate = DateTime.Now,
                    Rating = 7,
                },
                new CustomerFeedbacks()
                {
                    CreationDate = DateTime.Now,
                    FeedbackText = "Needs improvement in delivery time. Product quality is good.",
                    IsActive = true,
                    ModificationDate = DateTime.Now,
                    Rating = 4,
                },
                new CustomerFeedbacks()
                {
                    CreationDate = DateTime.Now,
                    FeedbackText = "Excellent communication and support. Very responsive team.",
                    IsActive = true,
                    ModificationDate = DateTime.Now,
                    Rating = 9,
                },
                new CustomerFeedbacks()
                {
                    CreationDate = DateTime.Now,
                    FeedbackText = "The service was below my expectations. Dissatisfied with the experience.",
                    IsActive = true,
                    ModificationDate = DateTime.Now,
                    Rating = 2,
                },
            };
            foreach (var row in list)
            {
                Assert.IsTrue(await customerFeedbacksService.AddAsync(row));
            }

        }
    }
}
