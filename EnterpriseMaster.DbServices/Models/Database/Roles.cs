namespace EnterpriseMaster.DbServices.Models.Database
{
    public class Roles : Bases
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Employees> Employees { get; set; }
        public List<Users> Users { get; set; }
    }
}
