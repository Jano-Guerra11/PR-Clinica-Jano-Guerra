﻿using Entidades;
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
            string consulta = "SELECT DiaAtencion_J AS 'DIA', HoraIngreso_J AS 'INGRESO', HoraEgreso_J AS 'EGRESO' FROM JornadaLaboral WHERE LegajoMedico_J = '"+legajo+"'";
           return ad.obtenerTabla(consulta,"JornadaLaboral");
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

    }
}
