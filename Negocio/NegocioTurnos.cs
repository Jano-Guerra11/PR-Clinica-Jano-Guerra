using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using Entidades;

namespace Negocio
{
    public class NegocioTurnos
    {
        DaoTurnos dao = new DaoTurnos();
        public DataTable obtenerHorariosDeDia(string fecha,string legajoMedico)
        {
            DataTable dt = dao.verHorariosDeDia(fecha, legajoMedico);
            return dt;
        }
        public bool altaTurno(string dniPaciente, string legajoMedico, string dia, DateTime horario,
            string estado)
        {
            Turnos turno = new Turnos();
            turno.CodTurno = 1;
            turno.DniPaciente = dniPaciente;
            turno.LegajoMedico = legajoMedico;
            turno.Dia = dia;
            turno.Horario = horario;
            turno.Estado = estado;
            
           
            if (dao.altaTurno(turno) > 0)
            {
                return true;
            }

                return false;
        }
        public DataTable obtenerTurnos()
        {
            return dao.obtenerTurnos();
        }
        public DataTable obtenerTurnosFiltrados( string nombreP,string apellidoP, string fecha, string opFecha, string estado, string legajoMedico)
        {
            Turnos turno = new Turnos();
            
            turno.Dia = fecha;
            turno.LegajoMedico = legajoMedico;
            turno.Estado = estado;
            return dao.obtenerTurnosFiltrados(turno,opFecha,nombreP,apellidoP);
        }
        public bool dejarEstadoYobservacion(int codTurno, string observacion, string estado)
        {
            Turnos turno = new Turnos();
            turno.CodTurno = codTurno;
            turno.Observacion = observacion;
            turno.Estado = estado;
            if (dao.actualizarEstadoYObservacion(turno) == 1)
            {
                return true;
            }
            else { return false; }
        }
        public bool bajaTurno(string codigo)
        {
            if (dao.bajaTurno(codigo) > 0)
            {
                return true;
            }
            return false;
        }
        
    }
}
