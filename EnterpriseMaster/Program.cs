using EnterpriseMaster.BusinessLogic.AuthenticationLogic;
using EnterpriseMaster.BusinessLogic.Interfaces;
using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Services;

namespace EnterpriseMaster
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Add session
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(60*5);
                options.Cookie.HttpOnly = true;
            });
            // Session injection
            builder.Services.AddHttpContextAccessor();

            // Add db injection here
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

            // Add logic injection here
            builder.Services.AddScoped<IAuthenticationLogic, AuthenticationLogic>();
            builder.Services.AddScoped<ICheckoutLogic, CheckoutLogic>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}