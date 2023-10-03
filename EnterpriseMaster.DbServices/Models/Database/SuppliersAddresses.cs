using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseMaster.DbServices.Models.Database
{
	public class SuppliersAddresses : Addresses
	{
        public List<Suppliers>? Suppliers { get; set; }
    }
}
