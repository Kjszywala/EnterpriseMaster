using EnterpriseMaster.BusinessLogic.Interfaces;
using EnterpriseMaster.DbServices.Helpers;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.BusinessLogic.AuthenticationLogic
{
    public class CheckoutLogic : ICheckoutLogic
    {
        public CheckoutModel GetCheckoutModelBasedOnString(
            List<SubscriptionTypes> subscriptions,
            List<ApplicationFeatures> features,
            List<PaymentMethods> paymentMethods, 
            string value
            )
        {
            var paymentMethod = paymentMethods.FirstOrDefault();
            switch (value)
            {
                case "basic":
                    var basicSubscription = subscriptions.Where(item=>item.Id == 1).FirstOrDefault();
                    return GetCheckoutModel(basicSubscription, paymentMethod, features, 1);

                case "professional":
                    var professionalSubscription = subscriptions.Where(item => item.Id == 3).FirstOrDefault();
                    professionalSubscription.ApplicationFeatures = features.Where(item => item.SubscriptionTypeId == 2).ToList();
                    return GetCheckoutModel(professionalSubscription, paymentMethod, features, 2);

                case "enterprise":
                    var enterpriseSubscription = subscriptions.Where(item => item.Id == 3).FirstOrDefault();
                    enterpriseSubscription.ApplicationFeatures = features.Where(item => item.SubscriptionTypeId == 2).ToList();
                    return GetCheckoutModel(enterpriseSubscription, paymentMethod, features, 3);

                default:
                    return new CheckoutModel();
            }
        }

        /// <summary>
        /// Set and get properties of checkout model based on the lists.
        /// </summary>
        /// <param name="subscription"></param>
        /// <param name="paymentMethod"></param>
        /// <returns></returns>
        private CheckoutModel GetCheckoutModel(
            SubscriptionTypes subscription, 
            PaymentMethods paymentMethod,
            List<ApplicationFeatures> features,
            int subscriptionId)
        {
            var checkoutModel = new CheckoutModel();

            checkoutModel.SubscriptionVat = 0.23m;
            checkoutModel.SubscriptionPrice = subscription.Price;
            checkoutModel.SubscriptionPlusVat = (checkoutModel.SubscriptionPrice * checkoutModel.SubscriptionVat) + checkoutModel.SubscriptionVat;
            checkoutModel.PaymentMethodImage = paymentMethod.Image;
            checkoutModel.SubscriptionName = subscription.SubscriptionName;
            checkoutModel.SubscriptionImage = subscription.Image;
            checkoutModel.SubscriptionInformation = subscription.Description;
            checkoutModel.SubscriptionTotal = checkoutModel.SubscriptionPlusVat;
            checkoutModel.ApplicationFeatures = features.Where(item => item.SubscriptionTypeId == subscriptionId).ToList();

            return checkoutModel;
        }
    }
}
