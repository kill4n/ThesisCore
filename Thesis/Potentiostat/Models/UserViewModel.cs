using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Potentiostat.Models
{
    public class UserViewModel
    {
        [Required]
        [Display(Name = "user", Prompt = "Usuario")]
        [StringLength(20, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 6)]
        public string User { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "password", Prompt = "Password")]
        public string Password { get; set; }
    }
}
