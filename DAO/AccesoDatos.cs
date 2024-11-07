using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    internal class AccesoDatos
    {
        string RutaClinica = "Data Source=LAPTOPJANO\\SQLEXPRESS;Initial Catalog=CLINICAGuerra;Integrated Security=True";

        private SqlConnection obtenerConexion()
        {
            SqlConnection conexion = new SqlConnection(RutaClinica);

            try
            {
                conexion.Open();
                return conexion;
            }
            catch(Exception err)
            {
                return null;
            }
        }
        private SqlDataAdapter obtenerAdaptador(string consultaSql, SqlConnection conexion)
        {
            SqlDataAdapter adaptador;
            try
            {
                adaptador = new SqlDataAdapter(consultaSql, conexion);
                return adaptador;
            }
            catch(Exception err)
            {
                return null;
            }
        }
        public DataTable obtenerTabla(string consultaSql,string nombreTabla)
        {
            SqlConnection conexion = obtenerConexion();
            SqlDataAdapter adaptador = obtenerAdaptador(consultaSql,conexion);
            DataSet ds = new DataSet();
            adaptador.Fill(ds, nombreTabla);
            conexion.Close();
            return ds.Tables[nombreTabla];
        }
        public int ejecutarProcedimientoAlmacenado(SqlCommand comando, string nombreSP)
        {
            SqlConnection conexion = obtenerConexion();
            SqlCommand cmd = new SqlCommand();
            cmd = comando;
            cmd.Connection = conexion;
            cmd.CommandText = nombreSP;
            cmd.CommandType = CommandType.StoredProcedure;
           int filasAfectadas = cmd.ExecuteNonQuery();
            conexion.Close();
            return filasAfectadas;

        }

        public int ejecutarConsulta(string consultaSql)
        {
            SqlConnection conexion = obtenerConexion();
            SqlCommand cmd = new SqlCommand(consultaSql,conexion);
            int filasAfectadas = cmd.ExecuteNonQuery();
            conexion.Close();
            return filasAfectadas;
        }

        public bool existe(string consultaSql)
        {
            SqlConnection conexion = obtenerConexion();
            SqlCommand cmd = new SqlCommand(consultaSql,conexion);
            SqlDataReader datos = cmd.ExecuteReader();
            if (datos.Read())
            {
                return true;
            }
            else { return false; }
        }
        

        
    }
}
