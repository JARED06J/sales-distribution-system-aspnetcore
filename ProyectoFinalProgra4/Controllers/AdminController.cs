using Microsoft.AspNetCore.Mvc;
using NuGet.ProjectModel;
using ProyectoFinalProgra4.Models;
using ProyectoFinalProgra4.Services;
using ProyectoFinalProgra4.Helpers;
using ServiceReference1;

namespace ProyectoFinalProgra4.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserService _userService;

        public AdminController()
        { 
            _userService = new UserService();
        }

        public async Task<IActionResult> Index(string filtro = "")
        {
            var users = await _userService.ObtenerUsuariosAsync();

            users = users
                .Where(u => string.Equals(u.Estado, "activo", StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (!string.IsNullOrWhiteSpace(filtro))
            {
                var term = filtro.Trim().ToLowerInvariant();
                users = users.Where(u =>
                    (!string.IsNullOrEmpty(u.Nombre) && u.Nombre.ToLowerInvariant().Contains(term)) ||
                    (!string.IsNullOrEmpty(u.PrimerApellido) && u.PrimerApellido.ToLowerInvariant().Contains(term)) ||
                    (!string.IsNullOrEmpty(u.SegundoApellido) && u.SegundoApellido.ToLowerInvariant().Contains(term)) ||
                    (!string.IsNullOrEmpty(u.Correo) && u.Correo.ToLowerInvariant().Contains(term))
                ).ToList();
            }

            return View(users);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            if(!ModelState.IsValid)
                return View(model);

            var(succes, newPassword, error) = await _userService.CreateUserAsync(model);

            if (succes)
            {
                EmailHelper.SendEmail(model.Correo, $"Usuario creado: {model.Usuario}", $"Tu contrasena es: {newPassword}");
                TempData["Message"] = " Proceso Finalizado de forma exitosa";
                return RedirectToAction("Index");
            }


            ModelState.AddModelError("", $"Error al realizar el proceso {error}");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Inactivar(string id)
        {

            var (success, error) = await _userService.InactivarUsuarioAsync(id);

            if (success)
            {
                TempData["Message"] = "Usuario inactivado correctamente.";
            }
            else
            {
                TempData["Message"] = $"Error al inactivar usuario: {error}";
            }

            return RedirectToAction("Index");
        }
    }
}
