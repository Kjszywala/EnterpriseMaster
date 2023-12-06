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
}
