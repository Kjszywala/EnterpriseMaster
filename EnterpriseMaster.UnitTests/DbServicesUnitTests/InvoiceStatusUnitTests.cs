using EnterpriseMaster.DbServices.Models.Database;
using EnterpriseMaster.DbServices.Services;
namespace EnterpriseMaster.UnitTests.DbServicesUnitTests
{
    public class InvoiceStatusUnitTests
    {
        InvoiceStatusServices invoiceStatusService = new InvoiceStatusServices();

        [Test]
        public async Task CreateMultipleInvoiceStatuses_TestAsync()
        {
            var invoiceStatuses = new List<InvoiceStatuses>
            {
                new InvoiceStatuses
                {
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now,
                    IsActive = true,
                    Notes = "Status 1 notes",
                    Title = "Status 1",
                    Status = "Open"
                },
                new InvoiceStatuses
                {
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now,
                    IsActive = true,
                    Notes = "Status 2 notes",
                    Title = "Status 2",
                    Status = "In Progress"
                },
                new InvoiceStatuses
                {
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now,
                    IsActive = true,
                    Notes = "Status 3 notes",
                    Title = "Status 3",
                    Status = "Completed"
                }
            };

            // Add more task statuses as needed
            foreach (var invoiceStatus in invoiceStatuses)
            {
                await invoiceStatusService.AddAsync(invoiceStatus);
            }
        }
    }
}
