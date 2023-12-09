namespace EnterpriseMaster.DesktopApp.Helpers.Methods
{
    public static class OrderStatusClasses
    {
        public static string GetClassForOrderStatus(string orderStatus)
        {
            switch (orderStatus)
            {
                case "Open":
                    return "blue-button";
                case "In Progress":
                    return "orange-button";
                case "Completed":
                    return "green-button";
                case "Shipped":
                    return "purple-button";
                case "On Hold":
                    return "yellow-button";
                case "Rejected":
                    return "red-button";
                default:
                    return "default-button";
            }
        }
    }
}
