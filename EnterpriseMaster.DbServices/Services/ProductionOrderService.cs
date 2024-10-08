﻿using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;

namespace EnterpriseMaster.DbServices.Services
{
    public class ProductionOrderService :
        BaseServices<ProductionOrders>,
        IProductionOrderService
    {
        public ProductionOrderService()
            : base("/api/v1.0/ProductionOrders/")
        {
        }
    }
}
