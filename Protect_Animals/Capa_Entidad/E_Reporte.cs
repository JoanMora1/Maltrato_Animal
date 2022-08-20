using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public class E_Reporte
    {
        private int _ID_REPORTE;
        private string _NOMBRE;
        private string _APELLIDO;
        private string _CORREO;
        private string _TELEFONO;
        private byte[] _FOTO;

        public int ID_REPORTE { get => _ID_REPORTE; set => _ID_REPORTE = value; }
        public string NOMBRE { get => _NOMBRE; set => _NOMBRE = value; }
        public string APELLIDO { get => _APELLIDO; set => _APELLIDO = value; }
        public string CORREO { get => _CORREO; set => _CORREO = value; }
        public string TELEFONO { get => _TELEFONO; set => _TELEFONO = value; }
        public byte[] FOTO { get => _FOTO; set => _FOTO = value; }
    }
}
