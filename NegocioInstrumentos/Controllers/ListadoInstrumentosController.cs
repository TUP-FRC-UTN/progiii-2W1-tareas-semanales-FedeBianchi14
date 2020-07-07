using NegocioInstrumentos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NegocioInstrumentos.Controllers
{
    public class ListadoInstrumentosController : Controller
    {
        // GET: ListadoInstrumentos
        public ActionResult ListadoInstrumentos()
        {
            List<Instrumento> listaInstrumentos = AccesoDatos.AD_Instrumentos.ListadoInstrumento();
            return View(listaInstrumentos);
        }
    }
}