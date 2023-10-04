using System.ComponentModel.DataAnnotations.Schema;

namespace EnterpriseMaster.DbServices.Models.Database
{
    public class FxRates : Bases
    {
        public DateTime? PostedTime { get; set; }

        public string? TypeCode { get; set; }

        public string? SourceCurrency { get; set; }

        public string? TargetCurrency { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? MidRate { get; set; }
    }
}
