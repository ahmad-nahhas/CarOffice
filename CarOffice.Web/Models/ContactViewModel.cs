using System.ComponentModel.DataAnnotations;

namespace CarOffice.Web.Models
{
    public class ContactViewModel
    {
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name should be minimum 3 characters and a maximum of 50 characters.")]
        [Required(ErrorMessage = "Please enter your full name first!")]
        [Display(Name = "Full Name")]
        [DataType(DataType.Text)]
        public string FullName { get; set; }

        [EmailAddress(ErrorMessage = "Email is incorrect.")]
        [Required(ErrorMessage = "The Email is required.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [MinLength(5, ErrorMessage = "Message should be minimum 5 characters.")]
        [Required(ErrorMessage = "Please enter your message first!")]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Full Name should be minimum 3 characters and a maximum of 50 characters.")]
        [DataType(DataType.Text)]
        public string Subject { get; set; }
    }
}