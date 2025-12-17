using System.Globalization;

namespace ProyectoFinalProgra4.Models
{
    public class UserViewModel
    {
        public string ID { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Correo { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public string Estado { get; set; }
        public int TipoUsuario { get; set; }
    }
}
