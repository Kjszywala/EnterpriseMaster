using EnterpriseMaster.DbServices.Models.Database;
using EnterpriseMaster.DbServices.Services;
namespace EnterpriseMaster.UnitTests.DbServicesUnitTests
{
    public class QuantityTypesUnitTests
    {
        QuantityTypesServices services = new QuantityTypesServices();

        [Test]
        public async Task CreateNewRowForQuantityTypes_TestAsync()
        {
            List<string> quantityTypes = new List<string>
            {
                "Units",
                "Boxes",
                "Liters",
                "Kilograms",
                "Meters",
                "Square Meters",
                "Sets",
                "Cases",
                "Bags",
                "Grams"
                // Add more quantity types as needed
            };
           
            foreach(var item  in quantityTypes)
            {
                var quantityType = new QuantityTypes()
                {
                    CreationDate = DateTime.Now,
                    IsActive = true,
                    ModificationDate = DateTime.Now,
                    Type = item
                };
                var result = await services.AddAsync(quantityType);
                Assert.True(result);
            }
        }
    }
}
