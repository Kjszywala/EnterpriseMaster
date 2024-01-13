using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnterpriseMaster.DbServices.Models.Database
{
    public class Refunds : Bases
    {
        public int? ReturnId { get; set; }
        public Returns? Return { get; set; }
        public DateTime RefundDate { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal RefundAmount { get; set; }
        public int? PaymentMethodId { get; set; }
        public PaymentMethods? RefundMethod { get; set; }
        public string Notes { get; set; }
        public int? Company { get; set; }
    }
}
