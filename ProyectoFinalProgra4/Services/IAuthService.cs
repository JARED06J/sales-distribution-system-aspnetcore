namespace ProyectoFinalProgra4.Services
{
    public interface IAuthService
    {
        Task<bool> ValidarCredenciales(string usuario, string contraseña, int tipoUsuario);

    }
}
