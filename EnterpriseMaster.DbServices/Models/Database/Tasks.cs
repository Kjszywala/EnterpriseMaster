﻿namespace EnterpriseMaster.DbServices.Models.Database
{
    public class Tasks : Bases
    {
        public string Task { get; set; }
        public string Description { get; set; }
        public bool IsRemoved { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CompleteBy { get; set; }
        public int? EmployeeId { get; set; }
        public Employees? Employee { get; set; }
        public int? TaskStatusId { get; set; }
        public TaskStatus? TaskStatus { get; set; }
        public int? Company { get; set; }
    }
}
