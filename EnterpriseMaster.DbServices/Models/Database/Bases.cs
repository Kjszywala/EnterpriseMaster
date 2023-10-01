using System.ComponentModel.DataAnnotations;

namespace EnterpriseMaster.DbServices.Models.Database
{
    public class Bases
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModificationDate { get; set; }
        public bool IsActive { get; set; }
        public string? Notes { get; set; }
        public string? Title { get; set; }
    }
}
