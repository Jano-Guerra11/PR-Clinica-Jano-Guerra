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

            if (!dao.existeJornada(jl))
            {
                return (dao.AltaJornada(jl) == 1) ? true : false;
            }
            return false;
        }
        public DataRow diaLaboralMedico(string legajoMedico,string dia)
        {
            DataTable dt = dao.obtenerJornadaDeDia(legajoMedico,dia);
            if(dt.Rows.Count > 0)
            {
            return dt.Rows[0];

            }
            return null;
        }
        public bool actualizarJornada(JornadaLaboral jl,string diaAnterior)
        {
           return (dao.actualizarJornada(jl,diaAnterior) > 0) ? true : false;         
        }
        public bool bajaJornadaLaboral(string legajo,string dia)
        {
            JornadaLaboral jl = new JornadaLaboral();
            jl.LegajoMedico1 = legajo;
            jl.DiaAtencion1 = dia;
            
            if(dao.existeJornada(jl))
            {
               return (dao.eliminarJornada(jl) > 0) ? true : false;
            }
            return false;
        }
        public bool ExisteJornada(string legajo,string dia)
        {
            JornadaLaboral jl = new JornadaLaboral();
            jl.LegajoMedico1 = legajo;
            jl.DiaAtencion1 = dia;
           return dao.existeJornada(jl);
        }
    }
}
