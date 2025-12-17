using Microsoft.AspNetCore.Mvc;
using ProyectoFinalProgra4.Models;
using ProyectoFinalProgra4.Services;





namespace ProyectoFinalProgra4.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        { 
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            bool esValido = await _authService.ValidarCredenciales(model.Usuario, model.Contraseña, 1);

            if (esValido)
            {
                
                return RedirectToAction("Index", "Productos");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Usuario y/o contraseña incorrectos");
                return View(model);
            }
        }

        public IActionResult Logout()
        {
            return RedirectToAction("Login");
        }
    }
}


