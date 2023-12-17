namespace EnterpriseMaster.DesktopApp.Helpers.Methods
{
    public static class OrderStatusClasses
    {
        /// <summary>
        /// Method decides which css class to use.
        /// </summary>
        /// <param name="orderStatus">status</param>
        /// <returns>string with the name of class</returns>
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

        /// <summary>
        /// Method decides which css class to use.
        /// </summary>
        /// <param name="paymentStatus">status</param>
        /// <returns>string with the name of class</returns>
        public static string GetClassForPaymentStatus(string paymentStatus)
        {
            switch (paymentStatus)
            {
                case "Pending":
                    return "blue-button";
                case "Received":
                    return "yellow-button";
                case "Failed":
                    return "orange-button";
                case "Refunded":
                    return "gray-button";
                case "Completed":
                    return "green-button";
                case "Rejected":
                    return "red-button";
                default:
                    return "default-button";
            }
        }
    }
}
