﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnterpriseMaster.DbServices.Models.Database
{
    public class Offers : Bases
    {
        public int? ProductId { get; set; }
        public Products? Product { get; set; }
        public string OfferName { get; set; }
        public string OfferDescrition { get; set; }
        public bool IsRejected { get; set; }
        public int? Company { get; set; }
        public string? RejectReason { get; set; }
        public DateTime AvailableFrom { get; set; }
        public DateTime AvailableTo { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Discount { get; set; }
        public int? EmployeeId { get; set; }
        public Employees? Employee { get; set; }
    }
}
