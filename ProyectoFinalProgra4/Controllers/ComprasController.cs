using Microsoft.AspNetCore.Mvc;
using ProyectoFinalProgra4.Models;
using ProyectoFinalProgra4.Services;

namespace ProyectoFinalProgra4.Controllers
{
    public class ComprasController : Controller
    {
        private readonly ComprasService _service;

        public ComprasController()
        { 
            _service = new ComprasService();
        }

        public async Task<IActionResult> Index(string filtro)
        {
            var compras = await _service.ObtenerUlltimasCompras(filtro);
            return View(compras);
        }

        public async Task<IActionResult> Detalle(string numeroIngreso)
        {
            var compra = await _service.ObtenerDetalleCompra(numeroIngreso);
            return View(compra);
        }

        [HttpGet]
        public IActionResult Nuevo()
        { 
            return View(new NuevaCompraViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Nuevo(NuevaCompraViewModel compra)
        {
            if (!ModelState.IsValid)
            {
                return View(compra);
            }

            var resultado = await _service.GuardarCompra(compra);

            if (resultado.resultado)
            {
                TempData["Mensaje"] = "¡Proceso finalizado de forma exitosa!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Mensaje"] = "Error al realizar el proceso: " + resultado.mensaje;
                return View(compra);
            }
        }


    }
}
