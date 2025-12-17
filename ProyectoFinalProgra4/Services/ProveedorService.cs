using ServiceReference2;
using ProyectoFinalProgra4.Models;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Dynamic;

namespace ProyectoFinalProgra4.Services
{
    public class ProveedorService
    {
        private readonly WS_Almacen2Client _client;

        public ProveedorService()
        {
            _client = new WS_Almacen2Client();
        }

        public async Task<(bool resultado, string mensaje)> GuardarProveedor(ProveedorViewModel proveedor)
        {


            var p = new Proveedor
            {
                
                CedulaJuridica = proveedor.cedulaJuridica,
                NombreEmpresa = proveedor.nombre,
                NombreContacto = proveedor.nombreContacto,
                Telefono = proveedor.telefono,
                CorreoElectronico = proveedor.correo,
                Estado = proveedor.estado,
                TipoTransaccion = "3"

            };

            try
            {
                var respuesta = await _client.MantenerProveedorAsync(p);
                if (respuesta.Resultado)
                {
                    return (true, "¡Proceso finalizado de manera exitosa!");
                }
                else
                {
                    return (false, "Error al realizar el proceso: " + respuesta.Mensaje);
                }

            }
            catch (Exception ex)
            {
                return (false, "Error interno: " + ex.Message);

            }

        }

        public async Task<(bool succes, string mensaje)> ActualizarProveedor(ProveedorViewModel proveedor)
        {
            var p = new Proveedor
            {
                
                CedulaJuridica = proveedor.cedulaJuridica,
                NombreEmpresa = proveedor.nombre,
                NombreContacto = proveedor.nombreContacto,
                Telefono = proveedor.telefono,
                CorreoElectronico = proveedor.correo,
                Estado = proveedor.estado,
                TipoTransaccion = "4",

            };

            try
            {
                var respuesta = await _client.MantenerProveedorAsync(p);

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
                return (false, "Error interno: "+ex.Message);
            }
        }
        public async Task<List<ProveedorViewModel>> ListarProveedores(string filtro)
        {
            var proveedores = await _client.ListarProveedoresAsync(filtro ?? "");

            return proveedores.Select(p => new ProveedorViewModel
            {
                cedulaJuridica = p.CedulaJuridica,
                nombre = p.NombreEmpresa,
                nombreContacto = p.NombreContacto,
                telefono = p.Telefono,
                correo = p.CorreoElectronico,
                estado = p.Estado,

            }).ToList();
        }

        public async Task<(bool success, string mensaje)> CambiarEstado(string cedulaJuridica)
        {
            try
            {
                var response = await _client.CambiarEstadoProveedorAsync(cedulaJuridica);

                if (response.Resultado)
                {
                    return (true, "Proveedor inactivado exitosamente");
                }
                else
                {
                    return (false, "Error al realizar el proceso");
                }
            }
            catch (Exception ex)
            {
                return (false, "Error al inactivar usuario" +ex.Message);
            }
        }
    }
}
