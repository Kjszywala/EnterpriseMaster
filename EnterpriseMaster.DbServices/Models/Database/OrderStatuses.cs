﻿namespace EnterpriseMaster.DbServices.Models.Database
{
	public class OrderStatuses : Bases
	{
        public int Status { get; set; }
        public string? Discription { get; set; }
        public List<SubscriptionOrders>? SubscriptionOrders { get; set; }
        public List<Orders>? Orders { get; set; }
    }
}
