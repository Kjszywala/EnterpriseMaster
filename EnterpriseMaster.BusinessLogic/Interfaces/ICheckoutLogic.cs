using EnterpriseMaster.DbServices.Helpers;
using EnterpriseMaster.DbServices.Models.Database;
using EnterpriseMaster.DbServices.Services;

namespace EnterpriseMaster.BusinessLogic.Interfaces
{
    public interface ICheckoutLogic
    {
        /// <summary>
        /// Create checkout model based on the given string.
        /// </summary>
        /// <param name="subscriptions">List of subscriptions</param>
        /// <param name="features">List of features</param>
        /// <param name="paymentMethods">List of payment methods</param>
        /// <param name="value">Plan we want to create model for (basic, professional, enterprise)</param>
        /// <returns></returns>
        CheckoutModel GetCheckoutModelBasedOnString(
            List<SubscriptionTypes> subscriptions, 
            List<ApplicationFeatures> features, 
            List<PaymentMethods> paymentMethods, 
            string value); 
    }
}
