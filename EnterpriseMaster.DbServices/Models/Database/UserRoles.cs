namespace EnterpriseMaster.DbServices.Models.Database
{
    public class UserRoles : Bases
    {
        public int? UserId { get; set; }
        public Users? Users { get; set; }
        public int? RoleId { get; set; }
        public Roles? Roles { get; set; }
        public bool UserRole { get; set; }
        public int? Company { get; set; }
    }
}
