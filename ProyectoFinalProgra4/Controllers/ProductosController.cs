using Microsoft.AspNetCore.Mvc;
using ProyectoFinalProgra4.Models;
using ServiceReferenceAlmacen1;
using ProyectoFinalProgra4.Services;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ProyectoFinalProgra4.Controllers
{
    public class ProductosController : Controller
    {
        public readonly ProductoService _service;

        public ProductosController()
        {
            _service = new ProductoService();
        }

        [HttpGet]
        public async Task<IActionResult> Index(string? filtro = null)
        {
            var productos = await _service.ListarProductos(filtro ?? "");
            ViewData["Filtro"] = filtro ?? "";
            return View(productos);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(string id)
        {
            var productos = await _service.ListarProductos(id);
            var producto = productos.FirstOrDefault(p => p.NumeroProducto == id);

            if (producto == null)
            {
                return NotFound();
            }

            ViewData["Action"] = "Editar";
            return View(producto);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(ProductoViewModel producto)
        {
            if (!ModelState.IsValid)
            {
                return View(producto);
            }

            var (succes, mensaje) = await _service.ActualizarProducto(producto);

            if (succes)
            {
                TempData["Mensaje"] = mensaje;
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", mensaje);
                return View(producto);
            }
        }

        [HttpGet]
        public IActionResult Nuevo()
        {
            ViewData["Action"] = "Nuevo";
            return View(new ProductoViewModel());
        }

        [HttpPost]
        [ActionName("Nuevo")]
        public async Task<IActionResult> NuevoPost(ProductoViewModel producto)
        {
            if (!ModelState.IsValid)
                return View("Nuevo", producto);

            var (success, mensaje) = await _service.GuardarProducto(producto);

            if (success)
            {
                TempData["Mensaje"] = mensaje;
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", mensaje);
                return View("Nuevo", producto);
            }
        }
    }
}
