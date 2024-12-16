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
        public bool altaTurno(string dniPaciente, string legajoMedico, string dia, TimeSpan horario,
            string estado)
        {
            Turnos turno = new Turnos();
           
            turno.DniPaciente = dniPaciente;
            turno.LegajoMedico = legajoMedico;
            turno.Dia = dia;
            turno.Horario = horario;
            turno.Estado = estado;

            return (dao.altaTurno(turno) > 0) ? true : false;
        }
        public DataTable obtenerTurnos()
        {
            return dao.obtenerTurnos();
        }
        public DataTable turnosDelMes()
        {
            return dao.obtenerTurnosDelMesActual();
        }
        public int[] CantTurnos()
        {
            int[] estado ={0,0,0};// 0 = indefinido ; 1 = presente ; 2 = ausente
            DataTable turnos = turnosDelMes();
            foreach(DataRow row in turnos.Rows)
            {
                if (row["estado_T"].ToString() == "presente")
                {
                    estado[1]++;
                }else if(row["estado_T"].ToString() == "ausente")
                {
                    estado[2]++;
                }
                else
                {
                    estado[0]++;
                }
            }
            return estado;
        }
        public float[] calcularProcentajes()
        {
           DataTable dt = turnosDelMes();
            int total = dt.Rows.Count;
            int[] cantEstados = CantTurnos();
            float[] porcentajes = { 0, 0, 0 }; // 0 = indefinido ; 1 = presente ; 2 = ausente
            porcentajes[0] = (cantEstados[0] * 100) / total;
            porcentajes[1] = (cantEstados[1] * 100) / total;
            porcentajes[2] = (cantEstados[2] * 100) / total;

            return porcentajes;
        }
        public DataTable obtenerTurnosMedico(string legajoM)
        {
            return dao.obtenerTurnosMedico(legajoM);
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
            Turnos turno = new Turnos();
            turno.CodTurno = Convert.ToInt32(codigo);
            if (dao.existeTurno(turno))
            {
               return (dao.bajaTurno(codigo) > 0) ? true : false;
            }
            return false;
        }
        public DataTable obtenerTurnosPaciente(string dni)
        {
            return dao.obtenerTurnosDePaciente(dni);
        }
        
    }
}
