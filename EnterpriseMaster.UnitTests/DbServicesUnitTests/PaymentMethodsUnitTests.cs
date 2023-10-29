using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;
using EnterpriseMaster.DbServices.Services;

namespace EnterpriseMaster.UnitTests.DbServicesUnitTests
{
    [TestFixture]
    public class PaymentMethodsUnitTests
    {
        PaymentMethodsServices paymentMethodsServices = new PaymentMethodsServices();

        [Test]
        public void CreateNewRowForPaymentMethods_Test()
        {
            var mainImage = File.ReadAllBytes("C:\\Users\\kamil\\Desktop\\visa_logo (1).png");

            var paymentMethodsModel = new PaymentMethods()
            {
                Image = mainImage,
                CreationDate = DateTime.Now,
                IsActive = true,
                Title = "Visa",
                ModificationDate = DateTime.Now,
                PaymentType = "Visa"
            };

            var result = paymentMethodsServices.AddAsync(paymentMethodsModel).Result;

            Assert.True(result);
        }

        [Test]
        public void RemoveFromPaymentMethods_Test()
        {
            var list = paymentMethodsServices.GetAllAsync().Result.FirstOrDefault();
            var result = paymentMethodsServices.RemoveAsync(list.Id).Result;

            Assert.True(result);
        }
    }
}
