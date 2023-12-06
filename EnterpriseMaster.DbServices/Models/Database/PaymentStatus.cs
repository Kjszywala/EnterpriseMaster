namespace EnterpriseMaster.DbServices.Models.Database
{
    public class PaymentStatus : Bases
    {
        public string Status { get; set; }
        List<Payments>? Payments { get; set; }
    }
}
