using Microsoft.AspNetCore.Mvc;
using ProyectoFinalProgra4.Models;
using ProyectoFinalProgra4.Services;
using System.Threading.Tasks;


namespace ProyectoFinalProgra4.Controllers
{
    public class ProveedoresController : Controller
    {
        private readonly ProveedorService _proveedorService;

        public ProveedoresController()
        {
            _proveedorService = new ProveedorService();
        }
        public async Task<IActionResult> Index(string? filtro = null)
        {
            var lista = await _proveedorService.ListarProveedores(filtro ?? "");
            ViewData["Filtro"] = filtro ?? "";
            return View(lista);
        }

        [HttpGet]
        public IActionResult Nuevo()
        {
            ViewData["Action"] = "Nuevo";
            return View(new ProveedorViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Nuevo(ProveedorViewModel proveedor)
        {
            if (!ModelState.IsValid)
            {
                return View("Nuevo", proveedor);
            }

            var (success, mensaje) = await _proveedorService.GuardarProveedor(proveedor);

            if (success)
            {
                TempData["Mensaje"] = mensaje;
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", mensaje);
                return View("Nuevo", proveedor);
            }
        }


        [HttpGet]
        public async Task<IActionResult> Editar(string id)
        {
            var proveedores = await _proveedorService.ListarProveedores(id);
            var proveedor = proveedores.FirstOrDefault(p => p.cedulaJuridica == id);

            if (proveedor == null)
            {
                return NotFound();
            }
            else
            {
                ViewData["Action"] = "Nuevo";
                return View(proveedor);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Editar(ProveedorViewModel proveedor)
        {
            if (!ModelState.IsValid)
            {
                return View(proveedor);
            }

            var (success, mensaje) = await _proveedorService.ActualizarProveedor(proveedor);

            if (success)
            {
                TempData["Mensaje"] = mensaje;
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", mensaje);
                return View(proveedor);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Inactivar(string cedulaJuridica)
        {
            var resultado = await _proveedorService.CambiarEstado(cedulaJuridica);

            if (resultado.success)
            {
                TempData["Mensaje"] = "Proveedor inactivado correctamente";
            }
            else
            {
                TempData["Mensaje"] = "Error al inactivar el proveedor";
            }

            return RedirectToAction("Index");
        }
    }
}
