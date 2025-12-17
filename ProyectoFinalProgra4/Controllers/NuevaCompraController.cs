using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using ProyectoFinalProgra4.Models;
using ProyectoFinalProgra4.Services;

namespace ProyectoFinalProgra4.Controllers
{
    public class NuevaCompraController : Controller
    {
        private readonly ComprasService _service;

        public NuevaCompraController()
        {
            _service = new ComprasService();
        }
        public IActionResult Nuevo()
        {
            var model = new NuevaCompraViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Nuevo(NuevaCompraViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(model);

                var respuesta = await _service.GuardarCompra(model);

                if (respuesta.resultado)
                {
                    TempData["Mensaje"] = "Proceso Finalizado con éxito";
                    return View(model);
                }
                else
                {
                    // Mensaje de error del servicio
                    ViewBag.Error = "Error: " + respuesta.mensaje;
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                // Mensaje de excepción inesperada
                ViewBag.Error = "Ocurrió un error inesperado: " + ex.Message;
                return View(model);
            }

        }
    }

}
