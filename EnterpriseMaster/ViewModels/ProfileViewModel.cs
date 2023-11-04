using System.ComponentModel.DataAnnotations;

namespace EnterpriseMaster.ViewModels
{
    public class ProfileViewModel
    {
        [Display(Name = "First Name:")]
        public string? FirstName { get; set; }
        [Display(Name = "Second Name:")]
        public string? SecondName { get; set; }
        [Display(Name = "Password:")]
        public string? Password { get; set; }
        [Display(Name = "Company Name:")]
        public string? CompanyName { get; set; }
        [Display(Name = "E-mail:")]
        public string? Email { get; set; }
        [Display(Name = "Date Of Birth:")]
        public DateTime? DateOfBirth { get; set; }
        [Display(Name = "Position:")]
        public string? Position { get; set; }
        [Display(Name = "Business Area:")]
        public string? BusinessArea { get; set; }
        [Display(Name = "Subscription Type:")]
        public string? SubscriptionType { get; set; }
        [Display(Name = "Profile Image:")]
        public byte[]? ProfileImage { get; set; }
        [Display(Name = "Subscribe To News Letter:")]
        public bool NewsLetter { get; set; } = false;
        [Display(Name = "Street:")]
        public string? StreetAddress { get; set; }
        [Display(Name = "City:")]
        public string? City { get; set; }
        [Display(Name = "State:")]
        public string? State { get; set; }
        [Display(Name = "Post Code:")]
        public string? PostalCode { get; set; }
        [Display(Name = "Country:")]
        public string? Country { get; set; }
    }
}
