using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalProgra4.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="El usuario es obligatorio")]
        public string Usuario { get; set; }
        [Required(ErrorMessage ="La contraseña no puede estar vacía.")]
        [DataType(DataType.Password)]
        public string Contraseña { get; set; }
    }
}
