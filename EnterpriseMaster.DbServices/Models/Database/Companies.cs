﻿namespace EnterpriseMaster.DbServices.Models.Database
{
    public class Companies : Bases
    {
        public string? Name { get; set; } // The name of the company
        public string? Description { get; set; } // A brief description of the company
        public int? CompanyAddressId { get; set; } // The company's physical address
        public CompanyAddress? CompanyAddress { get; set; } // The company's physical address
        public string? ContactEmail { get; set; } // Email address for contacting the company
        public string? ContactPhone { get; set; } // Phone number for contacting the company
        public DateTime? FoundedDate { get; set; } // Date when the company was founded
        public List<Employees>? Employees { get; set; } // List of employees associated with the company
        public List<Users>? Users { get; set; } // List of employees associated with the company
        //public string? HouseNumber { get; set; }
        //public string? Street { get; set; }
        //public string? City { get; set; }
        //public string? PostCode { get; set; }
        //public string? Country { get; set; }
        //public string? Latitude { get; set; }
        //public string? Longitude { get; set; }
    }
}
