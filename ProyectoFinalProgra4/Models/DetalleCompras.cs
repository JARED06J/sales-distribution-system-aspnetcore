namespace ProyectoFinalProgra4.Models
{
    public class DetalleCompras
    {
        public string noProducto { get; set; }
        public string nombreProducto { get; set; }
        public int cantidad { get; set; }
        public string nombreProveedor { get; set; }
        public string numeroIngreso { get; set; }
        public string fechaCompra { get; set; }
        public string cedulaJuridica { get; set; }

        public List<ProductoEntradas> Productos { get; set; }
    }
}
