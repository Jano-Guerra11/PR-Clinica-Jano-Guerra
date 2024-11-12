using DAO;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioJornadaLaboral
    {
        DaoJornadaLaoboral dao = new DaoJornadaLaoboral();

        public DataTable obtenerJornadaDeMedico(string legajo)
        {      
            return dao.obtenerJornadaDeMedico(legajo);

        }
        public bool AltaJornadaLaboral(string LegajoM, string diaAtencion, string Ingreso, string egreso)
        {
            JornadaLaboral jl = new JornadaLaboral();
            jl.LegajoMedico1 = LegajoM;
            jl.DiaAtencion1 = diaAtencion;
            jl.Ingreso1 = Ingreso;
            jl.Egreso = egreso;
            if (dao.AltaJornada(jl) == 1)
            {
                return true;
            }
            else { return false; }
        }
        public DataRow diaLaboralMedico(string legajoMedico,string dia)
        {
            DataTable dt = dao.obtenerJornadaDeDia(legajoMedico,dia);
            return dt.Rows[0];
        }
    }
}
