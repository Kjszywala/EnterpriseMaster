﻿namespace EnterpriseMaster.DbServices.Models.Database
{
    public class Addresses : Bases
	{
		public string? HouseNumber { get; set; }
		public string? Street { get; set; }
		public string? City { get; set; }
		public string? PostCode { get; set; }
		public string? Country { get; set; }
		public string? Latitude { get; set; }
		public string? Longitude { get; set; }
	}
}
