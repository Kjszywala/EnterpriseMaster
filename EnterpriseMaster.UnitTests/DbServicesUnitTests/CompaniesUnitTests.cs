using EnterpriseMaster.DbServices.Models.Database;
using EnterpriseMaster.DbServices.Services;

namespace EnterpriseMaster.UnitTests.DbServicesUnitTests
{
    public class CompaniesUnitTests
    {
        CompaniesServices companiesServices = new CompaniesServices();
        CompanyAddressServices companyAddressServices = new CompanyAddressServices();

        [Test]
        public async Task CreateRows_TestAsync()
        {
            var companyAddress = new CompanyAddress() 
            { 
                City = "Warsaw",
                Country = "Poland",
                CreationDate = DateTime.Now,
                HouseNumber = "2",
                IsActive = true,
                ModificationDate = DateTime.Now,
                PostCode = "28-160",
                Street = "Test Street",
            };

            Assert.IsTrue(await companyAddressServices.AddAsync(companyAddress));

            var fullCompanyAddress = (await companyAddressServices.GetAllAsync()).Where(item => 
                item.PostCode == companyAddress.PostCode && 
                item.City == companyAddress.City && 
                item.Street == companyAddress.Street)
                .FirstOrDefault();

            var company = new Companies()
            {
                FoundedDate = DateTime.Now.AddYears(-20),
                CreationDate = DateTime.Now,
                CompanyAddressId = fullCompanyAddress.Id,
                ContactEmail = "test@email.com",
                ContactPhone = "7775390152",
                Description = "Software producer",
                IsActive = true,
                Name = "Wordshop",
                ModificationDate = DateTime.Now
            };

            Assert.IsTrue(await companiesServices.AddAsync(company));
        }
    }
}
