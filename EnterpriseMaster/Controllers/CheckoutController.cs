using EnterpriseMaster.Helpers.Models;
using Microsoft.AspNetCore.Mvc;

namespace EnterpriseMaster.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Index(string type)
        {
            var checkoutModel = new CheckoutModel()
            {
                PaymentMethodImage = new byte[0],
                SubscriptionDelivery = 123m,
                SubscriptionImage = new byte[0],
                SubscriptionInformation = "info",
                SubscriptionName = "name",
                SubscriptionPlusVat = 123m,
                SubscriptionPrice = 100m,
                SubscriptionTotal = 0m,
                SubscriptionVat = 0.23m
            };
            return View();
        }
    }
}
