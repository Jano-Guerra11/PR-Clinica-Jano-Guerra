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
        public bool altaTurno( string dniPaciente, string legajoMedico, string dia, DateTime horario,
            string estado)
        {
            Turnos turno = new Turnos();
            
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
        public DataTable obtenerTurnosDeMedico( string nombreP,string apellidoP, string fecha, string opFecha, string estado, string legajoMedico)
        {
            Turnos turno = new Turnos();
           
            turno.Dia = fecha;
            turno.LegajoMedico = legajoMedico;
            turno.Estado = estado;
            return dao.obtenerTurnosMedico(legajoMedico);
        }
    }
}
