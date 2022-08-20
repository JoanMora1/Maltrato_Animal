using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
    public class N_Reporte
    {
        D_Reporte d_Reporte = new D_Reporte();

        public List<E_Reporte> ListandoReporte(string buscar)
        {
            return d_Reporte.Listar_Reportes(buscar);
        }

        public void InsertandoReporte(E_Reporte e_Reporte)
        {
            d_Reporte.InsertarReporte(e_Reporte);
        }

        public void EditandoReporte(E_Reporte e_Reporte)
        {
            d_Reporte.EditarReporte(e_Reporte);
        }

        public void EliminandoReporte(E_Reporte e_Reporte)
        {
            d_Reporte.EliminarReporte(e_Reporte);
        }
    }
}
