using EnterpriseMaster.DbServices.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace EnterpriseMaster.DbServices.Models
{
    public class DatabaseContext : DbContext
    {
        #region Constructor

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            :base(options) { }

        #endregion

        #region DbSets

        public virtual DbSet<ApplicationBookmarks> ApplicationBookmarks { get; set; }
        public virtual DbSet<ApplicationFeatures> ApplicationFeatures { get; set; }
        public virtual DbSet<BillingAddresses> BillingAddresses { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<CaseStatus> CaseStatus { get; set; }
        public virtual DbSet<CustomerInformation> CustomerInformation { get; set; }
        public virtual DbSet<EmployeeAddresses> EmployeeAddresses { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<ErrorLogs> ErrorLogs { get; set; }
        public virtual DbSet<FxRates> FxRates { get; set; }
        public virtual DbSet<Invoices> Invoices { get; set; }
        public virtual DbSet<InvoiceItem> InvoiceItem { get; set; }
        public virtual DbSet<InvoiceStatuses> InvoiceStatuses { get; set; }
        public virtual DbSet<SalesOrders> SalesOrders { get; set; }
        public virtual DbSet<PurchaseOrders> PurchaseOrders { get; set; }
        public virtual DbSet<ProductionOrders> ProductionOrders { get; set; }
        public virtual DbSet<ProductionOrderStatus> ProductionOrderStatus { get; set; }
        public virtual DbSet<CustomerAddresses> CustomerAddresses { get; set; }
        public virtual DbSet<OrderStatuses> OrderStatuses { get; set; }
        public virtual DbSet<PaymentMethods> PaymentMethods { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Offers> Offers { get; set; }
        public virtual DbSet<QuantityTypes> QuantityTypes { get; set; }
        public virtual DbSet<SaleCart> SaleCart { get; set; }
        public virtual DbSet<Shippers> Shippers { get; set; }
        public virtual DbSet<ShippersAddresses> ShippersAddresses { get; set; }
        public virtual DbSet<ShippingAddresses> ShippingAddresses { get; set; }
        public virtual DbSet<SubscriptionOrders> SubscriptionOrders { get; set; }
        public virtual DbSet<SubscriptionTypes> SubscriptionTypes { get; set; }
        public virtual DbSet<Suppliers> Suppliers { get; set; }
        public virtual DbSet<SuppliersAddresses> SuppliersAddresses { get; set; }
        public virtual DbSet<SupportCases> SupportCases { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersAdresses> UsersAdresses { get; set; }
        public virtual DbSet<EmployeeAccesses> EmployeeAccesses { get; set; }
        public virtual DbSet<WhatsNew> WhatsNew { get; set; }
        public virtual DbSet<AboutPage> AboutPage { get; set; }
        public virtual DbSet<BasicPlanPage> BasicPlanPage { get; set; }
        public virtual DbSet<EnterprisePlan> EnterprisePlan { get; set; }
        public virtual DbSet<MainPages> MainPages { get; set; }
        public virtual DbSet<ProfessionalPlanPage> ProfessionalPlanPage { get; set; }
        public virtual DbSet<Tasks> Tasks { get; set; }
        public virtual DbSet<DbServices.Models.Database.TaskStatus> TaskStatus { get; set; }
        public virtual DbSet<Companies> Companies { get; set; }
        public virtual DbSet<CompanyAddress> CompanyAddress { get; set; }
        public virtual DbSet<Payments> Payments { get; set; }
        public virtual DbSet<Parts> Parts { get; set; }
        public virtual DbSet<PartsCompanies> PartsCompanies { get; set; }
        public virtual DbSet<Refunds> Refunds { get; set; }
        public virtual DbSet<Returns> Returns { get; set; }
        public virtual DbSet<ReturnsStatuses> ReturnsStatuses { get; set; }

        #endregion
    }
}
