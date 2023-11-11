using EnterpriseMaster.DbServices.Interfaces;
using EnterpriseMaster.DbServices.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseMaster.DbServices.Services
{
    public class CompaniesServices :
        BaseServices<Companies>,
        ICompaniesServices
    {
        public CompaniesServices() 
            : base("/api/v1.0/Companies/")
        {
        }
    }
}
