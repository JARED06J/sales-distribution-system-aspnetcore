using System.Text;
using System.Security.Cryptography;
using System.Runtime.CompilerServices;
using ServiceReference1;
using ProyectoFinalProgra4.Helpers;

namespace ProyectoFinalProgra4.Services
{
    public class AuthService : IAuthService
    {
        public async Task<bool> ValidarCredenciales(string usuario, string contraseña, int tipoUsuario)
        {
            string usuarioCifrada = AESHelper.Encrypt(usuario);
            string contraseñaCifrada = AESHelper.Encrypt(contraseña);

            var request = new SolicitudLogin
            {
                UsuarioCifrado = usuarioCifrada,
                ContrasenaCifrada = contraseñaCifrada,
                TipoUsuario = tipoUsuario
            };

            var client = new AutenticacionServiceClient();

            RespuestaLogin resultado = await client.AutenticarUsuarioAsync(request);

            await client.CloseAsync();

            return resultado.Resultado;
        }
    }
}


