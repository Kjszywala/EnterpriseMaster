using EnterpriseMaster.DbServices.Models.Database;
using EnterpriseMaster.DesktopApp.Data.Models;

namespace EnterpriseMaster.DesktopApp.Helpers.PdfCreation.Models
{
    public class PaymentsReportModel
    {
        public string ReportNumber { get; set; }
        public string LargestSinglePayment { get; set; }
        public string PaymentsTotal { get; set; }
        public string LargestQuantity { get; set; }
        public string QuantityTotal { get; set; }
        public string MostFrequentlySellPart { get; set; }
        public string MostFrequentlyPaymentMethod { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string EmployeeEmail { get; set; }
        public List<PaymentViewModel> Payments { get; set; }
    }
}
