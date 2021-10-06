using System.ComponentModel.DataAnnotations;

namespace Thesis.Models.Data
{
    public class User
    {
        public long Id { get; set; }
        [Required]
        [Display(Name = "user", Prompt = "Username")]
        [StringLength(20, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 6)]

        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "password", Prompt = "Password")]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "email", Prompt = "Email address")]
        public string Email { get; set; }
        public bool State { get; set; }
        public bool Active { get; set; }
    }
}
