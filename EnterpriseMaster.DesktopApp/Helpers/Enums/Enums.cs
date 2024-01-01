namespace EnterpriseMaster.DesktopApp.Helpers.Enums
{
    public enum StatusForOrder
    {
        Open = 1,
        InProgress = 2,
        Completed = 3,
        Shipped = 4,
        OnHold = 5,
        Rejected = 7,
    }

    public enum StatusForPayment
    {
        Pending = 1,
        Received = 2,
        Failed = 3,
        Refunded = 4,
        Completed = 5,
        Rejected = 7,
    }

    public enum StatusForPaymentMethod
    {
        Visa = 1
    }

    public enum StatusForProductionOrder
    {
        Open = 1,
        InProgress = 2,
        Completed = 3,
        Rejected = 4
    }

    public enum StatusForRoles
    {
        PurchaseOrders = 1,
        Finance = 2,
        CreateOffers = 3,
        Inventory = 4,
        Invoices = 5,
        SalesOrders = 6,
        Analytics = 7,
        HumanResources = 8,
        Production = 9,
        Accounting = 10,
        CustomerData = 11,
        SalesActivities = 12,
    }
}
