using Microsoft.Build.Execution;
using ServiceReferenceAlmacen1;
using ProyectoFinalProgra4.Models;

namespace ProyectoFinalProgra4.Services
{
    public class ProductoService
    {
        public readonly ServiceReferenceAlmacen1.WS_Almacen1Client _Almacen1Client;

        public ProductoService()
        {
            _Almacen1Client = new WS_Almacen1Client();
        }

        public async Task<List<ProductoViewModel>> ListarProductos(string filtro)
        {
            var productos = await _Almacen1Client.ObtenerProductosAsync(filtro);

            return productos.Select(p => new ProductoViewModel {
                NumeroProducto = p.NumeroProducto,
                NombreProducto = p.NombreProducto,
                Precio = p.Precio

            }).ToList();
        }

        public async Task<(bool success, string mensaje)> ActualizarProducto(ProductoViewModel producto)
        {
            var request = new ServiceReferenceAlmacen1.Producto
            {
                TipoTransaccion = "2",
                NumeroProducto = producto.NumeroProducto,
                NombreProducto = producto.NombreProducto,
                Precio = producto.Precio
            };
            try
            {
                var respuesta = await _Almacen1Client.MantenerProductoAsync(request);
                if (respuesta.Resultado)
                {
                    return (true, "¡Proceso finalizado de forma exitosa!");

                }
                else
                {
                   return (false, "Error al realizar el proceso");
                }
            }
            catch (Exception ex)
            {
                return (false, "Error interno: " + ex.Message);

            }
        }

        public async Task<(bool resultado, string mensaje)> GuardarProducto(ProductoViewModel producto)
        {
            var productos = new ServiceReferenceAlmacen1.Producto{
                TipoTransaccion = "1",
                NumeroProducto = producto.NumeroProducto,
                NombreProducto = producto.NombreProducto,
                Precio = producto.Precio

            };
            try
            {
                var respuesta = await _Almacen1Client.MantenerProductoAsync(productos);
                if (respuesta.Resultado)
                {
                    return (true, "¡Proceso finalizado de forma exitosa!");

                }
                else
                {
                    return (false, "Error al realizar el proceso: " + respuesta.Mensaje);
                }
            }
            catch(Exception ex)
            {
                return (false, "Error interno: " + ex.Message);
            }
        }
    }
}
