using EnterpriseMaster.BusinessLogic.Interfaces;
using EnterpriseMaster.DbServices.Helpers;
using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;
using Microsoft.AspNetCore.Http;

namespace EnterpriseMaster.BusinessLogic.AuthenticationLogic
{
    public class CheckoutLogic : ICheckoutLogic
    {
        #region Variables

        IUsersServices usersServices;
        IUsersAdressesServices usersAdressesServices;

        #endregion

        #region Constructor

        public CheckoutLogic(IUsersServices _usersServices, IUsersAdressesServices _usersAdressesServices)
        {
            usersServices = _usersServices;
            usersAdressesServices = _usersAdressesServices;
        }

        #endregion

        #region Methods

        public CheckoutModel GetCheckoutModelBasedOnString(
          List<SubscriptionTypes> subscriptions,
          List<ApplicationFeatures> features,
          List<PaymentMethods> paymentMethods,
          string value,
          string session
          )
        {
            var paymentMethod = paymentMethods.FirstOrDefault();
            switch (value)
            {
                case "basic":
                    var basicSubscription = subscriptions.Where(item => item.Id == 1).FirstOrDefault();
                    return GetCheckoutModel(basicSubscription, paymentMethod, features, 1, session);

                case "professional":
                    var professionalSubscription = subscriptions.Where(item => item.Id == 3).FirstOrDefault();
                    return GetCheckoutModel(professionalSubscription, paymentMethod, features, 3, session);

                case "enterprise":
                    var enterpriseSubscription = subscriptions.Where(item => item.Id == 2).FirstOrDefault();
                    return GetCheckoutModel(enterpriseSubscription, paymentMethod, features, 2, session);

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
            int subscriptionId,
            string session
            )
        {
            var checkoutModel = new CheckoutModel();
            var currentUser = usersServices.GetAllAsync().Result.Where(item => item.Email == session).FirstOrDefault();
            var currentUserAddress = usersAdressesServices.GetAllAsync().Result.Where(item => item.Id == currentUser.UserAddressId).FirstOrDefault();
            currentUser.UserAddress = currentUserAddress;

            checkoutModel.SubscriptionVat = 0.23m;
            checkoutModel.SubscriptionPrice = subscription.Price;
            checkoutModel.SubscriptionPlusVat = (checkoutModel.SubscriptionPrice * checkoutModel.SubscriptionVat) + checkoutModel.SubscriptionVat;
            checkoutModel.PaymentMethodImage = paymentMethod.Image;
            checkoutModel.SubscriptionName = subscription.SubscriptionName;
            checkoutModel.SubscriptionImage = subscription.Image;
            checkoutModel.SubscriptionInformation = subscription.Description;
            checkoutModel.SubscriptionTotal = checkoutModel.SubscriptionPlusVat;
            checkoutModel.ApplicationFeatures = features.Where(item => item.SubscriptionTypeId == subscriptionId).ToList();
            checkoutModel.Email = currentUser.Email;
            checkoutModel.Contry = currentUser.UserAddress.Country;
            checkoutModel.DateOfBirth = currentUser.DateOfBirth;
            checkoutModel.FullName = currentUser.FirstName + " " + currentUser.SecondName;


            return checkoutModel;
        }

        #endregion
    }
}
