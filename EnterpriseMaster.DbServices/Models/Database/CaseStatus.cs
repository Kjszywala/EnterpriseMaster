﻿namespace EnterpriseMaster.DbServices.Models.Database
{
    public class CaseStatus : Bases
    {
        public string Status { get; set; }
        public int? Company { get; set; }
        public List<SupportCases>? SupportCases { get; set; }
    }
}
