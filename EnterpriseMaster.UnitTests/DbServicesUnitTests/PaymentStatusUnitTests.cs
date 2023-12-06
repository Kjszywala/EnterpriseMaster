using EnterpriseMaster.DbServices.Models.Database;
using EnterpriseMaster.DbServices.Services;

namespace EnterpriseMaster.UnitTests.DbServicesUnitTests
{
    public class PaymentStatusUnitTests
    {
        PaymentStatusService paymentStatusService = new PaymentStatusService();

        [Test]
        public async Task CreateMultiplePaymentStatuses_TestAsync()
        {
            var orderStatuses = new List<PaymentStatus>
            {
                new PaymentStatus
                {
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now,
                    IsActive = true,
                    Notes = "Payment Pending notes",
                    Title = "Payment Pending",
                    Status = "Pending"
                },
                new PaymentStatus
                {
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now,
                    IsActive = true,
                    Notes = "Payment Received notes",
                    Title = "Payment Received",
                    Status = "Received"
                },
                new PaymentStatus
                {
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now,
                    IsActive = true,
                    Notes = "Payment Failed notes",
                    Title = "Payment Failed",
                    Status = "Failed"
                },
                new PaymentStatus
                {
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now,
                    IsActive = true,
                    Notes = "Payment Refunded notes",
                    Title = "Payment Refunded",
                    Status = "Refunded"
                },
                new PaymentStatus
                {
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now,
                    IsActive = true,
                    Notes = "Payment Completed notes",
                    Title = "Payment Completed",
                    Status = "Completed"
                },
            };

            // Add more task statuses as needed
            foreach (var order in orderStatuses)
            {
                await paymentStatusService.AddAsync(order);
            }
        }
    }
}
