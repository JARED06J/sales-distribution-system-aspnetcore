namespace ProyectoFinalProgra4.Models
{
    public class CompraViewModel
    {
        public int NumeroIngreso { get; set; }
        public string FechaCompra { get; set; }
        public string CedulaJuridica { get; set; }
        public string NombreEmpresa { get; set; }
        public List<ProductoCompraViewModel> Productos { get; set; } = new();
    }
}
