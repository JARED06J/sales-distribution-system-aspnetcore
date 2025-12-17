using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace ProyectoFinalProgra4.Models
{
    public class ProductoViewModel
    {
        public string NumeroProducto { get; set; }
        public string NombreProducto { get; set; }

        public decimal Precio { get; set; }

        public int tipoTransaccion { get; set; }

    }
}
