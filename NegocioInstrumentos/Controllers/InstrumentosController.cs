using NegocioInstrumentos.AccesoDatos;
using NegocioInstrumentos.Models;
using NegocioInstrumentos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NegocioInstrumentos.Controllers
{
    public class InstrumentosController : Controller
    {
        // GET: Instrumentos
        public ActionResult AgregarInstrumentos()
        {
            List<TipoItemVM> listaTipo = AD_TipoInstrumentoVM.ObtenerTipoInstrumento();
            List<SelectListItem> items = listaTipo.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.NombreTipo,
                    Value = d.IdTipo.ToString(),
                    Selected = false


                };
            });
            ViewBag.items = items;
            return View();
        }

        [HttpPost]
        public ActionResult AgregarInstrumentos(Instrumento instrumento)
        {
            if (ModelState.IsValid)
            {
                
                
                bool resultado = AD_Instrumentos.InsertarInstrumentos(instrumento);
                if (resultado)
                {
                    return RedirectToAction("AgregarInstrumento", "Instrumentos");
                }
                else
                {
                    return View(instrumento);
                }
                
            }
            else
            {
                return View(instrumento);
            }
        }
    }
}