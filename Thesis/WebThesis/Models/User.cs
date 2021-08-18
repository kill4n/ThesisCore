using System;
using System.ComponentModel.DataAnnotations;

namespace WebThesis.Models
{
    public class Users
    {
        [Key]
        public long Id { get; set; }
        [Required("El nombre de usuario es obligatorio")]
        [Display("Nombre de usuario")]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Mail { get; set; }
    }
}
