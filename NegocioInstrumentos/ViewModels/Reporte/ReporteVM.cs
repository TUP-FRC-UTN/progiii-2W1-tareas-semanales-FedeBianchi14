using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;

namespace NegocioInstrumentos.ViewModels.Reporte
{
    public class ReporteVM
    {
        private List<InstrumentoItemVM> listaInstrumentos;

        public List<InstrumentoItemVM> ListaInstrumentos { get => listaInstrumentos; set => listaInstrumentos = value; }

        public ReporteVM()
        {
            ListaInstrumentos = new List<InstrumentoItemVM>();
            cargarVariables();

        }

        private void cargarVariables()
        {
            ListaInstrumentos = AccesoDatos.AD_Reporte.obtenerReporteInstrumentos();
        }
    }
}