using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DaoJornadaLaoboral
    {
        AccesoDatos ad = new AccesoDatos();

        public DataTable obtenerJornadaDeMedico(string legajo)
        {
            string consulta = "SELECT DiaAtencion_J AS 'DIA', HoraIngreso_J AS 'INGRESO', HoraEgreso_J AS 'EGRESO' FROM JornadaLaboral WHERE LegajoMedico_J LIKE '"+legajo+"%'";
           return ad.obtenerTabla(consulta,"JornadaLaboral");
        }
        public DataTable obtenerJornadaDeDia(string legajoMedico,string dia)
        {
            string consulta ="SELECT DiaAtencion_J AS 'DIA', HoraIngreso_J AS 'INGRESO', HoraEgreso_J AS 'EGRESO' FROM JornadaLaboral WHERE LegajoMedico_J = '"+legajoMedico+"' " +
                "AND DiaAtencion_J = '"+dia+"'";
            return ad.obtenerTabla(consulta, "diaLaboral");
        }
        public void cargarParametrosJornadaLaboral(ref SqlCommand cmd,JornadaLaboral jl)
        {
            SqlParameter par = new SqlParameter();
            par = cmd.Parameters.Add("@Legajo",SqlDbType.Char,5);
            par.Value = jl.LegajoMedico1;
            par = cmd.Parameters.Add("@Dia", SqlDbType.VarChar, 20);
            par.Value = jl.DiaAtencion1;
            par = cmd.Parameters.Add("@ingreso", SqlDbType.Time);
            par.Value = jl.Ingreso1;
            par = cmd.Parameters.Add("@egreso", SqlDbType.Time);
            par.Value = jl.Egreso;
        }
        public int AltaJornada(JornadaLaboral jl)
        {
            SqlCommand cmd = new SqlCommand();
            cargarParametrosJornadaLaboral(ref cmd,jl);
           return ad.ejecutarProcedimientoAlmacenado(cmd, "SP_AgregarJornadaLaboral");
        }
        public bool existeJornada(JornadaLaboral jl)
        {
            string consulta = "select * from JornadaLaboral where LegajoMedico_J = '"+jl.LegajoMedico1+"' AND DiaAtencion_J = '"+jl.DiaAtencion1+"'";
            return ad.existe(consulta);
        }
        public int actualizarJornada(JornadaLaboral jl)
        {
            string consulta = "UPDATE JornadaLaboral SET DiaAtencion_J = '"+jl.DiaAtencion1+"' , HoraIngreso_J = '"+jl.Ingreso1+"' , HoraEgreso_J = " +
                "'"+jl.Egreso+ "' WHERE LegajoMedico_J = '"+jl.LegajoMedico1+"'";
           return ad.ejecutarConsulta(consulta);
        }
        public int eliminarJornada(JornadaLaboral jl)
        {
            string consulta = "DELETE FROM JornadaLaboral WHERE LegajoMedico_J = '"+jl.LegajoMedico1+"' AND DiaAtencion_J = '"+jl.DiaAtencion1+"'";
           return ad.ejecutarConsulta(consulta);
        }
    }
}
