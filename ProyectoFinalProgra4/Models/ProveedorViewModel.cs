using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace ProyectoFinalProgra4.Models
{
    public class ProveedorViewModel
    {
        public string cedulaJuridica { get; set; }

        public string nombre { get; set; }

        public string nombreContacto{ get; set; }

       
        public string telefono { get; set; }

        
        public string correo { get; set; }

        public bool estado { get; set; }


    }
}
