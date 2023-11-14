using EnterpriseMaster.DbServices.Models.Database;
using EnterpriseMaster.DbServices.Services;

namespace EnterpriseMaster.UnitTests.DbServicesUnitTests
{
    public class CategoriesUnitTest
    {
        CategoriesServices services = new CategoriesServices();

        [Test]
        public async Task CreateNewRowForCategories_TestAsync()
        {
            List<string> productCategories = new List<string>
        {
            "Electronics",
            "Clothing and Apparel",
            "Home and Furniture",
            "Books and Media",
            "Toys and Games",
            "Health and Beauty",
            "Sports and Outdoors",
            "Automotive",
            "Appliances",
            "Jewelry and Accessories",
            "Food and Beverages",
            "Office Supplies",
            "Pet Supplies",
            "Fitness and Wellness",
            "Garden and Outdoor",
            "Travel and Luggage",
            "Music Instruments",
            "Art and Crafts",
            "Electrical and Lighting",
            "Miscellaneous"
        };

            foreach (var item in productCategories)
            {
                var category = new Categories()
                {
                    CreationDate = DateTime.Now,
                    IsActive = true,
                    ModificationDate = DateTime.Now,
                    CategotyDescription = item,
                };
                var result = await services.AddAsync(category);
                Assert.True(result);
            }
        }
    }
}
