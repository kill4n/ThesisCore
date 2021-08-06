using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ThesisCore.Controllers
{
    public class LoginModel
    {
        [DisplayName("Usuario *")]
        [Required(ErrorMessage ="El nombre de usuario es requeirido")]
        public string UserName { get; set; }
        [DisplayName("Contraseña *")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        public string Password { get; set; }
    }
}