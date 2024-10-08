﻿namespace EnterpriseMaster.DbServices.Models.Database
{
	public class PaymentMethods : Bases
	{
        public string PaymentType { get; set; }
		public byte[]? Image { get; set; }
		public List<Invoices>? Invoices { get; set; }
		public List<Refunds>? Refunds { get; set; }
        public List<Payments>? Payments { get; set; }
        public List<PaymentReports>? PaymentReports { get; set; }
    }
}
