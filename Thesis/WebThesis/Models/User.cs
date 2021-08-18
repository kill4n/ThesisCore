using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebThesis.Models
{
    public class User
    {
        [Key]
        public long Id { get; set; }
        [Required(ErrorMessage = "El nombre de usuario es obligatorio")]
        [DisplayName("Nombre de usuario")]
        public string UserName { get; set; }
        [Required]
        [DisplayName("Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string Mail { get; set; }
    }
}
