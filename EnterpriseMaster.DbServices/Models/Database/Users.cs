﻿namespace EnterpriseMaster.DbServices.Models.Database
{
    public class Users : Bases
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string? CompanyName { get; set; }
        public int? SubscriptionTypeId { get; set; }
        public SubscriptionTypes? SubscriptionType { get; set; }


    }
}
