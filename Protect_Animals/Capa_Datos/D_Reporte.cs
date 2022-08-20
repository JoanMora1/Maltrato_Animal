using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Capa_Entidad;

namespace Capa_Datos
{
    public class D_Reporte
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public List<E_Reporte> Listar_Reportes (string buscar)
        {
            SqlDataReader leer;
            SqlCommand cmd = new SqlCommand("SP_BUSCAR_REPORTE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();

            cmd.Parameters.AddWithValue("@BUSCAR", buscar);
            leer = cmd.ExecuteReader();

            List<E_Reporte> Listar = new List<E_Reporte>();
            while (leer.Read())
            {
                Listar.Add(new E_Reporte
                {
                    ID_REPORTE = leer.GetInt32(0),
                    NOMBRE = leer.GetString(1),
                    APELLIDO = leer.GetString(2),
                    CORREO = leer.GetString(3),
                    TELEFONO = leer.GetString(4),
                });
            }

            conn.Close();
            leer.Close();
            return Listar;
        }

        public void InsertarReporte (E_Reporte e_Reporte)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTAR_REPORTE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();

            cmd.Parameters.AddWithValue("@NOMBRE", e_Reporte.NOMBRE);
            cmd.Parameters.AddWithValue("@APELLIDO", e_Reporte.APELLIDO);
            cmd.Parameters.AddWithValue("@CORREO", e_Reporte.CORREO);
            cmd.Parameters.AddWithValue("@TELEFONO", e_Reporte.TELEFONO);
            cmd.Parameters.AddWithValue("@FOTO", e_Reporte.FOTO);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void EditarReporte(E_Reporte e_Reporte)
        {
            SqlCommand cmd = new SqlCommand("SP_EDITAR_REPORTE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();

            cmd.Parameters.AddWithValue("@ID_REPORTE", e_Reporte.ID_REPORTE);
            cmd.Parameters.AddWithValue("@NOMBRE", e_Reporte.NOMBRE);
            cmd.Parameters.AddWithValue("@APELLIDO", e_Reporte.APELLIDO);
            cmd.Parameters.AddWithValue("@CORREO", e_Reporte.CORREO);
            cmd.Parameters.AddWithValue("@TELEFONO", e_Reporte.TELEFONO);
            cmd.Parameters.AddWithValue("@FOTO", e_Reporte.FOTO);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void EliminarReporte(E_Reporte e_Reporte)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINAR_REPORTE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();

            cmd.Parameters.AddWithValue("@ID_REPORTE", e_Reporte.ID_REPORTE);

            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
