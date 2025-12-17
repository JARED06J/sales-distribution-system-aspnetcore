using ProyectoFinalProgra4.Models;
using ServiceReferenceAlmacen3;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ProyectoFinalProgra4.Services
{
    public class ComprasService
    {
        private readonly ServiceReferenceAlmacen3.WS_Almacen3Client _client;

        public ComprasService()
        {
            _client = new WS_Almacen3Client();
        }

        public async Task<List<UltimasComprasViewModel>> ObtenerUlltimasCompras(string filtro)
        {
            var respuesta = await _client.ObtenerUltimas10ComprasAsync(filtro ?? "");


            return respuesta.Select(
                c => new UltimasComprasViewModel
                {
                    numeroIngreso = c.numeroIngreso,
                    fechaCompra = c.fechaCompra,
                    cedulaJuridica = c.cedulaJuridica,
                    nombre = c.nombre
                }).Take(10).ToList();
        }

        public async Task<DetalleCompras> ObtenerDetalleCompra(string numeroIngreso)
        {
           var respuesta = await _client.ObtenerDetalleCompraAsync(numeroIngreso);

            var detalle = new DetalleCompras
            {
                noProducto = respuesta.noProducto,
                nombreProducto = respuesta.nombreProducto,
                cantidad = respuesta.cantidad,
                nombreProveedor = respuesta.nombreProveedor,
                numeroIngreso = respuesta.numeroIngreso,
                fechaCompra = respuesta.fechaCompra,
                cedulaJuridica = respuesta.cedulaJuridica,
                Productos = respuesta.Productos.Select(p => new ProductoEntradas
                {
                    noProducto = p.noProducto,
                    nombre = p.nombre,
                    cantidad= p.cantidad,
                }).ToList()


            };


            return detalle;
        }

        public async Task<RespuestCompraViewModel> GuardarCompra(NuevaCompraViewModel nuevacompra)
        {
            
                if (nuevacompra.Productos == null || !nuevacompra.Productos.Any())
                    return new RespuestCompraViewModel { resultado = false, mensaje = "No hay productos en la compra" };

                var productos = nuevacompra.Productos.Select(p => new ProductoCompra
            {
                NoProducto = p.Codigo,
                Cantidad = p.Cantidad

            }).ToArray();
            DateTime tiempo = DateTime.Now;

            var respuesta = new CompraInfo
            {
                numeroIngreso = nuevacompra.NumeroIngreso,
                fechaCompra = tiempo.Date,
                cedulaJuridica = nuevacompra.CedulaJuridica,
                listaProductos = productos


            };
            var respuesta2 = await _client.EjecutarCompraAsync(respuesta);

            return new RespuestCompraViewModel
            {
                resultado = respuesta2.Resultado,
                mensaje = respuesta2.Mensaje
            };

        }
    }
}
