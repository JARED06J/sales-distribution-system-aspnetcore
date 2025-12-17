using NuGet.Protocol;
using ProyectoFinalProgra4.Helpers;
using ProyectoFinalProgra4.Models;
using ServiceReference1;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProyectoFinalProgra4.Services
{
    public class UserService
    {
        private readonly ServiceReference1.AutenticacionServiceClient _client;

        public UserService()
        {
            _client = new AutenticacionServiceClient();
        }

        public async Task<List<UserViewModel>> ObtenerUsuariosAsync()
        {
            var usuarios = await _client.ObtenerUsuariosAsync();

            return usuarios.Select(u => new UserViewModel
            {
                ID = u.Identificacion,
                Nombre = u.Nombre,
                PrimerApellido = u.PrimerApellido,
                SegundoApellido = u.SegundoApellido,
                Correo = u.Correo,
                Usuario = u.UsuarioCifrado,
                Contraseña = u.ContrasenaCifrada,
                Estado = u.Estado,
                TipoUsuario = u.Tipo

            }).ToList();
        }
        public async Task<(bool success, string error)> InactivarUsuarioAsync(string identificacion)
        {
            try
            {
                
                var solicitud = new SolicitudCambiarEstado
                {
                    Identificacion= identificacion,
                    NuevoEstado = "inactivo"
                };

                
                var result = await _client.CambiarEstadoUsuarioAsync(solicitud);
                await _client.CloseAsync();

                if (result.Resultado)
                    return (true, "");
                else
                    return (false, result.Mensaje ?? "Error desconocido del servicio");
            }
            catch (Exception ex)
            {
                try { await _client.CloseAsync(); } catch { /* ignore */ }
                return (false, ex.Message);
            }
        }
        public async Task<(bool succes, string newPassword, string error)> CreateUserAsync(CreateUserViewModel user)
        {
            try
            {
                string newPassword;
                do
                {
                    newPassword = PasswordGeneratorHelper.Generate(20);
                } while (!PasswordGeneratorHelper.IsComplex(newPassword));

                string usuarioCifrado = AESHelper.Encrypt(user.Usuario);
                string contraseñaCifrada = AESHelper.Encrypt(newPassword);

                var solicitud = new SolicitudRegistro
                {
                    Identificacion = "ID-" + Guid.NewGuid().ToString("N"),
                    Nombre = user.Nombre,
                    PrimerApellido = user.PrimerApellido,
                    SegundoApellido = user.SegundoApellido,
                    Correo = user.Correo,
                    UsuarioCifrado = usuarioCifrado,
                    ContrasenaCifrada = contraseñaCifrada,
                    Estado = "activo",
                    Tipo = user.TipoUsuario

                };

                var result = await _client.RegistrarUsuarioAsync(solicitud);
                await _client.CloseAsync();

                if (result.Resultado)
                {
                    return (true, newPassword, "");

                }
                else
                {
                    return (false, "", result.Mensaje ?? "Error desconocido del servicio");

                }
            }
            catch (Exception ex)
            {
                try { await _client.CloseAsync(); } catch { /* ignore */ }
                return (false, "", ex.Message);

            }




        }
    }
}
