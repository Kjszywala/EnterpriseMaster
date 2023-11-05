using EnterpriseMaster.BusinessLogic.AuthenticationLogic;
using EnterpriseMaster.BusinessLogic.Interfaces;
using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Services;
using EnterpriseMaster.DesktopApp.Data.Services.LoginService;
using EnterpriseMaster.DesktopApp.Data.Services.MainLayout;
using Microsoft.Extensions.Logging;

namespace EnterpriseMaster.DesktopApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddBlazorBootstrap();
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
		    builder.Logging.AddDebug();
#endif
            // Desktop app injection
            builder.Services.AddSingleton<MainLayoutService>();
            builder.Services.AddSingleton<LoginService>();

            // Db injection
            builder.Services.AddScoped<IAboutPageServices, AboutPageServices>();
            builder.Services.AddScoped<IApplicationBookmarksServices, ApplicationBookmarksServices>();
            builder.Services.AddScoped<IApplicationFeaturesServices, ApplicationFeaturesServices>();
            builder.Services.AddScoped<IBasicPlanServices, BasicPlanServices>();
            builder.Services.AddScoped<IBillingAddressesServices, BillingAddressesServices>();
            builder.Services.AddScoped<ICategoriesServices, CategoriesServices>();
            builder.Services.AddScoped<ICustomerInformationsServices, CustomerInformationsServices>();
            builder.Services.AddScoped<IEmployeeAddressesServices, EmployeeAddressesServices>();
            builder.Services.AddScoped<IEmployeesServices, EmployeesServices>();
            builder.Services.AddScoped<IEnterprisePlanServices, EnterprisePlanServices>();
            builder.Services.AddScoped<IErrorLogsServices, ErrorLogsServices>();
            builder.Services.AddScoped<IFxRatesServices, FxRatesServices>();
            builder.Services.AddScoped<IInvoicesServices, InvoicesServices>();
            builder.Services.AddScoped<IMainPageServices, MainPageServices>();
            builder.Services.AddScoped<IOrdersServices, OrdersServices>();
            builder.Services.AddScoped<IOrderStatusesServices, OrderStatusesServices>();
            builder.Services.AddScoped<IPaymentMethodsServices, PaymentMethodsServices>();
            builder.Services.AddScoped<IProductsServices, ProductsServices>();
            builder.Services.AddScoped<IProfessionalPlanServices, ProfessionalPlanServices>();
            builder.Services.AddScoped<IQuantityTypesServices, QuantityTypesServices>();
            builder.Services.AddScoped<ISaleCartsServices, SaleCartsServices>();
            builder.Services.AddScoped<IShippersServices, ShippersServices>();
            builder.Services.AddScoped<IShippingAddressesServices, ShippingAddressesServices>();
            builder.Services.AddScoped<ISubscriptionOrdersServices, SubscriptionOrdersServices>();
            builder.Services.AddScoped<ISubscriptionTypesServices, SubscriptionTypesServices>();
            builder.Services.AddScoped<ISuppliersAddressesServices, SuppliersAddressesServices>();
            builder.Services.AddScoped<ISuppliersServices, SuppliersServices>();
            builder.Services.AddScoped<IUsersAdressesServices, UsersAdressesServices>();
            builder.Services.AddScoped<IUsersServices, UsersServices>();
            builder.Services.AddScoped<IWhatsNewsServices, WhatsNewsServices>();
            builder.Services.AddScoped<ISupportCaseServices, SupportCaseServices>();
            builder.Services.AddScoped<ICaseStatusServices, CaseStatusServices>();

            //Business logic injection
            builder.Services.AddScoped<IAuthenticationLogic, AuthenticationLogic>();
            builder.Services.AddScoped<ICheckoutLogic, CheckoutLogic>();

            return builder.Build();
        }
    }
}