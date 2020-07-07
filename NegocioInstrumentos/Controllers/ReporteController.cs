using NegocioInstrumentos.ViewModels.Reporte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NegocioInstrumentos.Controllers
{
    public class ReporteController : Controller
    {
        // GET: Reporte
        public ActionResult Reporte()
        {
            ReporteVM resultado = new ReporteVM();
            return View(resultado);
        }
    }
}